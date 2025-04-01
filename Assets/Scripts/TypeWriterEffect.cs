using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    [Header("Text Components")]
    public TextMeshProUGUI textComponent1; // First text
    public TextMeshProUGUI textComponent2; // Second text
    public TextMeshProUGUI textComponent3; // Third text (after video)
    public float typingSpeed = 0.05f; // Adjustable speed for typewriter effect

    [Header("Monkey Animation")]
    public Transform monkeyTransform;
    public float bounceHeight = 5f;
    public float bounceSpeed = 5f;

    [Header("Speech Bubble and Buttons")]
    public GameObject speechBubble; // Reference to the speech bubble object
    public Button closeButton; // Reference to the close button
    public Button clickHereButton; // Reference to the "click here" button
    public Button playBtn;  // Play button reference
    public Button pauseBtn; // Pause button reference
    public float buttonBounceHeight = 10f; // Button bounce height
    public float buttonBounceSpeed = 3f; // Button bounce speed

    private bool isAnimating = false;
    private bool hasClosedBeforeVideo = false; // Track if the bubble was closed before the video
    private Coroutine activeTypingCoroutine = null; // Store active typewriter coroutine

    private string textComponent3FullText; // Store the full text for textComponent3

    void Start()
    {
        playBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);

        speechBubble.SetActive(false);
        closeButton.gameObject.SetActive(false);
        clickHereButton.gameObject.SetActive(true);

        textComponent1.gameObject.SetActive(false);
        textComponent2.gameObject.SetActive(false);
        textComponent3.gameObject.SetActive(false);

        // Store the full text for textComponent3
        textComponent3FullText = textComponent3.text;

        StartCoroutine(AnimateButton());
        StartCoroutine(PlayTextSequence());
    }

    IEnumerator PlayTextSequence()
    {
        speechBubble.SetActive(true);

        textComponent1.gameObject.SetActive(true);
        activeTypingCoroutine = StartCoroutine(TypeText(textComponent1));
        yield return activeTypingCoroutine;
        yield return new WaitForSeconds(3f);
        textComponent1.gameObject.SetActive(false); // Hide textComponent1

        textComponent2.gameObject.SetActive(true);
        activeTypingCoroutine = StartCoroutine(TypeText(textComponent2));
        yield return activeTypingCoroutine;
        yield return new WaitForSeconds(3f);

        closeButton.gameObject.SetActive(true);
    }

    IEnumerator TypeText(TextMeshProUGUI textComponent)
    {
        isAnimating = true;
        StartCoroutine(AnimateMonkey());

        string fullText = textComponent.text;
        textComponent.text = ""; // Clear the text at the start of the coroutine

        foreach (char letter in fullText)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isAnimating = false;
    }

    IEnumerator AnimateMonkey()
    {
        Vector3 originalPosition = monkeyTransform.position;

        while (isAnimating)
        {
            float newY = originalPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
            monkeyTransform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
            yield return null;
        }

        monkeyTransform.position = originalPosition;
    }

    public void CloseTextAndBubble()
    {
        if (activeTypingCoroutine != null)
        {
            StopCoroutine(activeTypingCoroutine);
            activeTypingCoroutine = null;
        }

        textComponent1.text = "";
        textComponent2.text = "";

        speechBubble.SetActive(false);
        closeButton.gameObject.SetActive(false);

        hasClosedBeforeVideo = true;
    }

    public void ShowVideoCompletionText()
    {
        if (activeTypingCoroutine != null)
        {
            StopCoroutine(activeTypingCoroutine);
            activeTypingCoroutine = null;
        }

        textComponent1.gameObject.SetActive(false); // Ensure textComponent1 is hidden
        textComponent2.gameObject.SetActive(false); // Ensure textComponent2 is hidden

        speechBubble.SetActive(true); // Ensure speech bubble appears
        textComponent3.gameObject.SetActive(true); // Ensure textComponent3 is visible

        // Set the full text for textComponent3
        textComponent3.text = textComponent3FullText;

        activeTypingCoroutine = StartCoroutine(TypeText(textComponent3));
        StartCoroutine(ShowCloseButtonAfterText3());
    }

    IEnumerator ShowCloseButtonAfterText3()
    {
        yield return new WaitForSeconds(textComponent3FullText.Length * typingSpeed);
        closeButton.gameObject.SetActive(true);
    }

    IEnumerator AnimateButton()
    {
        Vector3 originalPosition = clickHereButton.transform.position;

        while (true)
        {
            float newY = originalPosition.y + Mathf.Sin(Time.time * buttonBounceSpeed) * buttonBounceHeight;
            clickHereButton.transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
            yield return null;
        }
    }

    public void OnClickHereButton()
    {
        Debug.Log("Click here button pressed!");
    }

    public void OnPlayClick()
    {
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
    }

    public void OnPauseClick()
    {
        playBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }

    public void OnDoneButtonClick()
    {
        textComponent1.text = "";
        textComponent2.text = "";

        if (hasClosedBeforeVideo)
        {
            speechBubble.SetActive(true);
            ShowVideoCompletionText();
        }
    }
}