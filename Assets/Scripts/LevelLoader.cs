using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string levelTag;
    public string levelToLoad;

	public bool playerInZone;

    
    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical")>0 && playerInZone){
            //Application.LoadLevel(levelToLoad);//immediately load level
            //LoadLevelAsync naya unity feature
            LoadLevel();
        }
      
        
    }
    public void LoadLevel(){
        PlayerPrefs.SetInt (levelTag, 1);
        Application.LoadLevel(levelToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player") {
			this.playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "player") {
			this.playerInZone = false;
		}
	}
}
