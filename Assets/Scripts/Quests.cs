using System;
using System.Collections;
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
    Bell,
    RefresQuests
}

public class Quests : MonoBehaviour
{
    private bool topTopTargetOnHit;
    private bool topLeftTargetOnHit;
    private bool topRightTargetOnHit;
    private bool wallTargetOnHit;
    private bool gateLeftOnPass;
    private bool gateMiddleOnPass;
    private bool gateRightOnPass;
    private bool bellOnhit;
    private bool targetQuest;
    private bool gateQuest;
    
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
            case MyQuest.RefresQuests:
                topTopTargetOnHit = false;
                topLeftTargetOnHit = false;
                topRightTargetOnHit = false;
                wallTargetOnHit = false;
                targetQuest = false;
                gateQuest = false;
                bellOnhit = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(Quest), Quest, null);
        }
    }
    public void Update()
    {
        if (topLeftTargetOnHit && topRightTargetOnHit && topTopTargetOnHit && wallTargetOnHit)
        {
            targetQuest = true;
            hitAllTargets?.Invoke(true);
            topTopTargetOnHit = false;
            topLeftTargetOnHit = false;
            topRightTargetOnHit = false;
            wallTargetOnHit = false;
        }
        if (gateLeftOnPass & gateMiddleOnPass & gateRightOnPass)
        {
            gateQuest = true;
            passAllGates?.Invoke(true);
            gateLeftOnPass = false;
            gateMiddleOnPass = false;
            gateRightOnPass = false;
        }
        if (targetQuest & gateQuest & bellOnhit)
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

    
    public IEnumerator LeftGateTimer()
    {
        gateLeftOnPass = true;
        yield return new WaitForSeconds(10);
        gateLeftOnPass = false;
    }
    public IEnumerator MiddleGateTimer()
    {
        gateMiddleOnPass = true;
        yield return new WaitForSeconds(10);
        gateMiddleOnPass = false;
    }
    public IEnumerator RightGateTimer()
    {
        gateRightOnPass = true;
        yield return new WaitForSeconds(10);
        gateRightOnPass = false;
    }
    public IEnumerator BellTimer()
    {
        bellOnhit = true;
        yield return new WaitForSeconds(20);
        bellOnhit = false;
    }
    
}
