using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public static Explosion cl_Explosion;

    public GameObject go_Explosion;
    public GameObject go_flameInst;

    public Transform playerTransform;
    public Transform explosionTransform;

    public Vector3 v3_Explosion;

    public float timeLeft;
    private float f_explosionTouch;

    void Start () {
        
        if (this.gameObject.name != "explosion")
        {
            go_Explosion.name = "explosion_clone";
            go_flameInst = GameObject.Find("flame");
            go_Explosion.transform.position = new Vector3(explosionTransform.position.x, -3.55f, explosionTransform.position.z);
            timeLeft = 0.8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && f_explosionTouch == 0 && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            f_explosionTouch++;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            PlayerController.cl_PlaterController.LoosingHealth();
            PlayerController.cl_PlaterController.sr_player.color = Color.red;
        }

        if (collision.gameObject.tag == "Enemy" && f_explosionTouch == 0 && Enemy_Front.cl_Enemy_Front.b_Is_Dead == false)
        {
            f_explosionTouch++;

            Enemy_Front.cl_Enemy_Front.b_Is_Dead = true;
            Enemy_Front.cl_Enemy_Front.f_moveSpeed = 0;
            Enemy_Front.cl_Enemy_Front.enemyCircleCollider.enabled = false;
            Enemy_Front.cl_Enemy_Front.enemyBoxCollider.enabled = false;

            Enemy_Front.cl_Enemy_Front.enemy_floatAnimator.SetBool("Zombie_Is_Dead", true);
            FindObjectOfType<AudioManager>().Play("ZombieDead");
            
        }
    }


    private void Update()
    {
        if (explosionTransform.position.x + 1 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            f_explosionTouch = 0;
        }
    }

    private void FixedUpdate()
    {


        v3_Explosion.x = explosionTransform.position.x;
        v3_Explosion.y = explosionTransform.position.y;
        v3_Explosion.z = explosionTransform.position.z;



        timeLeft -= Time.deltaTime;

            if (timeLeft <= 0 && this.gameObject.name != "explosion")
            {
            Instantiate(go_flameInst, v3_Explosion, new Quaternion(0, 0, 0, 0));
            Destroy(go_Explosion);
            }
        

    }
}
