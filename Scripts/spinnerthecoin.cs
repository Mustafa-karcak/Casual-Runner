using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerthecoin : MonoBehaviour
{
    [SerializeField] private float zAngel;
   
  
    void Update()
    {
        transform.Rotate(0f,0f ,zAngel*Time.deltaTime, Space.Self);
    }
}
