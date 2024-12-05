using UnityEngine;

namespace Morris
{
    /// <summary>
    /// NPC ���
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        [SerializeField, Header("NPC ���")]
        private DataNPC dataNPC;
        [SerializeField, Header("�ʵe�Ѽ�")]
        private string[] paramaters =
        {
            "Ĳ�o����_01","���m","���`","Ĳ�o����_02","�]"
        };

        private Animator ani;
        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();

        }
        public void PlayAinmation(int index)
        {
            ani.SetTrigger(paramaters[index]);
        }
    }
}
