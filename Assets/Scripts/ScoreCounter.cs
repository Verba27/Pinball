using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum ScoreValue
{
    NoScore,
    Angles,
    Gears,
    Gates,
    Targets,
    MainBumpers,
    Sparks,
    Bell,
    QuestTargets,
    QuestGates,
    MainQuest
}

public class ScoreCounter : MonoBehaviour
{
    
    public int currentScore = 0;
    [SerializeField]
    private int scoreSideTapes = 20;
    [SerializeField]
    private int scoreCulinders = 10;
    [SerializeField]
    private int scoreGates = 40;
    [SerializeField]
    private int scoreTarget = 50;
    [SerializeField]
    private int scoreMainBumpers = 30;
    [SerializeField]
    private int scoreSparks = 50;
    [SerializeField]
    private int scoreBell = 100;
    [SerializeField]
    private int firstBonusTreshold = 1000;
    [SerializeField]
    private int secondBonusTreshold = 5000;
    [SerializeField]
    private int thirdBonusTreshold = 15000;
    [SerializeField]
    private int targetsQuestScore = 500;
    [SerializeField]
    private int gatesQuestScore = 1000;
    [SerializeField]
    private int mainQuestScore = 5000;

    [SerializeField] private float scoreNormalizer = 1;


    public void ScoreAdding(ScoreValue score)
    {
        switch (score)
        {
            case ScoreValue.NoScore:
                break;
            case ScoreValue.Angles:
                currentScore += Convert.ToInt32(scoreSideTapes * scoreNormalizer);
                break;
            case ScoreValue.Gears:
                currentScore += Convert.ToInt32(scoreCulinders * scoreNormalizer);
                break;
            case ScoreValue.Gates:
                currentScore += Convert.ToInt32(scoreGates * scoreNormalizer);
                break;
            case ScoreValue.Targets:
                currentScore += Convert.ToInt32(scoreTarget * scoreNormalizer);
                break;
            case ScoreValue.MainBumpers:
                currentScore += Convert.ToInt32(scoreMainBumpers * scoreNormalizer);
                break;
            case ScoreValue.Sparks:
                currentScore += Convert.ToInt32(scoreSparks * scoreNormalizer);
                break;
            case ScoreValue.Bell:
                currentScore += Convert.ToInt32(scoreBell * scoreNormalizer);
                break;
            case ScoreValue.QuestTargets:
                currentScore += Convert.ToInt32(targetsQuestScore * scoreNormalizer);
                break;
            case ScoreValue.QuestGates:
                currentScore += Convert.ToInt32(gatesQuestScore * scoreNormalizer);
                break;
            case ScoreValue.MainQuest:
                currentScore += Convert.ToInt32(mainQuestScore * scoreNormalizer);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(score), score, null);
        }
        onScore?.Invoke(currentScore);
    }

    public delegate void Scored(int currentScore);
    public event Scored onScore;


    void Update()
    {
        if (currentScore > firstBonusTreshold)
        {
            scoreNormalizer = 1.2f;
        }

        if (currentScore > secondBonusTreshold)
        {
            scoreNormalizer = 1.5f;
        }
        if (currentScore > thirdBonusTreshold)
        {
            scoreNormalizer = 2f;
        }
    }
    

    //public void GameScoreTape(bool onScore)
    //{
    //    currentScore += Convert.ToInt32(scoreSideTapes * scoreNormalizer) ;
    //    this.onScore?.Invoke(currentScore);
    //}
    //public void GameScoreCylinder(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreCulinders * scoreNormalizer);
    //    onScore?.Invoke(currentScore);

    //}
    //public void GameScoreMainBumpers(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreMainBumpers * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    //public void GameScoreGates(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreGates * scoreNormalizer);
    //    onScore?.Invoke(currentScore);

    //}
    //public void GameScoreSparks(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreSparks * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    //public void GameScoreTarget(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreTarget * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    //public void GameScoreBell(bool score)
    //{
    //    currentScore += Convert.ToInt32(scoreBell * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}

    //public void TargetQuest(bool score)
    //{
    //    currentScore += Convert.ToInt32(targetsQuestScore * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    //public void GateQuest(bool score)
    //{
    //    currentScore += Convert.ToInt32(gatesQuestScore * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    //public void MainQuest(bool score)
    //{
    //    currentScore += Convert.ToInt32(mainQuestScore * scoreNormalizer);
    //    onScore?.Invoke(currentScore);
    //}
    
}
