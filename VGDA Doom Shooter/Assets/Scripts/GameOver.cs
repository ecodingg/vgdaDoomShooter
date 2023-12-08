using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public UIDocument uiDocument;
    public PlayerHealth playerHealth;

    void Start()
    {
        SetGameOverUIVisibility(false);
    }

    private void OnEnable()
    {
        int currentHealth = playerHealth.GetCurrentHealth();

        VisualElement root = uiDocument.rootVisualElement;

        Button buttonRetry = root.Q<Button>("Retry");
        Button buttonQuit = root.Q<Button>("Quit");

        buttonRetry.clicked += RetryButton;
        buttonQuit.clicked += QuitButton;

        if (currentHealth >= 0)
        {
            root.visible = true;
        }
        else {
            root.visible = false;
        }

    }

    void Update()
    {

    }

    private void RetryButton()
    { //restarts level
        Debug.Log("restarting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitButton()
    { //quits application
        Application.Quit();
    }

    private void SetGameOverUIVisibility(bool isVisible)
    {
        // Set the visibility of the game over UI elements
        VisualElement root = uiDocument.rootVisualElement;
        if (isVisible == false)
        {
            root.visible = false;
        }
        else {
            root.visible = true;
        }
    }
}
