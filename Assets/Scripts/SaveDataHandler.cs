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

 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public string nameInput;
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

        if(string.IsNullOrEmpty(data.nameInput))
            return 0;
        

        string json = JsonUtility.ToJson(data);

        //Debug.Log(json);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        return 1;
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameInput = data.nameInput;
        }
    }


}
