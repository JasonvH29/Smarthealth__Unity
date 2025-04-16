using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorMessage;
    public Button loginButton;
    public Button createAccountButton;
    public Button togglePasswordButton;
    public TMP_Text toggleButtonText;

    private bool isPasswordVisible = false;
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>();

    void Start()
    {
        loginButton.onClick.AddListener(HandleLogin);
        createAccountButton.onClick.AddListener(CreateAccount);
        togglePasswordButton.onClick.AddListener(TogglePassword);

        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
    }

    void CreateAccount()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text; // Corrected this line

        if (username == "" || password == "")
        {
            errorMessage.text = "Gebruikersnaam en wachtwoord mogen niet leeg zijn!";
            return;
        }

        if (userDatabase.ContainsKey(username))
        {
            errorMessage.text = "Deze gebruikersnaam is al in gebruik.";
            return;
        }

        userDatabase[username] = password;
        errorMessage.text = "Account succesvol aangemaakt!";
    }

    void HandleLogin()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (userDatabase.TryGetValue(username, out string storedPassword))
        {
            if (storedPassword == password)
            {
                errorMessage.text = "Login succesvol!";
                SceneManager.LoadScene("AvatarSelectieMenu"); // Change to your avatar selection scene name
            }
            else
            {
                errorMessage.text = "Verkeerde wachtwoord ingevoerd";
            }
        }
        else
        {
            errorMessage.text = "Gebruikersnaam niet gevonden.";
        }
    }

    void TogglePassword()
    {
        isPasswordVisible = !isPasswordVisible;
        passwordInput.contentType = isPasswordVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();

        if (toggleButtonText != null)
        {
            toggleButtonText.text = isPasswordVisible ? "Verberg" : "Toon";
        }
    }
}
