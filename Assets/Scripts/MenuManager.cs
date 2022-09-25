using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool startGame = false;
    private float timer = 0;
    private const float delay = 3;

    private void Update()
    {
        if(startGame)
        {
            timer += Time.deltaTime;
            if(timer > delay)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void StartGame(GameObject textBalloon)
    {
        textBalloon.SetActive(true);
        startGame = true;
    }

    public void HideObject(GameObject theObject)
    {
        theObject.SetActive(false);
    }

    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
