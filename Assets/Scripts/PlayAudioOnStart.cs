using System.Collections;
using UnityEngine;

public class PlayAudioOnStart : MonoBehaviour
{
    [Header("Main Audio Sequence")]
    public AudioSource audioSource; // Assign an AudioSource in the Inspector
    public AudioClip audioClip1; // First audio clip (TTS1)
    public AudioClip audioClip2; // Second audio clip (TTS2)
    public AudioClip audioClip3; // Third audio clip (TTS3 - after video)

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        // Play first audio immediately on start
        audioSource.clip = audioClip1;
        audioSource.Play();

        // Wait for audio1 to finish
        yield return new WaitForSeconds(audioClip1.length);

        // Wait for an extra 3 seconds before playing the next audio
        yield return new WaitForSeconds(3f);

        // Play second audio
        audioSource.clip = audioClip2;
        audioSource.Play();
    }

    // Function to play the third audio after the video
    public void PlayThirdAudio()
    {
        if (audioClip3 != null)
        {
            audioSource.clip = audioClip3;
            audioSource.Play();
        }
    }
}
