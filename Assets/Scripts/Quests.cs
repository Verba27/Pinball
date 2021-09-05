using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyQuest
{
    NoQuest,
    TopTopTarget,
    TopLeftTarget,
    TopRightTarget,
    WallTarget,
    LeftGate,
    MiddleGate,
    RightGate,
    Bell
}

public class Quests : MonoBehaviour
{
    [SerializeField]
    private bool topTopTargetOnHit, topLeftTargetOnHit, topRightTargetOnHit, wallTargetOnHit;
    private bool gateLeftOnPass, gateMiddleOnPass, gateRightOnPass;
    [SerializeField]
    private bool bellOnhit;
    [SerializeField]
    private bool targetQuest, gateQuest;


    public void QuestCompliter(MyQuest Quest)
    {
        switch (Quest)
        {
            case MyQuest.NoQuest:
                break;
            case MyQuest.TopTopTarget:
                topTopTargetOnHit = true;
                break;
            case MyQuest.TopLeftTarget:
                topLeftTargetOnHit = true;
                break;
            case MyQuest.TopRightTarget:
                topRightTargetOnHit = true;
                break;
            case MyQuest.WallTarget:
                wallTargetOnHit = true;
                break;
            case MyQuest.LeftGate:
                StartCoroutine(LeftGateTimer());
                break;
            case MyQuest.MiddleGate:
                StartCoroutine(MiddleGateTimer());
                break;
            case MyQuest.RightGate:
                StartCoroutine(RightGateTimer());
                break;
            case MyQuest.Bell:
                StartCoroutine(BellTimer());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(Quest), Quest, null);
        }
    }
    void Update()
    {
        if (topLeftTargetOnHit && topRightTargetOnHit && topTopTargetOnHit && wallTargetOnHit == true)
        {
            targetQuest = true;
            hitAllTargets?.Invoke(true);
            topTopTargetOnHit = false;
            topLeftTargetOnHit = false;
            topRightTargetOnHit = false;
            wallTargetOnHit = false;
        }
        if (gateLeftOnPass & gateMiddleOnPass & gateRightOnPass == true)
        {
            gateQuest = true;
            passAllGates?.Invoke(true);
            gateLeftOnPass = false;
            gateMiddleOnPass = false;
            gateRightOnPass = false;
        }
        if (targetQuest & gateQuest & bellOnhit == true)
        {
            onMainQuest?.Invoke(true);
            targetQuest = false;
            gateQuest = false;
            bellOnhit = false;
        }
    }
    public delegate void QuestTargets(bool hitAllTargets);
    public event QuestTargets hitAllTargets;
    public delegate void QuestGates(bool passAllGates);
    public event QuestGates passAllGates;
    public delegate void MainQuest(bool onMainQuest);
    public event MainQuest onMainQuest;

    IEnumerator LeftGateTimer()
    {
        gateLeftOnPass = true;
        yield return new WaitForSecondsRealtime(10);
        gateLeftOnPass = false;
    }
    IEnumerator MiddleGateTimer()
    {
        gateMiddleOnPass = true;
        yield return new WaitForSecondsRealtime(10);
        gateMiddleOnPass = false;
    }
    IEnumerator RightGateTimer()
    {
        gateRightOnPass = true;
        yield return new WaitForSecondsRealtime(10);
        gateRightOnPass = false;
    }
    IEnumerator BellTimer()
    {
        bellOnhit = true;
        yield return new WaitForSecondsRealtime(20);
        bellOnhit = false;
    }
    //// BELL ON HIT

    //public void BellFinisherQuest()
    //{
    //    StartCoroutine(BellTimer());
    //}


    ////TARGETS QUEST!!!!!!!!!!!!!!!!!!!!!

    //public void TopTopTargetOnHit()
    //{
    //    topTopTargetOnHit = true;
    //}
    //public void TopLeftTargetOnHit()
    //{
    //    topLeftTargetOnHit = true;
    //}
    //public void TopRightTargetOnHit()
    //{
    //    topRightTargetOnHit = true;
    //}
    //public void WallTargetOnHit()
    //{
    //    wallTargetOnHit = true;
    //}

    ////GATES QUEST!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    //public void GateLeftOnPass()
    //{
    //    StartCoroutine(LeftGateTimer());
    //}
    //public void GateMiddleOnPass()
    //{
    //    StartCoroutine(MiddleGateTimer());
    //}
    //public void GateRightOnPass()
    //{
    //    StartCoroutine(RightGateTimer());
    //}


}
