using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Button purchaseButton;
    [SerializeField] private SkinButton[] skinButtons;
    
    
    [Header("Skins")]
    [SerializeField] private Sprite[] skins;

    [Header("Price")]
    [SerializeField] private int skinPrice;
    [SerializeField] private Text priceText;

    private void Awake()
    {
        priceText.text = skinPrice.ToString();
    }

    void Start()
    {
        ConfigureButtons();

        UpdatePurchaseButton();
      //  SelectSkin(0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    
            UnlockSkin(UnityEngine.Random.Range(0, skinButtons.Length));
        if (Input.GetKeyDown(KeyCode.D))
            PlayerPrefs.DeleteAll();
    }

    private void ConfigureButtons()
    {
        for (int i = 0; i < skinButtons.Length; i++) 
        {
            bool unlocked = PlayerPrefs.GetInt("skinButton" + i) == 1;
            
            skinButtons[i].Configure(skins[i], unlocked);
         
            int skinIndex = i;

            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }    
    }
    public void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex, 1);
        skinButtons[skinIndex].Unlock();    
    }
    private void UnlockSkin(SkinButton skinButton)
    {
        int skinIndex = skinButton.transform.GetSiblingIndex();
        UnlockSkin(skinIndex);  
    }
      
    private void SelectSkin(int skinIndex)
    {  
        for (int i = 0; i < skinButtons.Length; i++) 
        {
            if (skinIndex == i)
                skinButtons[i].Select();
            else
                skinButtons[i].DeSelect();
        }
    }
    public void PurchaseSkin()
    {
        List<SkinButton> skinButtonsList = new List<SkinButton>();
        for (int i = 0; i < skinButtons.Length; i++) 
          if (!skinButtons[i].IsUnlocked())
                skinButtonsList.Add(skinButtons[i]);
          

            if(skinButtonsList.Count <= 0)  
                return;


            SkinButton randomSkinButton = skinButtonsList[UnityEngine.Random.Range(0, skinButtonsList.Count)];

            UnlockSkin(randomSkinButton);
            SelectSkin(randomSkinButton.transform.GetSiblingIndex());

            DataManager.Instance.UseCoins(skinPrice);

            UpdatePurchaseButton();
    }
   public void UpdatePurchaseButton()
    {
        if (DataManager.Instance.GetCoins() < skinPrice) 
            purchaseButton.interactable = false;
        else
            purchaseButton.interactable = true;
    }


}
