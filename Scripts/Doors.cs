using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public enum BonusType { Addition,Difference,Product,Division}

public class Doors : MonoBehaviour
{
    
    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private BoxCollider Doorscollider;


    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    [SerializeField] private int xPositionss = 4;

    [SerializeField] private BonusType leftBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;



    void Start()
    {
        ConfigureDoors();
        bonusColor.a = 0.5f;
        penaltyColor.a = 0.5f;
    }

    void Update()
    {
        
    }
  
    
    private void ConfigureDoors()
    {
        switch(rightDoorBonusType)
        {
        case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
       
        case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;
        
        case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmount;
                break;  
     
        case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
     
        
        }

        switch (leftBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;

        }
    }

    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > xPositionss)
            return rightDoorBonusAmount;
        else
           return leftDoorBonusAmount;   
    }
    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > xPositionss)
            return rightDoorBonusType;
        else
            return leftBonusType;
                
                
    }
    public void Disable()
    {
        Doorscollider.enabled = false;
    }
}











