using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button startButton;
    public Button backButton;
    public Button NextButton;
    public Button VTavontuurButton1;
    public Button VTavontuurButton2;
    public Button VTavontuurButton3;
    public Button BTavontuurButton1;
    public Button BTavontuurButton2;
    public Button BTavontuurButton3;
    public Button NTavontuurButton1;
    public Button NTavontuurButton2;
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

        else if(currentScene == "InlogMenu")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("StartMenu"));
                Debug.Log("Terugknop gekoppeld aan StartMenu.");
            }
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

            if (VTavontuurButton1 != null)
            {
                VTavontuurButton1.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur1"));
                Debug.Log("Avontuur 1 knop gekoppeld aan VoorTrajectAvontuur1.");
            }

            if (VTavontuurButton2 != null)
            {
                VTavontuurButton2.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur2"));
                Debug.Log("Avontuur 2 knop gekoppeld aan VoorTrajectAvontuur2.");
            }

            if (VTavontuurButton3 != null)
            {
                VTavontuurButton3.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur3"));
                Debug.Log("Avontuur 3 knop gekoppeld aan VoorTrajectAvontuur3.");
            }
        }
        else if (currentScene == "VoorTrajectAvontuur1")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("VoorTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan VoorTrajectMap.");
            }

            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur2"));
                Debug.Log("Volgende knop gekoppeld aan VoorTrajectAvontuur2.");
            }

        }

        else if (currentScene == "VoorTrajectAvontuur2")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur1"));
                Debug.Log("Terugknop gekoppeld aan VoorTrajectAvontuur1");
            }

            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur3"));
                Debug.Log("Volgende knop gekoppeld aan VoorTrajectAvontuur3.");
            }
        }

        else if (currentScene == "VoorTrajectAvontuur3")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("VoorTrajectAvontuur2"));
                Debug.Log("Terugknop gekoppeld aan VoorTrajectAvontuur1");
            }

            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("BehandelTrajectMap"));
                Debug.Log("Volgende knop gekoppeld aan BehandelTrajectMap");
            }
        }

        else if (currentScene == "BehandelTrajectMap")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("VoorTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan TrajectMenu.");
            }

            if (BTavontuurButton1 != null)
            {
                BTavontuurButton1.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur1"));
                Debug.Log("Avontuur 1 knop gekoppeld aan BehandelTrajectAvontuur1.");
            }

            if (BTavontuurButton2 != null)
            {
                BTavontuurButton2.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur2"));
                Debug.Log("Avontuur 2 knop gekoppeld aan BehandelTrajectAvontuur2.");
            }

            if (BTavontuurButton3 != null)
            {
                BTavontuurButton3.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur3"));
                Debug.Log("Avontuur 3 knop gekoppeld aan BehandelTrajectAvontuur3.");
            }
        }

        else if (currentScene == "BehandelTrajectAvontuur1")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("BehandelTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan BehandelTrajectMap.");
            }
            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur2"));
                Debug.Log("Volgende knop gekoppeld aan BehandelTrajectAvontuur2.");
            }
        }
        else if (currentScene == "BehandelTrajectAvontuur2")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur1"));
                Debug.Log("Terugknop gekoppeld aan BehandelTrajectAvontuur1.");
            }
            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur3"));
                Debug.Log("Volgende knop gekoppeld aan BehandelTrajectAvontuur3.");
            }
        }
        else if (currentScene == "BehandelTrajectAvontuur3")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("BehandelTrajectAvontuur2"));
                Debug.Log("Terugknop gekoppeld aan BehandelTrajectAvontuur2.");
            }
            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("NaTrajectMap"));
                Debug.Log("Volgende knop gekoppeld aan NaTrajectMap.");
            }
        }

        else if (currentScene == "NaTrajectMap")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("BehandelTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan BehandelTrajectMenu.");
            }

            if (NTavontuurButton1 != null)
            {
                NTavontuurButton1.onClick.AddListener(() => LoadScene("NaTrajectAvontuur1"));
                Debug.Log("Avontuur 1 knop gekoppeld aan NaTrajectAvontuur1.");
            }

            if (NTavontuurButton2 != null)
            {
                NTavontuurButton2.onClick.AddListener(() => LoadScene("NaTrajectAvontuur2"));
                Debug.Log("Avontuur 2 knop gekoppeld aan NaTrajectAvontuur2.");
            }
        }

        else if (currentScene == "NaTrajectAvontuur1")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("NaTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan NaTrajectMap.");
            }

            if (NextButton != null)
            {
                NextButton.onClick.AddListener(() => LoadScene("NaTrajectAvontuur2"));
                Debug.Log("Volgende knop gekoppeld aan NaTrajectAvontuur2.");
            }
        }

        else if (currentScene == "NaTrajectAvontuur2")
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(() => LoadScene("NaTrajectMap"));
                Debug.Log("Terugknop gekoppeld aan NaTrajectMap.");
            }
        }

            void LoadScene(string sceneName)
        {
            Debug.Log("Laden van scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
