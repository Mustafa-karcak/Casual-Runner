using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionnEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Runner"))
        {
            Destroy(other.gameObject);
     
        
        }
    }



}
