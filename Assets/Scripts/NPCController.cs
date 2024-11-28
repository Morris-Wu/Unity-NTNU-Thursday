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

        private Animator ani;
        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();

        }
    }
}
