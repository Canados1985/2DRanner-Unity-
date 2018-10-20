using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController cl_PlaterController; // class 
    public GameObject go_Player;
    public Rigidbody2D rb_Player;
    public CharacterController2D controller;
    public Canvas canvasInst;

    public Text playerScore;
    public Text playerLife;
    public Text playerCoins;
    public Text playerKills;
    public Text playerDaggers;
    public Text playerName;
    public Text highScore;
    public Text killScore;
    public Text coinScore;
    public string s_playerName = "Andrey";

    public GameObject PauseMenuInst;
    public GameObject StartMenuInst;

    //public float f_runSpeed;
    //public float f_runSpeed;
    //public float f_jumpForce;
    public int i_Life;
    private int i_Points;
    private int i_Coins;
    public int i_Kills;
    public int i_Daggers = 30;

    private bool b_Jump = false;
    public bool b_IsDead;
    
    
    public Transform playerTransform;
    public Transform sp_MainCamera_Transform;


    

    public Animator animator;
    public SpriteRenderer sr_player;

    public float f_horizontalMove = 0f;
    private float f_runSpeed = 40f;

    private int i_spriteColloringCounter = 0; 
	

	void Start () {

        i_Life = 3;
        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sr_player = GetComponent<SpriteRenderer>();
        cl_PlaterController = this;
        rb_Player = this.GetComponent<Rigidbody2D>();
        
        sp_MainCamera_Transform = GameObject.Find("Enemy_front").transform;

        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        killScore.text = PlayerPrefs.GetInt("HighKills").ToString();
        coinScore.text = PlayerPrefs.GetInt("HighCoins").ToString();
        s_playerName = PlayerPrefs.GetString("PlayerName").ToString();
    }




    public void Points()
    {
        i_Points = i_Points + 1;
    }
    public void CollectCoins()
    {
        i_Coins = i_Coins + 1;
        
    }

    public void LoosingHealth()
    {
        
        i_Life--;
        
    }

    //Switching Jump animation
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsThrowing", false);
    }


    private void Update()
    {
        Debug.Log("PLAYER'S NAME" + s_playerName);

        playerCoins.text = i_Coins.ToString();
        playerScore.text = i_Points.ToString();
        playerLife.text = i_Life.ToString();
        playerKills.text = i_Kills.ToString();
        playerDaggers.text = i_Daggers.ToString();
        playerName.text = playerName.ToString();


        PlayerPrefs.SetInt("HighScore", i_Points);
        PlayerPrefs.SetInt("HighKills", i_Kills);
        PlayerPrefs.SetInt("HighCoins", i_Coins);
        PlayerPrefs.SetString("PlayerName", s_playerName);

        //Debug.Log(i_Coins);


        // Check player Death
        if (i_Life <= 0)
        {
            b_IsDead = true;
            f_runSpeed = 0;

        }
        //If Deadd
        if (b_IsDead)
        {
            animator.SetBool("IsDead", true);
            f_runSpeed = 0;
            f_horizontalMove = 0;


        }

        if (sr_player.color == Color.red && i_spriteColloringCounter == 0)
        {
            i_spriteColloringCounter++;
            if (i_spriteColloringCounter >= 50)
            {
                i_spriteColloringCounter = 0;
                sr_player.color = Color.white;
            }
            
        }

        if (!b_IsDead && PauseMenuInst.active == false && StartMenuInst.active == false)
        {
            
            
            f_horizontalMove = Input.GetAxisRaw("Horizontal") * f_runSpeed;
            animator.SetFloat("PlayerSpeed", Mathf.Abs(f_horizontalMove));


            //Jumping
            if (Input.GetButtonDown("Jump"))
            {
                b_Jump = true;
                animator.SetBool("IsJumping", true);
            }


            //Throw Dagger
            if (Input.GetButton("Throw") && i_Daggers > 0)
            {
                animator.SetBool("IsThrowing", true);
                
            }
            else if (Input.GetButtonUp("Throw"))
            {
                animator.SetBool("IsThrowing", false);
                f_runSpeed = 0;
            }
            
            //Sword Attack
            if (Input.GetButton("Attack"))
            {
                animator.SetBool("IsAttacking", true);
            }
            else if (Input.GetButtonUp("Attack"))
            {
                animator.SetBool("IsAttacking", false);
            }
        }
        f_runSpeed = 40;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (b_IsDead)
        {
            f_horizontalMove = 0f;
            controller.Move(f_horizontalMove * Time.deltaTime, false, b_Jump);
        }

        if (!b_IsDead && Input.GetButton("Throw") == false)
        {
            // Moving player
            controller.Move(f_horizontalMove * Time.deltaTime, false, b_Jump);

            b_Jump = false;
            
        }
 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "GROUND")
        {
            animator.SetBool("IsJumping", false);
            b_Jump = false;
            animator.SetBool("IsThrowing", false);

        }
        
    }

    
}
