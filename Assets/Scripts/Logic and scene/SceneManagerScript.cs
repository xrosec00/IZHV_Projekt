using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManagerScript : MonoBehaviour
{

    public UIDocument mMainMenu;

    public UIDocument mMainScene;

    public LogicManager mLogic;
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

    public void RestartGame()
    {
        
    }

    public void RestartCurrentLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        mMainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
        mMainScene.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 0;
        mLogic.SetPause(true);
    }

    public void UnpauseGame()
    {
        mMainMenu.rootVisualElement.style.display = DisplayStyle.None;
        mMainScene.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 1;
        mLogic.SetPause(false);
    }

    /**
     * Quitting game
     * Shamelessly copied from IZHV_E6
     */
    public void QuitGame()
    {
        #if UNITY_EDITOR
                // Quitting in Unity Editor: 
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER || UNITY_WEBGL
                // Quitting in the WebGL build: 
                Application.OpenURL(Application.absoluteURL);
        #else // !UNITY_WEBPLAYER
                // Quitting in all other builds: 
                Application.Quit();
        #endif
    }
}
