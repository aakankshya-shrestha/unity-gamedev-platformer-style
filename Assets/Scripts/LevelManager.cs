using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerController player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    public int pointPenaltyOnDeath;
    private float gravityScore;
    private CameraController camera;
    public HealthManager healthManager;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController> ();
        camera = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(){
       
        StartCoroutine("RespawnPlayerCo");

    }
    //creating a co-routint
    public IEnumerator RespawnPlayerCo(){
        gravityScore = player.GetComponent<Rigidbody2D>().gravityScale;
        Instantiate (deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        //camera.isFollowing = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        //stop his speed
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ScoreManager.AddPoints(-pointPenaltyOnDeath); 
        Debug.Log ("PLayer respawn");
        yield return new WaitForSeconds (respawnDelay);
        player.GetComponent<Rigidbody2D>().gravityScale = gravityScore;
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        //camera.isFollowing=true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
