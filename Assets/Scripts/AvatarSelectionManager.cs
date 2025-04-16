using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarSelectionManager : MonoBehaviour
{
    public Button[] monkeyButtons; // Array of buttons for each monkey
    public TMP_Text[] descriptionTexts; // Array of TextMeshPro components for each description

    void Start()
    {
        // Add listeners to each button
        for (int i = 0; i < monkeyButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            monkeyButtons[i].onClick.AddListener(() => OnMonkeyButtonClicked(index));
        }

        // Hide all description texts initially
        foreach (TMP_Text descText in descriptionTexts)
        {
            descText.gameObject.SetActive(false);
        }
    }

    void OnMonkeyButtonClicked(int index)
    {
        // Hide all description texts
        foreach (TMP_Text descText in descriptionTexts)
        {
            descText.gameObject.SetActive(false);
        }

        // Show the relevant description text
        descriptionTexts[index].gameObject.SetActive(true);
    }
}
