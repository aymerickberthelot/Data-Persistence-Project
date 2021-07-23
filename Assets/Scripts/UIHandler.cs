using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public abstract class UIHandler : MonoBehaviour
{
    
    public Text bestScoreInfoText;
    public ArrayList data_InList;
  
    public string userName;
    public int currentScore;

    public int personalBestScore;
    public int highestScore = 0;



    public virtual void GetAllInfo()
    {
        data_InList = SaveDataHandler.Instance.LoadUserInfo();
        userName = (string)data_InList[0];
        currentScore = (int)data_InList[1];
        personalBestScore = (int)data_InList[2];
        highestScore = (int)data_InList[3];

    }


    public void DisplayBestScoreInfo(Text t, int score)
    {

        t.text = "Best score : " + score + " Name : " + userName;

    }
}
