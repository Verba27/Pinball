using System;
using UnityEngine;

public enum MySounds
{
    NoSound,
    LauncherSound,
    GateSound,
    GearSound,
    SparkleSound,
    AngleSound,
    MainBumperSound,
    FlipperSound,
    BellSound,
    TargetSound,
    TargetQuestSound,
    GateQuestSound,
    MainQuestSound,
    DestroySound
}
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    //[SerializeField] private AudioSource audioController;
    [SerializeField] private AudioClip launcherClip;
    [SerializeField] private AudioClip gateClip;
    [SerializeField] private AudioClip gearClip;
    [SerializeField] private AudioClip sparkClip;
    [SerializeField] private AudioClip angleClip;
    [SerializeField] private AudioClip mainBumperClip;
    [SerializeField] private AudioClip flipperClip;
    [SerializeField] private AudioClip bellClip;
    [SerializeField] private AudioClip targetClip;
    [SerializeField] private AudioClip targetQuestClip;
    [SerializeField] private AudioClip gateQuestClip;
    [SerializeField] private AudioClip mainQuestClip;
    [SerializeField] private AudioClip destroyClip;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //currentSound = null;
    }
    
    public void PlaySound(MySounds sounds)
    {
        switch (sounds)
        {
            case MySounds.NoSound:
                break;
            case MySounds.LauncherSound:
                audioSource.PlayOneShot(launcherClip);
                break;
            case MySounds.GateSound:
                audioSource.PlayOneShot(gateClip);
                break;
            case MySounds.GearSound:
                audioSource.PlayOneShot(gearClip);
                break;
            case MySounds.SparkleSound:
                audioSource.PlayOneShot(sparkClip);
                break;
            case MySounds.AngleSound:
                audioSource.PlayOneShot(angleClip);
                break;
            case MySounds.MainBumperSound:
                audioSource.PlayOneShot(mainBumperClip);
                break;
            case MySounds.FlipperSound:
                audioSource.PlayOneShot(flipperClip);
                break;
            case MySounds.BellSound:
                audioSource.PlayOneShot(bellClip);
                break;
            case MySounds.TargetSound:
                audioSource.PlayOneShot(targetClip);
                break;
            case MySounds.TargetQuestSound:
                audioSource.PlayOneShot(targetQuestClip);
                break;
            case MySounds.GateQuestSound:
                audioSource.PlayOneShot(gateQuestClip);
                break;
            case MySounds.MainQuestSound:
                audioSource.PlayOneShot(mainQuestClip);
                break;
            case MySounds.DestroySound:
                audioSource.PlayOneShot(destroyClip);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sounds), sounds, null);
        }
    }
}
