using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class APIservice : MonoBehaviour
{
    private string URL = "https://your-api-url.com/data";
    public Text LevelText;
    public Text ExpText;

    private void Start()
    {
        StartCoroutine(GetDatas());
    }

    IEnumerator GetDatas()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                var stats = JSON.Parse(json);

                LevelText.text = "Level: " + stats["level"];
                ExpText.text = "EXP: " + stats["exp"];
            }
        }
    }
}