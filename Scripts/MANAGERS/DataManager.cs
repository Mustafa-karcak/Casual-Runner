using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    [Header("Coin Text")]
    [SerializeField] private Text[] coinsTexts;
    [Header("Source")]
    [SerializeField] private AudioSource coinSound;
    
    private int coins;

    private void Awake()
    {
    if(Instance != null)
        Destroy(gameObject);
        else
            Instance = this;

        coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void Start()
    {
    
        
        UpdateCoinsText();
    }


    private void UpdateCoinsText()
    {
        foreach (var coinText in coinsTexts)
        {
            coinText.text = coins.ToString();
        }

    }
    public void AddCoins(int amount)
    {
        coins += amount;

        coinSound.Play();

        UpdateCoinsText();

        PlayerPrefs.SetInt("coins", coins);
    }
    public void UseCoins(int amount)
    {
        coins -= amount;

        UpdateCoinsText();

        PlayerPrefs.SetInt("coins", coins);
    }
    
    
    public int GetCoins()
    {
        return coins;

    }
}
