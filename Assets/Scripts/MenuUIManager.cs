using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Button startButton;

    private void Start()
    {
        bestScoreText.text = BestScore.Instance.GetBestScore();
    }

    private void Update()
    {
        startButton.interactable = PlayerInfo.Instance.GetPlayerName() != "";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
