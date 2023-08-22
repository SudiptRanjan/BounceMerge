using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class HighScoreData
{
    public int highScore;
}

public class HighScore : MonoBehaviour
{
    public static HighScore instance;
    public TextMeshProUGUI highScoreTextForGameOver;

    private int highScore = 0;
    private const string highScoreFilePath = "/highscore.json";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadHighScore();
        UpdateHighScoreText();
    }
    public void UpdateHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }

        UpdateHighScoreText();
    }


    private void SaveHighScore()
    {
        string path = Application.persistentDataPath + highScoreFilePath;
        HighScoreData data = new HighScoreData();
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + highScoreFilePath;

        //print(path);
        //Debug.Log(path + " Path of saved file");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            highScore = data.highScore;
        }
    }

    
    private void UpdateHighScoreText()
    {
        highScoreTextForGameOver.text = "High Score: " + highScore.ToString();
    }
}


