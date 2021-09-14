using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] 
    private string volumeParameter = "LevelVolume";
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private Slider slider;
    [SerializeField] 
    private float multiplier = 30f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
    }

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }
}
