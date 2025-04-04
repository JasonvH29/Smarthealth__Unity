/*using System.Collections;
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
}*/
private async Task<string> PerformApiCall(string url, string method, string jsonData = null, string token = null)
{
    using (UnityWebRequest request = new UnityWebRequest(url, method))
    {
        if (!string.IsNullOrEmpty(jsonData))
        {
            byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        if (!string.IsNullOrEmpty(token))
        {
            request.SetRequestHeader("Authorization", "Bearer " + token);
        }

        await request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("API-aanroep is successvol: " + request.downloadHandler.text);

            return request.downloadHandler.text;
        }
        else
        {
            Debug.Log("Fout bij API-aanroep: " + request.error);
            return null;
        }
    }
}

private IWebRequestResponse ParseEnvironment2DResponse(IWebRequestResponse webRequestResponse)
{
    switch (webRequestResponse)
    {
        case WebRequestData<string> data:
            Debug.Log("Response data raw: " + data.Data);
            Environment2D environment = JsonUtility.FromJson<Environment2D>(data.Data);
            WebRequestData<Environment2D> parsedWebRequestData = new WebRequestData<Environment2D>(environment);
            return parsedWebRequestData;
        default:
            return webRequestResponse;
    }
}

private IWebRequestResponse ParseEnvironment2DListResponse(IWebRequestResponse webRequestResponse)
{
    switch (webRequestResponse)
    {
        case WebRequestData<string> data:
            Debug.Log("Response data raw: " + data.Data);
            List<Environment2D> environment2Ds = JsonHelper.ParseJsonArray<Environment2D>(data.Data);
            WebRequestData<List<Environment2D>> parsedWebRequestData = new WebRequestData<List<Environment2D>>(environment2Ds);
            return parsedWebRequestData;
        default:
            return webRequestResponse;
    }
}