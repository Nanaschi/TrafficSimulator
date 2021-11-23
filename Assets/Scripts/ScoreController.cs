using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    Text text;
    int scoreNumber;
    [SerializeField] int scoreToWin;
    private void Awake()
    {
        text = GetComponent<Text>();

    }



    private void OnEnable()
    {
        GameEvents.current.onChangingScore += AddingTheScore;
    }

    public void AddingTheScore()
    {
        scoreNumber += 1;
        text.text = scoreNumber.ToString();
        if (scoreNumber == scoreToWin) { SceneManager.LoadScene("Win"); }
    }

    private void OnDisable()
    {
        GameEvents.current.onChangingScore -= AddingTheScore;
    }
}
