
using System.Text;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Morris
{
    ///<summary>
    ///Hugging Face 管理器
    ///</summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "你是一隻小狗";
        private string[] npcSentences;

        [SerializeField, Header("NPC 物件")]
        private NPCController npc;

        private void Awake()
        {
            inputField = GameObject.Find("輸入欄位").GetComponent<TMP_InputField>();
            inputField.onEndEdit.AddListener(PlayerInput);
            npcSentences = npc.data.sentences;
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>{input}</color>");
            prompt = input;
            StartCoroutine(GetResult());
        }

        private IEnumerator GetResult()
        {
            var inputs = new
            {

                source_sentence = prompt,
                sentences = npcSentences

            };

            string json = JsonConvert.SerializeObject(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                print($"<color=#f33>要求失敗:{request.error}</color>");
            }
            else
            {
                string responseTet = request.downloadHandler.text;
                var response = JsonConvert.DeserializeObject<List<string>>(responseTet);
                print($"<color=#3f3>分數:{responseTet}</color>");

                if (response != null && response.Count > 0)
                {
                    int best = response.Select((value, index) => new
                    {
                        Value = value,
                        Index = index
                    }).OrderByDescending(x => x.Value).First().Index;

                    print($"<color=#37f>最佳答案:{npcSentences[best]}</color>");

                    npc.PlayAinmation(best);
                }

            }

        }
    }
}


