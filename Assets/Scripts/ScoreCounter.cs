using System;
using UnityEngine;

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
    public int scoreThisSession = 0;
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
                scoreThisSession += Convert.ToInt32(scoreSideTapes * scoreNormalizer);
                break;
            case ScoreValue.Gears:
                scoreThisSession += Convert.ToInt32(scoreCulinders * scoreNormalizer);
                break;
            case ScoreValue.Gates:
                scoreThisSession += Convert.ToInt32(scoreGates * scoreNormalizer);
                break;
            case ScoreValue.Targets:
                scoreThisSession += Convert.ToInt32(scoreTarget * scoreNormalizer);
                break;
            case ScoreValue.MainBumpers:
                scoreThisSession += Convert.ToInt32(scoreMainBumpers * scoreNormalizer);
                break;
            case ScoreValue.Sparks:
                scoreThisSession += Convert.ToInt32(scoreSparks * scoreNormalizer);
                break;
            case ScoreValue.Bell:
                scoreThisSession += Convert.ToInt32(scoreBell * scoreNormalizer);
                break;
            case ScoreValue.QuestTargets:
                scoreThisSession += Convert.ToInt32(targetsQuestScore * scoreNormalizer);
                break;
            case ScoreValue.QuestGates:
                scoreThisSession += Convert.ToInt32(gatesQuestScore * scoreNormalizer);
                break;
            case ScoreValue.MainQuest:
                scoreThisSession += Convert.ToInt32(mainQuestScore * scoreNormalizer);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(score), score, null);
        }
        if (scoreThisSession > firstBonusTreshold)
        {
            scoreNormalizer = 1.2f;
        }

        if (scoreThisSession > secondBonusTreshold)
        {
            scoreNormalizer = 1.5f;
        }
        if (scoreThisSession > thirdBonusTreshold)
        {
            scoreNormalizer = 2f;
        }
        onScore?.Invoke(scoreThisSession);
    }

    public void DeleteScore()
    {
        scoreThisSession = 0;
    }
    public delegate void Scored(int scoreThisSession);
    public event Scored onScore;
}
