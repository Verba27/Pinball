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
    [SerializeField] private InteractionObjects interactionObjects;
    [SerializeField] private Quests quests;
    [SerializeField] private Launcher launcher;

    [SerializeField] private CollisionDetector[] bumperTapes;

    private int lives;
    void Start()
    {
        for (int i = 0; i < bumperTapes.Length; i++)
        {
            bumperTapes[i].onColl += BumpCollision;
        }
        scoreCounter.onScore += ScoreInfo;
        quests.hitAllTargets += AllTargetsQuestDone;
        quests.passAllGates += AllGatesPassQuestDone;
        quests.onMainQuest += MainQuestDone;
        forceManager.onDestroy += BallLost;


        lives = 3;

    }

    void Update()
    {
        if (lives == 3)
        {
            EndGame();
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        lives = 3;
        
    }

    public void EndGame()
    {
        //Time.timeScale = 0;
    }
    
    private void BallLost(bool ondestroy)
    {
        lives--;
    }

    private void ScoreInfo(int scoreCurrent)
    {
        Debug.Log(scoreCurrent);
    }
    
    private void BumpCollision(bool onContact, Collision collision, ForceType force, Vector3 direction,
        MyParticlesSystems particles, MyInteractions interactions, ScoreValue scoreValue, MyQuest quest, MySounds sound)
    {
        forceManager.DoForce(force, collision, direction);
        scoreCounter.ScoreAdding(scoreValue);
        quests.QuestCompliter(quest);
        particleManager.PlayParticles(particles);
        interactionObjects.DoInteraction(interactions);
        audioManager.PlaySound(sound);
        //sound
    }
    private void AllTargetsQuestDone(bool hitAllTargets)
    {
        interactionObjects.DoInteraction(MyInteractions.AllTargetsBackOn);
        scoreCounter.ScoreAdding(ScoreValue.QuestTargets);
        audioManager.PlaySound(MySounds.TargetQuestSound);
    }

    private void AllGatesPassQuestDone(bool passAllGates)
    {
        scoreCounter.ScoreAdding(ScoreValue.QuestGates);
        audioManager.PlaySound(MySounds.GateQuestSound);
    }

    private void MainQuestDone(bool onMainQuest)
    {
        scoreCounter.ScoreAdding(ScoreValue.MainQuest);
        launcher.MultiballAction();
        lives = lives+2;
        audioManager.PlaySound(MySounds.MainQuestSound);
    }



    //private void BumpCylinderCollision(bool onContact, Collision collision, ForceType force, Vector3 direction,
    //    MyParticlesSystems particles, MyInteractions interactions, ScoreValue scoreValue, MyQuest quest)
    //{
    //    forceManager.DoForce(force, collision, direction);
    //    scoreCounter.ScoreAdding(scoreValue);
    //    //sound
    //}
    //private void BlockingFieldCollision(bool onTrigger)
    //{
    //    //forceManager.BlockingFieldForce();
    //    particleManager.PlayParticles(MyParticlesSystems.BlockingSteamParticle);
    //    //sound
    //}
    //private void SideSaverLeft(Collision collision, Vector3 direction, MyParticlesSystems particles)
    //{
    //    forceManager.SideSaver(collision, direction);
    //    particleManager.PlayParticles(particles);
    //    //particleManager.FallSaverLeftParticleOn();
    //    //interactionObjects.SwitchLeftActive();
    //    interactionObjects.DoInteraction(MyInteractions.SwitchLeft);
    //    //sound
    //}
    //private void SideSaverRight(Collision collision, Vector3 direction, MyParticlesSystems particles)
    //{
    //    forceManager.SideSaver(collision, direction);
    //    particleManager.PlayParticles(particles);
    //    //particleManager.FallSaverRightParticleOn();
    //    interactionObjects.DoInteraction(MyInteractions.SwitchRight);
    //    //interactionObjects.SwitchRightActive();
    //    //sound
    //}
    //private void WallCollision(Collision collision, Vector3 direction, MyParticlesSystems particles)
    //{
    //    forceManager.DirectForce(collision, direction);
    //    particleManager.PlayParticles(particles);
    //    //particleManager.WallSteamOn();
    //    //sound
    //}
    //private void MainBumperCollision(Collision collision, Vector3 direction, MyParticlesSystems particles, ScoreValue scoreValue)
    //{
    //    forceManager.DirectForce(collision, direction);
    //    scoreCounter.ScoreAdding(scoreValue);
    //    //scoreCounter.GameScoreMainBumpers(true);
    //    //sound
    //}
    //private void PyramidCollision(Collision collision, Vector3 direction, MyParticlesSystems particles)
    //{
    //    forceManager.DirectForce(collision, direction);
    //    //sound
    //}
    //private void SparksCollision(Collision collision, Vector3 direction, MyParticlesSystems particles)
    //{
    //    forceManager.DirectForce(collision, direction);
    //    particleManager.PlayParticles(particles);
    //    //particleManager.SparkParticleOn();
    //    scoreCounter.GameScoreSparks(true);
    //    //sound
    //}
    //private void LeftGatePass(bool onTriggerEnter, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Gates);
    //    particleManager.PlayParticles(MyParticlesSystems.ThunderLeft);
    //    //particleManager.ThunderLeftOn();
    //    quests.GateLeftOnPass();

    //    //sound?
    //}
    //private void MiddleGatePass(bool onTriggerEnter, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Gates);
    //    particleManager.PlayParticles(MyParticlesSystems.ThunderMiddle);
    //    //particleManager.ThunderMiddleOn();
    //    quests.GateMiddleOnPass();

    //    //sound?
    //}
    //private void RightGatePass(bool onTriggerEnter, ScoreValue scoreValue)
    //{

    //    scoreCounter.ScoreAdding(ScoreValue.Gates);
    //    particleManager.PlayParticles(MyParticlesSystems.ThunderRight);
    //    //particleManager.ThunderRightOn();
    //    quests.GateRightOnPass();

    //    //sound?
    //}
    //private void TargetTopTopHit(bool onContact, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Targets);
    //    interactionObjects.DoInteraction(MyInteractions.TargetTopTop);
    //    //interactionObjects.TargetTopTopDisable();
    //    quests.TopTopTargetOnHit();
    //    //sound?
    //}

    //private void TargetTopLeftHit(bool onContact, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Targets);
    //    interactionObjects.DoInteraction(MyInteractions.TargetTopLeft);
    //    //interactionObjects.TargetTopLeftDisable();
    //    quests.TopLeftTargetOnHit();
    //    //sound?
    //}

    //private void TargetTopRightHit(bool onContact, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Targets);
    //    interactionObjects.DoInteraction(MyInteractions.TargetTopRight);
    //    //interactionObjects.TargetTopRightDisable();
    //    quests.TopRightTargetOnHit();
    //    //sound?
    //}

    //private void TargetWallHit(bool onContact, ScoreValue scoreValue)
    //{
    //    scoreCounter.ScoreAdding(ScoreValue.Targets);
    //    interactionObjects.DoInteraction(MyInteractions.TargetWall);
    //    //interactionObjects.TargetWallDisable();
    //    quests.WallTargetOnHit();
    //    //sound?
    //}
    //private void DingDong(bool onTriggerEnter, ScoreValue scoreValue)
    //{

    //    scoreCounter.ScoreAdding(ScoreValue.Bell);
    //    interactionObjects.DoInteraction(MyInteractions.Bell);
    //    //interactionObjects.BellMove();
    //    quests.BellFinisherQuest();

    //    //sound?
    //}

}
