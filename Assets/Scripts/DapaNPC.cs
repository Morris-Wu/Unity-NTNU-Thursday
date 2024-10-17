using UnityEngine;

namespace Morris
{
    /// <summary>
    /// NPC 資料
    /// </summary>
    [CreateAssetMenu(menuName = "Morris/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC 要分析的句子")]
        public string[] sentences;




    }
}

