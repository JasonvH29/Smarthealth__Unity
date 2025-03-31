using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // The video panel
    public Button btn1; // "Druk op mij!" Button
    public Button backBtn; // Scene's Back button (outside the panel)
    public Button nextBtn; // Next button (outside the panel)
    public Button back2; // Back button INSIDE the panel
    public Button doneBtn; // Done button (hidden initially)
    public Button playBtn;  // Play button
    public Button pauseBtn; // Pause button

    public VideoPlayer videoPlayer; // Reference to VideoPlayer component

    void Start()
    {
        panel.SetActive(false);
        back2.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);
        doneBtn.gameObject.SetActive(false);

        playBtn.gameObject.SetActive(false); // Hide Play button initially
        pauseBtn.gameObject.SetActive(false); // Hide Pause button initially

        btn1.onClick.AddListener(ShowPanel);
        back2.onClick.AddListener(HidePanel);
        doneBtn.onClick.AddListener(OnDoneClick);
        playBtn.onClick.AddListener(PlayVideo);
        pauseBtn.onClick.AddListener(PauseVideo);

        videoPlayer.loopPointReached += VideoEnded;
    }

    void ShowPanel()
    {
        panel.SetActive(true);
        btn1.gameObject.SetActive(false);
        nextBtn.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        back2.gameObject.SetActive(true);

        videoPlayer.Play();
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true); // Show Pause button
    }

    void HidePanel()
    {
        panel.SetActive(false);
        back2.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);

        doneBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(false);
    }

    void VideoEnded(VideoPlayer vp)
    {
        doneBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(true); // Show Play button to restart video
        pauseBtn.gameObject.SetActive(false);
    }

    void OnDoneClick()
    {
        HidePanel();
        TypewriterEffect typewriter = FindObjectOfType<TypewriterEffect>();
        if (typewriter != null)
        {
            typewriter.ShowVideoCompletionText();
        }

        PlayAudioOnStart audioManager = FindObjectOfType<PlayAudioOnStart>();
        if (audioManager != null)
        {
            audioManager.PlayThirdAudio();
        }
    }

    void PlayVideo()
    {
        videoPlayer.Play();
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
        playBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }
}
