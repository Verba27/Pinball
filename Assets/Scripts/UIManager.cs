using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MyUI
{
    MainMenuUI,
    SettingMenuUI,
    ShopMenuUI,
    GameplayUI,
    PauseGameOverUI,
    ExitSettings,
    ExitShop
}

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject SettingsMenuUI;
    [SerializeField] private GameObject ShopMenuUI;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject PauseGameOverUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ballCounterText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [SerializeField] private Image mainMenuCanvas;
    [SerializeField] private Image settingsCanvas;
    [SerializeField] private Image shopCanvas;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float durationCameraRotation = 3f;
    [SerializeField] private float durationMenuRotation = 0.5f;
    private Coroutine coroutine;
    private bool isPlaying = false;
    
    public void UpdadeUI(MyUI doUI)
    {
        switch (doUI)
        {
            case MyUI.MainMenuUI:
                isPlaying = false;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                MainMenuUI.SetActive(true);
                SettingsMenuUI.SetActive(false);
                ShopMenuUI.SetActive(false);
                GameplayUI.SetActive(false);
                mainCamera.transform.rotation = Quaternion.Euler(165, 180, -180);
                PauseGameOverUI.SetActive(false);
                break;
            case MyUI.SettingMenuUI:
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(EnterSettings());
                break;
            case MyUI.ShopMenuUI:
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(EnterShop());
                break;
            case MyUI.GameplayUI:
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                MainMenuUI.SetActive(false);
                SettingsMenuUI.SetActive(false);
                ShopMenuUI.SetActive(false);
                GameplayUI.SetActive(true);
                PauseGameOverUI.SetActive(false);
                if (isPlaying == false)
                {
                    coroutine = StartCoroutine(StartGameCameraPosition());
                }
                break;
            case MyUI.PauseGameOverUI:
                MainMenuUI.SetActive(false);
                SettingsMenuUI.SetActive(false);
                ShopMenuUI.SetActive(false);
                GameplayUI.SetActive(false);
                PauseGameOverUI.SetActive(true);
                break;
            case MyUI.ExitSettings:
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(ExitSettings());
                break;
            case MyUI.ExitShop:
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(ExitShop());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(doUI), doUI, null);
        }
    }

    IEnumerator StartGameCameraPosition()
    {
        Quaternion startRotation= Quaternion.Euler(165, 180, -180);
        Quaternion gameRotation = Quaternion.Euler(94, 180, -180);
        float startTime = 0;
        while (startTime < durationCameraRotation)
        {
            startTime += Time.deltaTime;
            mainCamera.transform.rotation = Quaternion.Lerp(startRotation,gameRotation,(startTime/durationCameraRotation));
            yield return null;
        }
        isPlaying = true;
    }
    IEnumerator EnterSettings()
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion gameRotation = Quaternion.Euler(90, 0, 0);
        float startTime = 0;
        while (startTime < durationMenuRotation)
        {
            startTime += Time.deltaTime;
            mainMenuCanvas.transform.rotation = Quaternion.Lerp(startRotation, gameRotation, (startTime / durationMenuRotation));
            SettingsMenuUI.SetActive(true);
            settingsCanvas.transform.rotation = Quaternion.Lerp(gameRotation, startRotation, (startTime / durationMenuRotation));
            yield return null;
        }
        MainMenuUI.SetActive(false);
    }
    IEnumerator ExitSettings()
    {
        
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion gameRotation = Quaternion.Euler(90, 0, 0);
        float startTime = 0;
        while (startTime < durationMenuRotation)
        {
            startTime += Time.deltaTime;
            settingsCanvas.transform.rotation = Quaternion.Lerp(startRotation, gameRotation, (startTime / durationMenuRotation));
            MainMenuUI.SetActive(true);
            mainMenuCanvas.transform.rotation = Quaternion.Lerp(gameRotation, startRotation, (startTime / durationMenuRotation));
            yield return null;
        }
        SettingsMenuUI.SetActive(false);
    }
    IEnumerator EnterShop()
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion gameRotation = Quaternion.Euler(90, 0, 0);
        float startTime = 0;
        while (startTime < durationMenuRotation)
        {
            startTime += Time.deltaTime;
            mainMenuCanvas.transform.rotation = Quaternion.Lerp(startRotation, gameRotation, (startTime / durationMenuRotation));
            ShopMenuUI.SetActive(true);
            shopCanvas.transform.rotation = Quaternion.Lerp(gameRotation, startRotation, (startTime / durationMenuRotation));
            yield return null;
        }
        MainMenuUI.SetActive(false);
    }
    IEnumerator ExitShop()
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion gameRotation = Quaternion.Euler(90, 0, 0);
        float startTime = 0;
        while (startTime < durationMenuRotation)
        {
            startTime += Time.deltaTime;
            shopCanvas.transform.rotation = Quaternion.Lerp(startRotation, gameRotation, (startTime / durationMenuRotation));
            MainMenuUI.SetActive(true);
            mainMenuCanvas.transform.rotation = Quaternion.Lerp(gameRotation, startRotation, (startTime / durationMenuRotation));
            yield return null;
        }
        ShopMenuUI.SetActive(false);
    }
    public void UpdateGameScore(int currentScore)
    {
        scoreText.text = currentScore.ToString();
        endGameScoreText.text = currentScore.ToString();
    }

    public void RemainingBalls(int balls)
    {
        ballCounterText.text = balls.ToString();
    }
    
}