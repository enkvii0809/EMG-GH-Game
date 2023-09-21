using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    // Initialisation
    public Transform SuccessBurst;

    public Transform FailBurst;
    
    public KeyCode key;

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
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FailCol")
        {

            Destroy (gameObject);
            Debug.Log ("FAIL!!!");
            Instantiate(FailBurst, transform.position, FailBurst.rotation); // Red burst
            GH.totalScore -= 2; // Score decreases by 2 if note is missed
        }

        if(Input.GetKeyDown(key)){
            Destroy(gameObject);
            Debug.Log ("SUCCESS!!!");
            Instantiate(SuccessBurst, transform.position, SuccessBurst.rotation); // Green burst
            GH.WinStreak += 1;
            GH.totalScore += 10; // Score increases by 10 if note is destroyed
        }
        
    }
}
