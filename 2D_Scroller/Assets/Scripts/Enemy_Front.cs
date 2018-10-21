using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Front : MonoBehaviour {

    public static Enemy_Front cl_Enemy_Front;

    public GameObject go_EnemyFront;

    private GameObject go_daggerInst;

    private Vector3 v3_enemyFront;

    public Transform enemy_Front_Transform;
    public SpriteRenderer enemy_Front_SR;
    public Animator enemy_floatAnimator;
    public CircleCollider2D enemyCircleCollider;
    public BoxCollider2D enemyBoxCollider;
    public float f_moveSpeed;
    public int enemyTouch = 0;



    public bool b_Is_Dead = false;
    bool b_voise = false;


    void Start () {

        cl_Enemy_Front = this;

        go_daggerInst = GameObject.Find("daggerLoot");
        enemy_Front_Transform.GetComponent<Transform>();
        enemy_Front_SR.GetComponent<SpriteRenderer>();
        
        if (this.gameObject.name != "Enemy_front" && this.gameObject.name != "Enemy_front_female")
        {

            f_moveSpeed = -5.0f;
            float f_random;
            f_random = Random.Range(10, 30);
            go_EnemyFront.transform.position = new Vector3(enemy_Front_Transform.transform.position.x + f_random, -4.1f, enemy_Front_Transform.position.z);
            if (f_random >= 20) { EnemyVoice(); }

        }

        enemy_Front_SR.flipX = true;
        enemyCircleCollider.enabled = true;
        enemyBoxCollider.enabled = true;
    }

    private void EnemyVoice()
    {
        FindObjectOfType<AudioManager>().Play("ZombieVoice");
    }

    //Cillisions enter
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && enemyTouch == 0)
        {
            enemyTouch++;
            PlayerController.cl_PlaterController.LoosingHealth();
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            PlayerController.cl_PlaterController.sr_player.color = Color.red;
            // this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
        }
        if (col.gameObject.tag == "DAGGER")
        {
            b_Is_Dead = true;
            f_moveSpeed = 0;
            enemyCircleCollider.enabled = false;
            enemyBoxCollider.enabled = false;
            
            float f_random;
            f_random = Random.Range(100, 500);
            //enemy_Front_Transform.position = new Vector3 (PlayerController.cl_PlaterController.playerTransform.position.x + f_random, enemy_Front_Transform.position.y, enemy_Front_Transform.position.z);
            
            enemy_floatAnimator.SetBool("Zombie_Is_Dead", true);
            FindObjectOfType<AudioManager>().Play("ZombieDead");
            if (f_random >= 400) { Instantiate(go_daggerInst, v3_enemyFront, new Quaternion(0, 0, 0, 0)); }

            //go_EnemyFront.SetActive(true);
            //enemy_Front_SR.flipX = true;
            //go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));
        }
        if (col.gameObject.tag == "Explosion")
        {
            b_Is_Dead = true;
            f_moveSpeed = 0;
            enemyCircleCollider.enabled = false;
            enemyBoxCollider.enabled = false;

            float f_random;
            f_random = Random.Range(100, 500);
          
            enemy_floatAnimator.SetBool("Zombie_Is_Dead", true);
            FindObjectOfType<AudioManager>().Play("ZombieDead");
            if (f_random >= 400) { Instantiate(go_daggerInst, v3_enemyFront, new Quaternion(0, 0, 0, 0)); }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController.cl_PlaterController.sr_player.color = Color.white;
        }
    }




    void Update () {



        if (this.gameObject.name != "Enemy_front" && this.gameObject.name != "Enemy_front_female")
        {
            v3_enemyFront.x = enemy_Front_Transform.position.x;
            v3_enemyFront.y = enemy_Front_Transform.position.y;
            v3_enemyFront.z = enemy_Front_Transform.position.z;


            bool b_startChasing = false;
            //Enemy runs from the front
            if (PlayerController.cl_PlaterController.playerTransform.position.x - 5 < enemy_Front_Transform.position.x && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == false)
            {
                go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));

                //If player is death
                if (PlayerController.cl_PlaterController.b_IsDead == true && enemy_Front_Transform.position.x == PlayerController.cl_PlaterController.playerTransform.position.x)
                {
                    f_moveSpeed = 0;
                }
            }


            //Enemy turns and chasing player
            if (enemy_Front_Transform.position.x + 5 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == false && b_startChasing == false)
            {
                
                f_moveSpeed = 6.0f;
                enemy_Front_SR.flipX = false;
                go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));
                go_EnemyFront.transform.position = new Vector3(enemy_Front_Transform.transform.position.x, enemy_Front_Transform.position.y, enemy_Front_Transform.position.z);
                b_startChasing = true;


                if (enemy_Front_Transform.position.x > PlayerController.cl_PlaterController.playerTransform.position.x + 5 && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == true)
                {
                    b_startChasing = false;
                    if (!b_voise)
                    {

                        EnemyVoice();
                        b_voise = true;
                    }
                }
            }
            //Enemy turns and chasing player
            if (enemy_Front_Transform.position.x > PlayerController.cl_PlaterController.playerTransform.position.x + 5 && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == false)
            {

                f_moveSpeed = -6.0f;
                enemy_Front_SR.flipX = true;
               // go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));
               // go_EnemyFront.transform.position = new Vector3(enemy_Front_Transform.transform.position.x, enemy_Front_Transform.position.y, enemy_Front_Transform.position.z);
                b_startChasing = false;
               
            }


            //Enemy was far away from player -> gets closer to player
            if (enemy_Front_Transform.position.x + 50 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == false && b_startChasing == true)
            {

                f_moveSpeed = 10.0f;
                enemy_Front_SR.flipX = false;
                go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));
                go_EnemyFront.transform.position = new Vector3(enemy_Front_Transform.transform.position.x + 10, enemy_Front_Transform.position.y, enemy_Front_Transform.position.z);

                


            }




            if (enemy_Front_Transform.position.x + 1 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false && b_Is_Dead == false)
            {
                enemyTouch = 0;

            }

            if (PlayerController.cl_PlaterController.b_IsDead == true)
            {
                enemy_floatAnimator.SetBool("If_Player_IsDead", true);

            }


            if (PlayerController.cl_PlaterController.playerTransform.position.x - enemy_Front_Transform.position.x >= 10 && b_Is_Dead == true)
            {

                enemyCircleCollider.enabled = true;
                enemyBoxCollider.enabled = true;
                b_voise = false;
                f_moveSpeed = -5.0f;
                enemy_Front_SR.flipX = true;
                //go_EnemyFront.SetActive(false);
                go_EnemyFront.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));
                //go_EnemyFront.SetActive(true);
                b_Is_Dead = false;
                Destroy(go_EnemyFront);
            }

        }

    }


}
