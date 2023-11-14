using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private ShopManager shopManager;


    [Header("Elements")]
    [SerializeField] private GameObject menuPanel; 
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private Text levelText;
    [SerializeField] private Slider progressBar;
    void Start()
    {
        progressBar.value = 0;

        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        settingsPanel.SetActive(false);
        HideShop();
       
        levelText.text = "Level" + (ChunkManager.instance.GetLevel() + 1);

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    void Update()
    {
        UpdateProgressBar();
    }
  private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.GameOver)
            ShowGameOver();
       else if(gameState == GameManager.GameState.LevelComplete) 
              ShowLevelComplete();
    }


    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        levelCompletePanel.SetActive(false);
    }
    public void ShowLevelComplete()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
        gameOverPanel.SetActive(false);

    
    }


    public void PlayButtonPressed()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);   
    
    }
    public void UpdateProgressBar()
    {
        if (!GameManager.Instance.ÝsGameState())
            return;
        float progress = PlayerController.instance.transform.position.z/ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    
    public void ShowShop()
    {
        shopPanel.SetActive(true);   
   shopManager.UpdatePurchaseButton();
   menuPanel.SetActive(false);
    }
    public void HideShop()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}

