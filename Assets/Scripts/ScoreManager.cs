using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text text;

        // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        //score = 0;
        ScoreManager.score = PlayerPrefs.GetInt ("CurrentPlayerScore");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (score<0)
            score = 0;

        text.text = "" + score;

        
    }
    public static void AddPoints(int pointsToAdd){
        score += pointsToAdd;
        PlayerPrefs.SetInt ("CurrentPlayerScore", score);

    }
    //if in case for resetting points
    public static void reset(){
        score=0;
        PlayerPrefs.SetInt ("CurrentPlayerScore", score);
    }
}
