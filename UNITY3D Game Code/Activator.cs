using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Initialisation
    public Transform SuccessBurst;

    public KeyCode key;
    bool active = false;
    GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If corresponding key is pressed note is destroyed
        if (Input.GetKeyDown(key) && active && note != null){
            Destroy(note);
            Debug.Log ("SUCCESS!!!");
            Instantiate(SuccessBurst, transform.position, SuccessBurst.rotation); // Green 'success' burst
            GH.WinStreak += 1;
            GH.totalScore += 10; // Score increases by 10 for correct note
        }
        
    }

    void OnTriggerEnter(Collider col){
        active=true;
        if(col.gameObject.tag=="Note"){
            note = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col){
        active=false;
    }
}
