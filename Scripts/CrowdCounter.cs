using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro CrowdCounterText;
    [SerializeField] private Transform runnersParent;
  



 void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrowdCounterText.text=runnersParent.childCount.ToString();
    }
}
