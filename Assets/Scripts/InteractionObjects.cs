using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyInteractions
{
    NoInteraction,
    TargetTopTop,
    TargetTopLeft,
    TargetTopRight,
    TargetWall,
    SwitchLeft,
    SwitchRight,
    Bell,
    AllTargetsBackOn
}

public class InteractionObjects : MonoBehaviour
{
    [SerializeField] private GameObject targetTopTop;
    [SerializeField] private GameObject targetTopLeft;
    [SerializeField] private GameObject targetTopRight;
    [SerializeField] private GameObject targetWall;
    [SerializeField] private GameObject switchLeft;
    [SerializeField] private GameObject switchRight;
    [SerializeField] private Animation bell;

    public void DoInteraction(MyInteractions obj)
    {
        switch (obj)
        {
            case MyInteractions.NoInteraction:
                break;
            case MyInteractions.TargetTopTop:
                targetTopTop.SetActive(false);
                break;
            case MyInteractions.TargetTopLeft:
                targetTopLeft.SetActive(false);
                break;
            case MyInteractions.TargetTopRight:
                targetTopRight.SetActive(false);
                break;
            case MyInteractions.TargetWall:
                targetWall.SetActive(false);
                break;
            case MyInteractions.SwitchLeft:
                switchLeft.SetActive(true);
                break;
            case MyInteractions.SwitchRight:
                switchRight.SetActive(true);
                break;
            case MyInteractions.Bell:
                bell.Play();
                break;
            case MyInteractions.AllTargetsBackOn:
                StartCoroutine(TargetsBackOn());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
        }
    }
    IEnumerator TargetsBackOn()
    {
        yield return new WaitForSecondsRealtime(10);
        targetTopTop.SetActive(true);
        targetTopLeft.SetActive(true);
        targetTopRight.SetActive(true);
        targetWall.SetActive(true);
    }
    //public void TargetTopTopDisable()
    //{
    //    targetTopTop.SetActive(false);
    //}
    //public void TargetTopLeftDisable()
    //{
    //    targetTopLeft.SetActive(false);
    //}
    //public void TargetTopRightDisable()
    //{
    //    targetTopRight.SetActive(false);
    //}
    //public void TargetWallDisable()
    //{
    //    targetWall.SetActive(false);
    //}
    //public void BellMove()
    //{
    //    bell.Play();
    //}

    //public void SwitchLeftActive()
    //{
    //    switchLeft.SetActive(true);
    //}
    //public void SwitchRightActive()
    //{
    //    switchRight.SetActive(true);
    //}
    //public void AllTargetsEnable()
    //{
    //    StartCoroutine(TargetsBackOn());
    //}

}
