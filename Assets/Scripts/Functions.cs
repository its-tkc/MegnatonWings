using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.O))
        {
            Application.Quit();
            Debug.Log("Exited");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(@"Scenes/MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(@"Scenes/Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(@"Scenes/Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(@"Scenes/Level3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(@"Scenes/Level4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(@"Scenes/Level5");
    }

    public void EndCutScene()
    {
        SceneManager.LoadScene(@"Scenes/EndScene");
    }
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(@"Scenes/Intro");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(@"Scenes/Credits");
    }

}
