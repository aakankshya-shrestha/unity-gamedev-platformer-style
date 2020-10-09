using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFinalScore : MonoBehaviour
{
    // Start is called before the first frame update
   private PlayerController player;
    public GameObject FinalScreen;
    public string mainMenu;
	public float waitAfterFinalScreen;

    //public LifeManager lifeManager;
    void Start()
    {
   
        
    }

    // Update is called once per frame
  
    void OnTriggerEnter2D (Collider2D other){
        if (other.GetComponent<PlayerController>() ==null)
        return;
        FinalScreen.SetActive (true);
		player.gameObject.SetActive (false);
     
     
    }
    
}