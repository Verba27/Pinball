using UnityEngine;

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
    [SerializeField] private Destroyer destroy;

    [SerializeField] private CollisionDetector[] bumperTapes;
    
    private int ballsRemain = 2;
    private int lives = 3;
    private int currentScore;

    private int gamesCounter;
    private int bestScore;
    private string STATS_KEY = "stats_key";
    private string GAMES_KEY = "games_key";

    public void Awake()
    {
        gamesCounter = PlayerPrefs.GetInt(GAMES_KEY, gamesCounter);
        bestScore = PlayerPrefs.GetInt(STATS_KEY, bestScore);
        Debug.Log($"bestScore = {bestScore}");
        Debug.Log($"GamesPlayed = {gamesCounter}");
    }
    public void Start()
    {
        for (int i = 0; i < bumperTapes.Length; i++)
        {
            bumperTapes[i].onColl += BumpCollision;
        }
        scoreCounter.onScore += ScoreInfo;
        quests.hitAllTargets += AllTargetsQuestDone;
        quests.passAllGates += AllGatesPassQuestDone;
        quests.onMainQuest += MainQuestDone;
        destroy.onDestroy += BallLost;
        launcher.ballCreated += AddBallInGame;
        uiManager.UpdadeUI(MyUI.MainMenuUI);
    }
    
    public void StartGame()
    {
        ballsRemain = 3;
        uiManager.UpdadeUI(MyUI.GameplayUI);
        uiManager.UpdateGameScore(0);
        uiManager.RemainingBalls(ballsRemain);
        interactionObjects.DoInteraction(MyInteractions.AllObjectsBackOn);
        scoreCounter.DeleteScore();
        lives = 3;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        Destroy(ball);
        uiManager.UpdadeUI(MyUI.MainMenuUI);
        lives = 3;
        Time.timeScale = 1;
    }
    public void SettingsMenu()
    {
        uiManager.UpdadeUI(MyUI.SettingMenuUI);
    }
    public void ShopMenu()
    {
        uiManager.UpdadeUI(MyUI.ShopMenuUI);
        uiManager.UpdateStatistics(bestScore, gamesCounter);
    }
    public void BackFromSettingsMenu()
    {
        uiManager.UpdadeUI(MyUI.ExitSettings);
    }
    public void BackFromShopMenu()
    {
        uiManager.UpdadeUI(MyUI.ExitShop);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        uiManager.UpdadeUI(MyUI.GameplayUI);
        Time.timeScale = 1;
    }
    public void EndGame()
    {
        uiManager.UpdadeUI(MyUI.PauseGameOverUI);
        gamesCounter++;
        Time.timeScale = 0;
        PlayerPrefs.SetInt(GAMES_KEY, gamesCounter);
        PlayerPrefs.SetInt(STATS_KEY, bestScore);
        PlayerPrefs.Save();
    }

    public void Restart()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        Destroy(ball);
        StartGame();
    }
    private void AddBallInGame(bool ballcreated)
    {
        ballsRemain--;
    }
    private void BallLost(bool onDestroy)
    {
        lives--;
        if (lives == 0)
        {
            if (bestScore < currentScore)
            {
                bestScore = currentScore;
            }
            EndGame();
        }
        particleManager.PlayParticles(MyParticlesSystems.OffAllParticles);
        interactionObjects.DoInteraction(MyInteractions.AllObjectsBackOn);
        audioManager.PlaySound(MySounds.DestroySound);
        quests.QuestCompliter(MyQuest.RefresQuests);
    }
    private void ScoreInfo(int scoreThisSession)
    {
        currentScore = scoreThisSession;
        uiManager.UpdateGameScore(currentScore);
        uiManager.RemainingBalls(ballsRemain);
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
}
