using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int playerHealth;

	public int maxPlayerHealth;
	//public Text text;
    public Slider healthBar;

	private LevelManager levelManager;
    public bool isDead;
    private LifeManager lifeSystem;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();

        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
        lifeSystem = FindObjectOfType<LifeManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
            lifeSystem.TakeLife();
        }

        
        //text.text = "" + playerHealth;
        
        if(playerHealth > maxPlayerHealth){
            playerHealth = maxPlayerHealth;
        }
        healthBar.value = playerHealth;
    }

    public static void HurtPlayer (int damageToGive)
	{
		playerHealth -= damageToGive;
        PlayerPrefs.SetInt ("PlayerCurrentHealth", HealthManager.playerHealth);

	
	}
    public void FullHealth ()
	{
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
        PlayerPrefs.SetInt ("PlayerCurrentHealth", HealthManager.playerHealth);
	}
}
