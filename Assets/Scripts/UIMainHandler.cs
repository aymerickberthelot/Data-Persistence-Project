using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIMainHandler : UIHandler
{

    
    // Start is called before the first frame update
    void Start()
    {
        bestScoreInfoText = GameObject.Find("BestScoreText").GetComponent<Text>();
        GetAllInfo();
        
        DisplayBestScoreInfo(bestScoreInfoText, personalBestScore);
    }

    public override void GetAllInfo()
    {
        data_InList = SaveDataHandler.Instance.LoadUserInfo();
        userName = SaveDataHandler.Instance.LoadName();
        currentScore = (int)data_InList[1];
        personalBestScore = (int)data_InList[2];
        highestScore = (int)data_InList[3];

    }
 

    
}
