using UnityEngine;

namespace Morris
{
    /// <summary>
    /// NPC 資料
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        [SerializeField, Header("NPC 資料")]
        private DataNPC dataNPC;
        [SerializeField, Header("動畫參數")]
        private string[] paramaters =
        {
            "觸發攻擊_01","防禦","死亡","觸發攻擊_02","跑"
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
