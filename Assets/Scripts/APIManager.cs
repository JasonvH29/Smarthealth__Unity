using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;
using System.IO;

public class APIManager : MonoBehaviour
{
    public static ApiManger()
    {
        httpWebRequest request = (HttpWebRequest)WebRequest.Create("lu1project.azurewebsites.net");
        httpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
    }
   
    private string baseUrl = "lu1project.azurewebsites.net";

    public void GetUserById(string userId)
    {
        StartCoroutine(GetUserCoroutine(userId));
    }

    private IEnumerator GetUserCoroutine(string userId)
    {
        string url = $"{baseUrl}/{userId}";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User Data: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error fetching user: " + request.error);
            }
        }
    }
    private IEnumerator CreateUserCoroutine(string jsonData)
    {
        string url = $"{baseUrl}";
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] jsonToSend = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User created: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error creating user: " + request.error);
            }
        }
    }
}