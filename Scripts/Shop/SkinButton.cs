using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Button skinButton;
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject selector;

    private bool unlocked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(Sprite skinSprite, bool unlocked)
    { 
    skinImage.sprite = skinSprite;
    this.unlocked = unlocked;
  
        if(unlocked)
        Unlock();
        else
            Lock();
        
    
    
    }

    public void Unlock()
    {
        skinButton.interactable = true;
        skinImage.gameObject.SetActive(true);
        lockImage.SetActive(false);

        unlocked = true;
    }
    private void Lock()
    {
        skinButton.interactable = false;
        skinImage.gameObject.SetActive(false);
        lockImage.SetActive(true);
 
    unlocked = false;
    }

    public void Select()
    {
        selector.SetActive(true);
    }
  
    
    public void DeSelect()
    {
        selector.SetActive(false);
    }
  
    public Button GetButton()
    {
        return skinButton;
    }
    
    public bool IsUnlocked()
    {
        return unlocked; 
    
    }

}
