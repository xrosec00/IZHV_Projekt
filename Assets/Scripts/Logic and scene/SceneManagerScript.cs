using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManagerScript : MonoBehaviour
{

    public UIDocument mMainMenu;

    public UIDocument mMainScene;
    // Start is called before the first frame update
    void Start()
    {
        mMainMenu.rootVisualElement.style.display = DisplayStyle.None;
        mMainScene.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        
    }

    public void RestartGame()
    {
        
    }

    public void RestartCurrentLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        mMainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
        mMainScene.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void UnpauseGame()
    {
        mMainMenu.rootVisualElement.style.display = DisplayStyle.None;
        mMainScene.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
