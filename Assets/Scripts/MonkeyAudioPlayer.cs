using UnityEngine;
using UnityEngine.UI;

public class MonkeyAudioPlayer : MonoBehaviour
{
    public AudioSource monkeyAudioSource; // Assign an AudioSource in the Inspector
    public AudioClip monkeySound; // Assign monkey sound in Inspector
    public Button monkeyButton; // Assign the button in Inspector

    void Start()
    {
        if (monkeyButton != null)
        {
            monkeyButton.onClick.AddListener(PlayMonkeySound);
        }
    }

    public void PlayMonkeySound()
    {
        if (monkeyAudioSource != null && monkeySound != null)
        {
            monkeyAudioSource.PlayOneShot(monkeySound); // Allows spamming sound
        }
    }
}
