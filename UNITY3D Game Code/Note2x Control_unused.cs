using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2xcontrol : MonoBehaviour

{

    public Transform SuccessBurst;
    public Transform FailBurst;

    public int noteHP = 10;

    Rigidbody rb;

    public float speed;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0,speed,speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (noteHP < 1)
        {
            Destroy (gameObject);
            Debug.Log ("SUCCESS!!!");
            Instantiate(SuccessBurst, transform.position, SuccessBurst.rotation);
            GH.WinStreak += 1;
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FailCol")
        {
            Destroy (gameObject);
            Debug.Log ("FAIL!!!");
            Instantiate(FailBurst, transform.position, FailBurst.rotation); 
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.name == "Success") && (StringS1.releasedKey == "n"))
        {
            noteHP -= 1;      
            
        }
    }
}
