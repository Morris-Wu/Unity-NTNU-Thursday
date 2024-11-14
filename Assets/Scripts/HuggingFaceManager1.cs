
using System.Text;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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

        private void Awake()
        {
            inputField = GameObject.Find("輸入欄位").GetComponent<TMP_InputField>();
            inputField.onEndEdit.AddListener(PlayerInput);
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
                sentences = ""
                
            };

            string json = JsonUtility.ToJson(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = new UnityWebRequest(url, "Post");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization.", "Bearer " + key);

            yield return request.SendWebRequest();

            print(request.result);
        }

    }
}
