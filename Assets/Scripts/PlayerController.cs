using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
	public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D myRigidbody2D;
    private bool grounded;
    private bool doubleJumped;
    private Animator anim;
    private float moveVelocity;
    public float ladderHeight;
    
    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockbackLength;
    public float knockback;
    public float knockbackCount;
    public bool knockFromRight;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore; 
     //private const float size = 0.20f;
     private const float size = 0.5785947f;
   



    void Start()
    {
       anim = GetComponent<Animator> ();
       myRigidbody2D = GetComponent<Rigidbody2D>();
       gravityStore = myRigidbody2D.gravityScale;
        
    }
    void FixedUpdate()
	{
		this.grounded = Physics2D.OverlapCircle (this.groundCheck.position, this.groundCheckRadius, this.whatIsGround);
	}
    void Update()

    {
        //to set doublejump state
        if(grounded){
            doubleJumped = false;
        }

        this.anim.SetBool ("grounded", this.grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown ("Jump") && this.grounded) {
			this.Jump ();
		}

		if (Input.GetButtonDown ("Jump") && !this.doubleJumped && !this.grounded) {
			this.Jump ();
			this.doubleJumped = true;
		}
      

//movement code
        
        // 
        Move(Input.GetAxisRaw ("Horizontal"));
        //no knockback
#endif
        if(knockbackCount<=0){
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        //knockback
        
        else {
			if (knockFromRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-knockback, knockback);
			} else {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (knockback, knockback);
			}
			knockbackCount -= Time.deltaTime;
		}


        //Animation setting
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        //player flipping
       
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(size,size,size);

        else if(GetComponent<Rigidbody2D>().velocity.x <0)
            transform.localScale = new Vector3(-size,size,size);
        

        //for projectile
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if(Input.GetButtonDown("Fire1")){
            FireStar();
            //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }
        if(Input.GetButtonDown("Fire1")){

            shotDelayCounter -= Time.deltaTime;
            if(shotDelayCounter<=0){
                shotDelayCounter = shotDelay;
                FireStar();
                //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            }

        }

        if(anim.GetBool("Sword"))
            //anim.SetBool("Sword", false);
            ResetSword();

       if(Input.GetButtonDown("Fire2")){
            //anim.SetBool("Sword", true);
            Sword();

        }
      
    // if (this.onLadder) {
	// 		ClimbLadder();
         
	// 	}

	// 	if (!this.onLadder) {
	// 		ResetLadder();
	// 	}    
   
     #endif  


    }


    public void Move(float moveInput){
        this.moveVelocity = moveSpeed * moveInput;

    }
    public void FireStar(){
        Instantiate(ninjaStar, firePoint.position, firePoint.rotation);

    }
    public void Sword(){
        anim.SetBool("Sword", true);

    }
    public void ResetSword(){
        anim.SetBool("Sword", false);


    }

    // public void ClimbLadder(){

    //     if(onLadder){
    //         this.myRigidbody2D.gravityScale = 0f;
    //         GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,ladderHeight);
    //         this.myRigidbody2D.velocity = new Vector2 (this.myRigidbody2D.velocity.x, this.ladderHeight);
    //     }
         
	// 	// this.climbVelocity = this.climbSpeed * Input.GetAxisRaw ("Vertical");
	// 	// this.myRigidbody2D.velocity = new Vector2 (this.myRigidbody2D.velocity.x, this.climbVelocity);

    // }
    // public void ResetLadder(){
    //     this.myRigidbody2D.gravityScale = this.gravityStore;
    // }
    public void Jump(){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
        
        if (grounded && this.grounded) {
             GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			
		}

		if (!this.doubleJumped && !this.grounded) {
             GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			
			this.doubleJumped = true;
		}
    }
}
