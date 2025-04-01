using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button startButton;
    public Button backButton;
    public Button avontuurButton;
    public Button VoorTrajectKeuze;
    public Button BehandelTrajectKeuze;
    public Button NaTrajectKeuze;
    public Button loginButton;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Huidige Scene: " + currentScene);

        if (currentScene == "StartMenu" && startButton != null)
        {
            startButton.onClick.AddListener(() => LoadScene("TrajectMenu"));
            Debug.Log("Startknop gekoppeld aan TrajectMenu.");
        }

        if (currentScene == "StartMenu" && loginButton != null)
        {
            loginButton.onClick.AddListener(() => LoadScene("InlogMenu"));
            Debug.Log("Login knop gekoppeld aan StartMenu.");
        }

        else if (currentScene == "TrajectMenu")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("StartMenu"));
                Debug.Log("Terugknop gekoppeld aan StartMenu.");
            }

            if (VoorTrajectKeuze != null)
            {
                VoorTrajectKeuze.onClick.AddListener(() => LoadScene("VoorTrajectMap"));
                Debug.Log("VoorTrajectKeuze knop gekoppeld aan VoorTrajectKeuze.");
            }

            if (BehandelTrajectKeuze != null)
            {
                BehandelTrajectKeuze.onClick.AddListener(() => LoadScene("BehandelTrajectMap"));
                Debug.Log("BehandelTrajectKeuze knop gekoppeld aan BehandelTrajectScene.");
            }

            if (NaTrajectKeuze != null)
            {
                NaTrajectKeuze.onClick.AddListener(() => LoadScene("NaTrajectMap"));
                Debug.Log("NaTrajectKeuze knop gekoppeld aan NaTrajectScene.");
            }
        }
        else if (currentScene == "VoorTrajectMap")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("TrajectMenu"));
                Debug.Log("Terugknop gekoppeld aan TrajectMenu.");
            }

            if (avontuurButton != null)
            {
                avontuurButton.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur1"));
                Debug.Log("Avontuur 1 knop gekoppeld aan VoorTrajectAvontuur1.");
            }
        }
        else if (currentScene == "VoorTrajectAvontuur1" && backButton != null)
        {
            backButton.onClick.AddListener(() => LoadScene("VoorTrajectMap"));
            Debug.Log("Terugknop gekoppeld aan VoorTrajectMap.");
        }

        else if (currentScene == "BehandelTrajectMap")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("TrajectMenu"));
                Debug.Log("Terugknop gekoppeld aan TrajectMenu.");
            }
        }

        else if (currentScene == "NaTrajectMap")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("TrajectMenu"));
                Debug.Log("Terugknop gekoppeld aan TrajectMenu.");
            }
        }

        void LoadScene(string sceneName)
        {
            Debug.Log("Laden van scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
