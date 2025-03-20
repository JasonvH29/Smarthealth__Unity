using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button startButton;   // Start button in Scene1
    public Button backButton;    // Back button in Scene2 en Scene3
    public Button avontuurButton; // Avontuur 1 knop in Scene2

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Huidige Scene: " + currentScene); // Debug-log om te controleren waar we zijn

        if (currentScene == "Scene1" && startButton != null)
        {
            startButton.onClick.AddListener(() => LoadScene("Scene2"));
            Debug.Log("Startknop gekoppeld aan Scene2.");
        }
        else if (currentScene == "Scene2")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("Scene1"));
                Debug.Log("Terugknop gekoppeld aan Scene1.");
            }

            if (avontuurButton != null)
            {
                avontuurButton.onClick.AddListener(() => LoadScene("Scene3"));
                Debug.Log("Avontuur 1 knop gekoppeld aan Scene3.");
            }
        }
        else if (currentScene == "Scene3" && backButton != null)
        {
            backButton.onClick.AddListener(() => LoadScene("Scene2"));
            Debug.Log("Terugknop gekoppeld aan Scene2.");
        }
    }

    void LoadScene(string sceneName)
    {
        Debug.Log("Laden van scene: " + sceneName); // Extra debug-info
        SceneManager.LoadScene(sceneName);
    }
}
