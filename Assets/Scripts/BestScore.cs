using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScore : MonoBehaviour
{
    public static BestScore Instance;

    private const string scoreIntro = "Best score : ";
    private const string fileName = "BestScore.json";
    private string fileLocation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        fileLocation = Application.persistentDataPath + fileName;
    }

    [System.Serializable]
    class Score
    {
        public string playerName;
        public int score;
    }

    public string GetBestScore()
    {
        if (File.Exists(fileLocation))
        {
            string json = File.ReadAllText(fileLocation);
            Score bestScore = JsonUtility.FromJson<Score>(json);
            return scoreIntro + bestScore.playerName + " - " + bestScore.score;
        }
        else
            return scoreIntro + "____ - 0";
    }

    public void submitScore(string playerName, int score)
    {
        if (isBestScore(score) || !File.Exists(fileLocation))
        {
            Score newScore = new Score();
            newScore.playerName = playerName;
            newScore.score = score;

            string json = JsonUtility.ToJson(newScore);
            File.WriteAllText(fileLocation, json);
        }
    }
    private bool isBestScore(int score)
    {
        if (File.Exists(fileLocation))
        {
            string json = File.ReadAllText(fileLocation);
            Score bestScore = JsonUtility.FromJson<Score>(json);
            return score > bestScore.score;
        }
        else
            return false;
    }
}
