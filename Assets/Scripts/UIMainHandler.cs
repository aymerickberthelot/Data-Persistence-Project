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
        
        DisplayBestScoreInfo(bestScoreInfoText, SaveDataHandler.Instance.instanceSaveData.personalBestScore);
    }


    
}
