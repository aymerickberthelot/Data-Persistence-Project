using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public class UIMenuHandler : MonoBehaviour
{

    public void StartGame()
    {
        if(SaveDataHandler.Instance.SaveName() != 0)
           SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }


    



}
