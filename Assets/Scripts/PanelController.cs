using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Assign the panel in the Inspector
    public Button btn1; // Assign Btn1
    public Button backBtn; // Assign BackBtn for Scene2
    public Button videoBackBtn; // Assign BackBtn for Video Popup

    void Start()
    {
        // Ensure panel is hidden and correct back button is shown at the start
        panel.SetActive(false);
        videoBackBtn.gameObject.SetActive(false);

        // Add listeners to buttons
        btn1.onClick.AddListener(ShowPanel);
        videoBackBtn.onClick.AddListener(HidePanel);
    }

    void ShowPanel()
    {
        panel.SetActive(true);
        backBtn.gameObject.SetActive(false); // Hide Scene2 Back Button
        videoBackBtn.gameObject.SetActive(true); // Show Video Back Button
    }

    void HidePanel()
    {
        panel.SetActive(false);
        videoBackBtn.gameObject.SetActive(false); // Hide Video Back Button
        backBtn.gameObject.SetActive(true); // Show Scene2 Back Button
    }
}
//werkt het???
