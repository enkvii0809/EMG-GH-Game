using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{

    public TMP_Text pointsText;
    // Start is called before the first frame update
    public void Setup(int Score)
    {
        gameObject.SetActive(true);
        
    }

    
}
