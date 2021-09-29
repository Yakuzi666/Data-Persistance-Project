using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMain : MonoBehaviour
{
    public static UIMain Instance;
    public string playerName;
    public TMP_Text playerNameInput;
    public string scoreName;
    public int scorePoints;

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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GetPlayerName()
    {
        playerName = playerNameInput.text;
    }
    
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int PlayerScore;
    }

    public void SaveScore(int points)
    {
        SaveData score = new SaveData();
        score.PlayerName = Instance.playerName;
        score.PlayerScore = points;
        
        string json = JsonUtility.ToJson(score);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData score = JsonUtility.FromJson<SaveData>(json);
            scoreName = score.PlayerName;
            scorePoints = score.PlayerScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
