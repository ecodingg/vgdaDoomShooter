using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UIDocument uiDocument;

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        Button buttonStart = root.Q<Button>("Start");
        Button buttonQuit = root.Q<Button>("Quit");

        buttonStart.clicked += StartButton;
        buttonQuit.clicked += QuitButton;
    }

    private void StartButton() { //starts game
        Debug.Log("start game");
        SceneManager.LoadScene("mainScene");
    }

    private void QuitButton() { //quits application
        Application.Quit();
    }
}
