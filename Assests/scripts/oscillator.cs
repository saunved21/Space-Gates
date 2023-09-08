using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillator : MonoBehaviour
{
    Vector3 startingpoint;
    [SerializeField] Vector3 movingvector;
    [SerializeField] [Range(0,1)] float movementfacotr;
    [SerializeField] float Period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingpoint=transform.position;
        Debug.Log(startingpoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; }    // or 0 
        float cycle = Time.time / Period;             //keeps grwoing 
        const float tau = Mathf.PI*2;                 // 2pi
            
        float rawsinwave = Mathf.Sin(cycle*tau);      //-1 to 1  

        movementfacotr= (rawsinwave+1)/2f;            // 0 to 1


        Vector3 offset = movingvector*movementfacotr;
        transform.position = startingpoint + offset;
    }
}
