using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainSceneScript : MonoBehaviour
{
    public PlayerLogic player;
    public SceneManagerScript scnMgr;
    private Label health_label;
    private Label score_label;
    private Button pause_button;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        health_label = root.Q<Label>("health_label");
        score_label = root.Q<Label>("score_label");
        pause_button = root.Q<Button>("pause_button");

        pause_button.clicked += (() => scnMgr.PauseGame());
    }

    private void FixedUpdate()
    {
        health_label.text = "Health: " + player.GetHealth().ToString();
        score_label.text = "Score: " + player.GetScore().ToString();
    }
}
