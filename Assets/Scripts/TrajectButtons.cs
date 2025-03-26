using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrajectButtons : MonoBehaviour
{
    // Verander de naam van de scènes naar de juiste namen in je project.
    public string voorTrajectScene = "VoorTrajectMap"; // Vul hier de naam van je VoorTraject scène in.
    public string behandelTrajectScene = "BehandelTrajectScene"; // Vul hier de naam van je BehandelTraject scène in.
    public string naTrajectScene = "NaTrajectScene"; // Vul hier de naam van je NaTraject scène in.

    private Button button;

    // Start wordt eenmaal uitgevoerd wanneer het script begint
    void Start()
    {
        // Verkrijg de Button component van het object waaraan het script is gekoppeld
        button = GetComponent<Button>();

        // Voeg een listener toe die de scene laadt wanneer de knop wordt geklikt
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    // Functie voor de knopactie
    void OnButtonClick()
    {
        // Kijk welke knop er geklikt wordt en laad de bijbehorende scene
        if (gameObject.name == "VoorTrajectKeuze")
        {
            SceneManager.LoadScene(voorTrajectScene);
        }
        else if (gameObject.name == "BehandelTrajectKeuze")
        {
            SceneManager.LoadScene(behandelTrajectScene);
        }
        else if (gameObject.name == "NaTrajectKeuze")
        {
            SceneManager.LoadScene(naTrajectScene);
        }
    }
}
