using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    //  [SerializeField] private float xAngel;
    
    
    Vector3 startingposition;
    [SerializeField] Vector3 Movementvector;
    [Range(0, 1)] float Movementfactor;
    [SerializeField] float period = 2f;

    private void Start()
    {
        startingposition = transform.position;
     
    }

    void Update()
    {
        //      transform.RotateAround(transform.position,Vector3.up,xAngel*Time.deltaTime);
       
     
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI / 2;

        float rawsinrawe = Mathf.Sin(cycles * tau);
        Movementfactor = (rawsinrawe + 1f) / 2f;

        Vector3 offset = (Movementfactor * Movementvector);

        transform.position = offset + startingposition;
    }


}
