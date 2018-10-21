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
    public Text highScore;
    public Text killScore;
    public Text coinScore;
    public Text PlayerNameUI_OLD;
    public Text PlayerNameUI_NEW;
    public Text PlayerNameIF_EXIST;

    public InputField PlayerName_IF;
    private string st_playerName;
    private string st_playerNameEXIST;
    

    public GameObject PauseMenuInst;
    public GameObject StartMenuInst;
    public GameObject GameUIInst;


    public int i_Life;
    private int i_Points;
    private int i_Coins;
    public int i_Kills;
    public int i_Daggers = 30;

    private bool b_Jump = false;
    public bool b_IsDead;
    private bool b_soundJump = false;
    
    public Transform playerTransform;
    
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
        
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        killScore.text = PlayerPrefs.GetInt("HighKills").ToString();
        coinScore.text = PlayerPrefs.GetInt("HighCoins").ToString();
        //PlayerNameUI_NEW.text = PlayerPrefs.GetString("").ToString();
        PlayerNameUI_OLD.text = PlayerPrefs.GetString("PlayerName").ToString();
        PlayerNameIF_EXIST.text = "FUCK";


}

     public void SetPlayerName()
    {

        PlayerNameUI_NEW.text = PlayerName_IF.text;
        PlayerName_IF.text = st_playerNameEXIST;
        st_playerName = PlayerNameUI_NEW.text;
        
        StartMenuInst.SetActive(false);
       
        Time.timeScale = 1f;

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
        Debug.Log(st_playerName);

        playerCoins.text = i_Coins.ToString();
        playerScore.text = i_Points.ToString();
        playerLife.text = i_Life.ToString();
        playerKills.text = i_Kills.ToString();
        playerDaggers.text = i_Daggers.ToString();
        
        


        PlayerPrefs.SetInt("HighScore", i_Points);
        PlayerPrefs.SetInt("HighKills", i_Kills);
        PlayerPrefs.SetInt("HighCoins", i_Coins);
        PlayerPrefs.SetString("PlayerName", st_playerName);
        

        // Check player Death
        if (i_Life <= 0)
        {
            b_IsDead = true;
            f_runSpeed = 0;

        }
        //If Dead
        if (b_IsDead)
        {

            animator.SetBool("IsDead", true);
            f_runSpeed = 0;
            f_horizontalMove = 0;
            //PlayerNameUI_NEW.text = PlayerNameUI_OLD.text;

        }

        if (sr_player.color == Color.red)
        {
            i_spriteColloringCounter++;
            if (i_spriteColloringCounter >= 50)
            {
                i_spriteColloringCounter = 0;
                sr_player.color = Color.white;
            }
            
        }

        if (!b_IsDead && PauseMenuInst.activeSelf == false && StartMenuInst.activeSelf == false)
        {
            GameUIInst.SetActive(true); // Activation UI

            f_horizontalMove = Input.GetAxisRaw("Horizontal") * f_runSpeed;
            animator.SetFloat("PlayerSpeed", Mathf.Abs(f_horizontalMove));


            //Jumping
            if (Input.GetButtonDown("Jump") && b_soundJump == false)
            {
                b_soundJump = true;
                b_Jump = true;
                animator.SetBool("IsJumping", true);
                FindObjectOfType<AudioManager>().Play("Jump");
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
            /*   if (Input.GetButton("Attack"))
            {
                animator.SetBool("IsAttacking", true);
            }
            else if (Input.GetButtonUp("Attack"))
            {
                animator.SetBool("IsAttacking", false);
            }*/
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
            b_soundJump = false;
            animator.SetBool("IsThrowing", false);

        }
        
    }





    //Phone Controller

    public void Jump ()
    {
        if (!b_IsDead && PauseMenuInst.activeSelf == false && StartMenuInst.activeSelf == false)
        {
            b_Jump = true;
            animator.SetBool("IsJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    public void MoveLeft()
    {


    }

    public void MoveRight()
    {


    }
}
