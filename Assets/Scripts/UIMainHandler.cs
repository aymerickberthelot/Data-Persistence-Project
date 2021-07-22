using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIMainHandler : MonoBehaviour
{

    private Text nameText;
    private string userName;
    class SaveData
    {
        public string nameInput;
  
    }
    // Start is called before the first frame update
    void Start()
    {
        nameText =  GameObject.Find("NameText").GetComponent<Text>();
         DisplayUserName();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayUserName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.nameInput;
            //Debug.Log(json);
            nameText.text = "Name : "+userName;


        }
    }
}
