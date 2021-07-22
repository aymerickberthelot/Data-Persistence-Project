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
    string nameInput;
    private bool changeBestScore = false;
    private bool changeHighestScore = false;

    public SaveData instanceSaveData;




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        this.instanceSaveData = new SaveData();

        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    public class SaveData
    {
        public string nameInput;

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
            nameInput = txt_Input.text;
        }
    }



    public int SaveName()
    {
        SaveData data = new SaveData();
        data.nameInput = nameInput;

        if (string.IsNullOrEmpty(data.nameInput))
            return 0;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        return 1;
    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameInput = data.nameInput;
        }
        else return "";

        return nameInput;
    }

    public int SaveUserInfo(int currentScore)
    {
        SaveData data = Instance.instanceSaveData;
        data.nameInput = nameInput;
        data.currentScore = currentScore;

        changeBestScore = data.CheckBestScore();
        changeHighestScore = data.CheckHighestScore();

        if (string.IsNullOrEmpty(data.nameInput))
            return 0;


        if (changeBestScore || changeHighestScore)
        {
            string json = JsonUtility.ToJson(data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        data.currentScore = 0;
        return 1;
    }

    public ArrayList LoadUserInfo()
    {
        ArrayList list = new ArrayList();
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            list.Add(data.nameInput);
            list.Add(data.currentScore);
            list.Add(data.personalBestScore);
            list.Add(data.highestScore);
            return list;
        }


        return list;
    }



}
