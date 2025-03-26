using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.PackageManager.Requests;

public class APIservice : MonoBehaviour
{
    private string URL = "";
    public Text LevelText;
    public Text ExpText;

    public int indec;
    private void Start()
    {
        StartCoroutine(GetDatas());
    }
    IEnumerator GetDatas()
    {
        using(UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.LogError(request.error);
            else
            {
                string json = request.downloadHandler.text;
// SimpleJSON JSONMode stats = SimpleJSON JSON Parse(json);
                LevelText.text = "tect";
            }
        }
    }
}
