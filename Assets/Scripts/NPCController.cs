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

        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();

        }
    }
}
