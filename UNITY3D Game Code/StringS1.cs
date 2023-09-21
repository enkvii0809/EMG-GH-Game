using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringS1 : MonoBehaviour
{
    public KeyCode activateString;

    public string lockInput = "n"; //Prevent multiple notes on key activatiom

    public static string releasedKey = "n";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown (activateString)) && (lockInput=="n")){

            lockInput = "y";
            GetComponent<Rigidbody> ().velocity = new Vector3(0,0,2.5f);
            StartCoroutine (retractCollider());
            releasedKey = "n";
        }

        if (Input.GetKeyUp (activateString)){

            releasedKey = "y";
        }
        
    }

    IEnumerator retractCollider(){

        //yield return new WaitForSeconds (.75f);
        //GetComponent<Rigidbody>().velocity = new Vector3(0,0,-0.6); // Reversing change in z
        yield return new WaitForSeconds (.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0); // Reversing change in z


        if (releasedKey == "n"){
            yield return new WaitForSeconds (1);
            StartCoroutine (releaseNote ());
        }

        if (releasedKey == "y"){
            StartCoroutine (releaseNote ());
        }

       //lockInput = "n";
    }

    IEnumerator releaseNote()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,-2.5f);
        yield return new WaitForSeconds (.75f);
        GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,0);
        lockInput = "n";
    }
}
