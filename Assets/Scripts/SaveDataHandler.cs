using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
public class SaveDataHandler : MonoBehaviour
{
    public static SaveDataHandler Instance;
    private InputField txt_Input;
    string userName;
    private bool changeBestScore = false;
    private bool changeHighestScore = false;

    public SaveData instanceSaveData;

    public string name_file = "name.json";
    public string data_file = "data.json";




    private void Awake()
    {

        SaveInstance();
        DontDestroyOnLoad(gameObject);

    }



    [System.Serializable]
    public class SaveData  //Data we want to save
    {
        public string userName;

        public int currentScore = 0;
        public int personalBestScore;

        public int highestScore;

        public bool CheckBestScore()
        {
            if (currentScore > personalBestScore)
            {
                personalBestScore = currentScore;
                return true;
            }

            else return false;
        }

        public bool CheckHighestScore()
        {
            if (personalBestScore > highestScore)
            {
                highestScore = personalBestScore;
                return true;
            }

            else return false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {

        txt_Input = GameObject.Find("NameInput").GetComponent<InputField>();

    }

    // Update is called once per frame
    void Update()
    {

        if (txt_Input != null)
        {
            userName = txt_Input.text;
        }
    }



    public int SaveName()
    {
        SaveData data = new SaveData();
        data.userName = userName;

        if (string.IsNullOrEmpty(data.userName))
            return 0;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + name_file, json);

        return 1;
    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/" + name_file;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
        }
        else return "";

        return userName;
    }

    public int SaveUserInfo(int currentScore)
    {
        SaveData data = Instance.instanceSaveData;
        data.userName = userName;
        data.currentScore = currentScore;

        changeBestScore = data.CheckBestScore();
        changeHighestScore = data.CheckHighestScore();

        if (string.IsNullOrEmpty(data.userName))
            return 0;


        if (changeBestScore || changeHighestScore)
        {
            string json = JsonUtility.ToJson(data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/" + data_file, json);
        }

        data.currentScore = 0;
        return 1;
    }

    public ArrayList LoadUserInfo()
    {
        ArrayList list = new ArrayList();
        string path = Application.persistentDataPath + "/" + data_file;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            list.Add(data.userName);
            list.Add(data.currentScore);
            list.Add(data.personalBestScore);
            list.Add(data.highestScore);
            return list;
        }


        return list;
    }


    public void SaveInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        this.instanceSaveData = new SaveData();
    }



}
