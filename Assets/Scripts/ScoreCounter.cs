using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{

    //[SerializeField] private CollisionDetector bumperTapeLeft;
    //[SerializeField] private CollisionDetector bumperTapeRight;
    //[SerializeField] private CollisionDetector cylinderTop;
    //[SerializeField] private CollisionDetector cylinderLeft;
    //[SerializeField] private CollisionDetector cylinderRight;
    //[SerializeField] private CollisionDetector mainLeft;
    //[SerializeField] private CollisionDetector mainRight;
    //[SerializeField] private CollisionDetector gateLeft;
    //[SerializeField] private CollisionDetector gateCentral;
    //[SerializeField] private CollisionDetector gateRight;
    //[SerializeField] private CollisionDetector sparks;

    private float currentScore = 0;
    [SerializeField]
    private int scoreSideTapes = 20;
    [SerializeField]
    private int scoreCulinders = 10;
    [SerializeField]
    private int scoreGates = 40;
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

    [SerializeField] private float scoreNormalizer = 1;

    void Start()
    {
        //bumperTapeLeft.onContact += GameScoreTape;
        //bumperTapeRight.onContact += GameScoreTape;
        //cylinderTop.onContact += GameScoreCylinder;
        //cylinderLeft.onContact += GameScoreCylinder;
        //cylinderRight.onContact += GameScoreCylinder;
        //mainLeft.onContact += GameScoreMainBumpers;
        //mainRight.onContact += GameScoreMainBumpers;
        //gateLeft.onContact += GameScoreGates;
        //gateCentral.onContact += GameScoreTape;
        //gateRight.onContact += GameScoreGates;
        //sparks.onContact += GameScoreSparks;
        
    }

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
        //Debug.Log($"Score {currentScore}");
    }
    
    public delegate void Scored(float scoreCurrent);
    public event Scored onScore;

    public void GameScoreTape(bool onScore)
    {
        currentScore += scoreSideTapes * scoreNormalizer;
        this.onScore?.Invoke(currentScore);
        //Debug.Log($"Score = {scoreCurrent}");
    }
    public void GameScoreCylinder(bool score)
    {
        currentScore += scoreCulinders * scoreNormalizer;
        //Debug.Log($"Score = {scoreCurrent}");
        onScore?.Invoke(currentScore);

    }
    public void GameScoreMainBumpers(bool score)
    {
        currentScore += scoreMainBumpers * scoreNormalizer;
        //Debug.Log($"Score = {scoreCurrent}");
        onScore?.Invoke(currentScore);
    }
    public void GameScoreGates(bool score)
    {
        currentScore += scoreGates * scoreNormalizer;
        //Debug.Log($"Score = {scoreCurrent}");
        onScore?.Invoke(currentScore);

    }
    public void GameScoreSparks(bool score)
    {
        currentScore += scoreSparks * scoreNormalizer;
        //Debug.Log($"Score = {scoreCurrent}");
        onScore?.Invoke(currentScore);
    }
    public void GameScoreBell(bool score)
    {
        currentScore += scoreBell * scoreNormalizer;
        //Debug.Log($"Score = {scoreCurrent}");
        onScore?.Invoke(currentScore);
    }
}
