using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GH : MonoBehaviour
{   // 50 random sequential notes with values 1-4
    List<float> whichNote = new List<float>() {1,3,4,2,2,1,2,3,4,1,2,4,1,1,4,3,2,1,2,2,3,4,2,1,1,3,3,2,1,2,2,2,4,4,3,2,1,2,3,3,4,3,2,1,2,4,3,1,4,3};

    // Initialisation
    public int SongSize = 0;
   
    public int noteMark = 0;//Notes start at 0

    public Transform noteObj;

    public string timerReset="y"; //Notes' positions only changing in y direction

    public float xPos;

    public static int WinStreak = 0;

    public Transform FireworksFountain;

    public string fireworkSpawnL = "n";
    public string fireworkSpawnR = "n";
    
    public int choose2x = 0;

    public GameOverScreen GameOverScreen;

    public static int totalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        SongSize = whichNote.Count;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((timerReset == "y") && (noteMark < SongSize))
        {

            StartCoroutine (spawnNote());
            timerReset = "n"; //To prevent overlapping spawning
        }
        // Firework at note streak = 5
        if ((WinStreak == 5) && (fireworkSpawnL == "n"))
        {
            fireworkSpawnL = "y";
            Instantiate(FireworksFountain, new Vector3 (-3.1f, -0.56f, 0.01f), FireworksFountain.rotation);
        }

        // Firework at note streak = 8
        if ((WinStreak == 8) && (fireworkSpawnR == "n"))
        {
            fireworkSpawnR = "y";
            Instantiate(FireworksFountain, new Vector3 (3.1f, -0.56f, 0.01f), FireworksFountain.rotation);
        }
    }

    IEnumerator spawnNote(){
        yield return new WaitForSeconds (1); //Evey ? seconds note will spawn

        if (whichNote [noteMark] == 1){ //Comparing list to align notes in x direction
            xPos = -1.57f;
        }
        
        if (whichNote [noteMark] == 2){ //Comparing list to align notes in x direction
            xPos = -0.517f;
        }

        if (whichNote [noteMark] == 3){ //Comparing list to align notes in x direction
            xPos = 0.537f;
        }

        if (whichNote [noteMark] == 4){ //Comparing list to align notes in x direction
            xPos = 1.59f;
        }
        
      

        noteMark += 1;
        timerReset = "y";
        Instantiate (noteObj, new Vector3 (xPos, 1.54f, 4.65f), noteObj.rotation); //Spawning notes at top of guitar board

    }

    public void GameOver(){
        GameOverScreen.Setup(totalScore);
    }
}