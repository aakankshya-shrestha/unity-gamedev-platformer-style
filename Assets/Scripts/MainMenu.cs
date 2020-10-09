using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
	public string startguidelevel;
	public string newlevelselect;
	public int playerLives;
	public int playerHealth;
	public string level1Tag;
    // Start is called before the first frame update

    public void NewGame ()
	{
		
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		PlayerPrefs.SetInt(level1Tag, 1);
		PlayerPrefs.SetInt("PlayerLevelSelectPosition",0);
		Application.LoadLevel (this.startLevel);
	}

	public void NewGuideGame (){
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		PlayerPrefs.SetInt(level1Tag, 1);
		PlayerPrefs.SetInt("PlayerLevelSelectPosition",0);
		Application.LoadLevel (this.startguidelevel);

	}

	public void LevelSelect ()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.playerLives); 
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		PlayerPrefs.SetInt(level1Tag, 1);	
		if(!PlayerPrefs.HasKey("PlayerLevelSelectPosition")){
			PlayerPrefs.SetInt("PlayerLevelSelectPosition",0);
		}
		Application.LoadLevel (this.newlevelselect);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
