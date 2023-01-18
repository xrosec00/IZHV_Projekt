using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIScript : MonoBehaviour
{
    public SceneManagerScript scnMgr;
    private Button ResumeButton;
    private Button RestartButton;
    private Button QuitButton;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        ResumeButton = root.Q<Button>("ResumeButton");
        RestartButton = root.Q<Button>("RestartButton");
        QuitButton = root.Q<Button>("QuitButton");

        ResumeButton.clicked += () => scnMgr.UnpauseGame();
        RestartButton.clicked += () => scnMgr.RestartCurrentLevel();
        QuitButton.clicked += () => scnMgr.QuitGame();
    }
}

