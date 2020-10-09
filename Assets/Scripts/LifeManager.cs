using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //public int startingLives;
    
    public int lifeCounter;
	private Text theText;
	private PlayerController player;
    public GameObject GameOverScreen;
    public string mainMenu;
	public float waitAfterGameOver;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text> ();
        lifeCounter = PlayerPrefs.GetInt ("PlayerCurrentLives");
        player = FindObjectOfType<PlayerController> ();
        
    }

    // Update is called once per frame
    void Update()
    
    {
        if (lifeCounter < 1) {
			GameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

        theText.text = "x " + lifeCounter;
        
        if (GameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) {
			Application.LoadLevel (mainMenu);
		}
        
    }
    public void GiveLife ()
	{
		lifeCounter++;
        PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
		
	}

	public void TakeLife ()
	{
		lifeCounter--;
        PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	
	}
    
    //pachi thapeko exit lai dungeon ko
    // void OnTriggerEnter2D (Collider2D other){
    //     if (other.GetComponent<PlayerController>() ==null)
    //     return;
    //     lifeCounter = 0;
     
    
    // }
}
