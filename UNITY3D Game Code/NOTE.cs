using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTE : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0,speed,speed); // Speed of note travelling down fretboard
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
