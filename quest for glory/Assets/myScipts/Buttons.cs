using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("map");
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void About()
    {
        SceneManager.LoadScene("How to Play");
    }
    

    public void Exit()
    {
        Debug.Log("GG");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}