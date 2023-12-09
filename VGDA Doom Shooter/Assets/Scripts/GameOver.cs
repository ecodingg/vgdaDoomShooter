using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public UIDocument uiDocument;

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        Button buttonRetry = root.Q<Button>("Retry");
        Button buttonQuit = root.Q<Button>("Quit");

        buttonRetry.clicked += RetryButton;
        buttonQuit.clicked += QuitButton;

    }

    private void RetryButton()
    {   //restarts level
        Debug.Log("restarting level");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    private void QuitButton()
    {   //goes to main menu
        SceneManager.LoadScene("UITest", LoadSceneMode.Single);
    }

}
