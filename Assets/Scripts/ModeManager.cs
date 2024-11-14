
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
    public class ModelManager : MonoBehaviour
    {
        private string url = "https://g.ubitus.ai/v1/chat/completions";
        private string key = "d4pHv5n2G3q2vkVMPen3vFMfUJic4huKiQbvMmGLWUVIr/ptUuGnsCx/zVdYmVtdrGPO9//2h8Fbp6HkSQ0/oA==";

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
            var data = new
            {
                model = "llama-3.1-70b",
                messages = new
                {
                    name = "user",
                    content = prompt,
                    role = this.role
                },
                stop = new string[] { "<|eot_id|>", "<|end_of_text|>" },
                frequency_penalty = 0,
                max_tokens = 2000,
                temperature = 0.2,
                top_p = 0.5,
                top_k = 20,
                stream = false
            };

            string json = JsonUtility.ToJson(data);
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
