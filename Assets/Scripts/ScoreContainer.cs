using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreContainer : SingletonMonoBehaviour<ScoreContainer>
{
    [SerializeField] private BallDataScriptableObject ballData;
    [SerializeField] private int totalScore = 0;

    private void Awake()
    {
        base.Awake();
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void AddScore(int size)
    {
        totalScore += ballData.ballDatas[size].score;
    }
}
