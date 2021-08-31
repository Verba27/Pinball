using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private ParticleSystemManager particleManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private ForceManager forceManager;

    [SerializeField] private CollisionDetector bumperTapeLeft;
    [SerializeField] private CollisionDetector bumperTapeRight;
    [SerializeField] private CollisionDetector cylinderTop;
    [SerializeField] private CollisionDetector cylinderLeft;
    [SerializeField] private CollisionDetector cylinderRight;
    [SerializeField] private CollisionDetector mainLeft;
    [SerializeField] private CollisionDetector mainRight;
    [SerializeField] private CollisionDetector sparks;
    [SerializeField] private CollisionDetector saverLeft;
    [SerializeField] private CollisionDetector saverRight;
    [SerializeField] private CollisionDetector blockingField;
    [SerializeField] private CollisionDetector wallSteam;
    [SerializeField] private CollisionDetector pyramindLeft;
    [SerializeField] private CollisionDetector pyramindRight;
    [SerializeField] private CollisionDetector gateLeft;
    [SerializeField] private CollisionDetector gateMiddle;
    [SerializeField] private CollisionDetector gateRight;
    [SerializeField] private CollisionDetector bell;

    void Start()
    {
        blockingField.onTriggerStay += BlockingFieldCollision;
        cylinderTop.onColl += BumpCylinderCollision;
        cylinderLeft.onColl += BumpCylinderCollision;
        cylinderRight.onColl += BumpCylinderCollision;
        sparks.onColl += SparksCollision;
        bumperTapeLeft.onColl += BumpTapeCollision;
        bumperTapeRight.onColl += BumpTapeCollision;
        mainLeft.onColl += MainBumperCollision;
        mainRight.onColl += MainBumperCollision;
        pyramindLeft.onColl += PyramidCollision;
        pyramindRight.onColl += PyramidCollision;
        wallSteam.onColl += WallCollision;
        saverLeft.onColl += SideSaverLeft;
        saverRight.onColl += SideSaverRight;
        gateLeft.onTriggerEnter += LeftGatePass;
        gateMiddle.onTriggerEnter += MiddleGatePass;
        gateRight.onTriggerEnter += RightGatePass;
        bell.onTriggerEnter += DingDong;
    }
    
    private void BlockingFieldCollision(bool onTrigger)
    {
        forceManager.BlockingFieldForce();
        particleManager.BlockingFieldOn();
        //sound
    }
    private void BumpTapeCollision(Collision collision, Vector3 direction)
    {
        forceManager.DirectForce(collision, direction);
        scoreCounter.GameScoreTape(true);
        particleManager.AngleSteamOn();
        //sound
    }
    private void BumpCylinderCollision(Collision collision, Vector3 direction)
    {
        forceManager.CylinderForce(collision);
        scoreCounter.GameScoreCylinder(true);
        //sound
    }
    private void SideSaverLeft(Collision collision, Vector3 direction)
    {
        forceManager.SideSaver(collision, direction);
        particleManager.FallSaverLeftParticleOn();
        //sound
    }
    private void SideSaverRight(Collision collision, Vector3 direction)
    {
        forceManager.SideSaver(collision, direction);
        particleManager.FallSaverRightParticleOn();
        //sound
    }
    private void WallCollision(Collision collision, Vector3 direction)
    {
        forceManager.DirectForce(collision, direction);
        particleManager.WallSteamOn();
        //sound
    }
    private void MainBumperCollision(Collision collision, Vector3 direction)
    {
        forceManager.DirectForce(collision, direction);
        scoreCounter.GameScoreMainBumpers(true);
        //sound
    }
    private void PyramidCollision(Collision collision, Vector3 direction)
    {
        forceManager.DirectForce(collision, direction);
        //sound
    }
    private void SparksCollision(Collision collision, Vector3 direction)
    {
        forceManager.DirectForce(collision, direction);
        particleManager.SparkParticleOn();
        scoreCounter.GameScoreMainBumpers(true);
        //sound
    }
    private void LeftGatePass(bool onTriggerEnter)
    {
        scoreCounter.GameScoreGates(true);
        particleManager.ThunderLeftOn();
        //quest
        //sound?
    }
    private void MiddleGatePass(bool onTriggerEnter)
    {
        scoreCounter.GameScoreGates(true);
        particleManager.ThunderMiddleOn();
        //quest
        //sound?
    }
    private void RightGatePass(bool onTriggerEnter)
    {
        scoreCounter.GameScoreGates(true);
        particleManager.ThunderRightOn();
        //quest
        //sound?
    }
    private void DingDong(bool onTriggerEnter)
    {
        scoreCounter.GameScoreBell(true);
        //Animation
        //quest
        //sound?
    }
}
