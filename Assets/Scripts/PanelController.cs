using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.Text;
using System;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // The video panel
    public Button btn1; // "Druk op mij!" Button
    public Button backBtn; // Scene's Back button (outside the panel)
    public Button nextBtn; // Next button (outside the panel)
    public Button back2; // Back button INSIDE the panel
    public TextMeshProUGUI videoDescription; // TMP text inside the panel

    void Start()
    {
        // Make sure everything is in the correct initial state
        panel.SetActive(false);
        back2.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);

        // Add event listeners to buttons
        btn1.onClick.AddListener(ShowPanel);
        back2.onClick.AddListener(HidePanel);

        // Add TTS trigger when clicking on text
        if (videoDescription != null)
        {
            videoDescription.GetComponent<Button>().onClick.AddListener(() => SpeakText(videoDescription.text));
        }
        else
        {
            UnityEngine.Debug.LogError("videoDescription is not assigned!");
        }
    }

    void ShowPanel()
    {
        panel.SetActive(true);
        btn1.gameObject.SetActive(false);
        nextBtn.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);

        back2.gameObject.SetActive(true);

        videoDescription.text = "This is a video about learning with Amando.";
    }

    void HidePanel()
    {
        panel.SetActive(false);
        back2.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);
    }

    void SpeakText(string text)
    {
        if (string.IsNullOrEmpty(text)) return;

        // Convert text to UTF-8
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        string utf8Text = Encoding.UTF8.GetString(bytes);

        // Use CHCP 65001 for UTF-8 support
        string command = $"chcp 65001 > nul && espeak \"{utf8Text}\"";

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();
    }
}
// Werkt het??? 
// Het werkt!
