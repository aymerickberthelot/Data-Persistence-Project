using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public class UIMenuHandler : UIHandler
{

    private string userName;
    InputField inputField;
   
    public void Start()
    {
        

        inputField = GameObject.Find("NameInput").GetComponent<InputField>();
        bestScoreInfoText = GameObject.Find("BestScoreInfoText").GetComponent<Text>();
        userName = SaveDataHandler.Instance.LoadName();

        

        GetAllInfo();
        DisplayBestScoreInfo(bestScoreInfoText, highestScore);
        DisplayUserNameOnInputField();
    }

    public void Update()
    {

    }

    public void StartGame()
    {
        if (SaveDataHandler.Instance.SaveName() != 0)
            SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

    public void DisplayUserNameOnInputField()
    {
        if (!string.IsNullOrEmpty(userName))
            inputField.text = userName;
    }


}
