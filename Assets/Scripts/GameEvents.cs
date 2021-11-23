using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }

    public delegate void ActionInt();
    public event ActionInt onChangingScore;


    public void ChangingTheScore()
    {
        if (onChangingScore != null)
        {
            onChangingScore();
        }
    }

}
