using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundButtonImage;

    [Header("Settings")]
    private bool soundsState = true;


    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds",1) == 1;
    }

    void Start()
    {
        Setup();
    }

    void Update()
    {
        
    }

    private void Setup()
    {
        if (soundsState)
            EnableSounds();
        else 
            DisableSounds();
    }
    
    
    public void ChangedSoundsState()

    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();
     
        soundsState = !soundsState;
        
        // save the value of the sounds State
       int soundsSaveState = 0;
        
        if(soundsState)
            soundsSaveState = 1;
        else
            soundsSaveState = 0;

        PlayerPrefs.SetInt("sounds", soundsSaveState);
    }
    private void EnableSounds()
    {

        soundsManager.EnableSounds();
        soundButtonImage.sprite = optionsOnSprite;
    }

    private void DisableSounds()
    {
        soundsManager.DisableSounds();
        soundButtonImage.sprite = optionsOffSprite;
    }
}
