using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_f : MonoBehaviour {

    public static Wave_f cl_Wave_f;

    public GameObject go_Wave_f;
    private Transform playerTransform;
    public Animator wave_fAnimator;

    void Start () {
        playerTransform = GameObject.Find("Player").transform;
    }
	
	
	void Update () {

        if (playerTransform.position.x - go_Wave_f.transform.position.x >= 20)
        {
            go_Wave_f.transform.position = new Vector3(go_Wave_f.transform.position.x + 8.5f, 0, playerTransform.position.z);
        }

        if (go_Wave_f.transform.position.x < playerTransform.position.x)
        {
            go_Wave_f.transform.position = new Vector3(go_Wave_f.transform.position.x + 0.05f, -4.1f, playerTransform.position.z);
        }

        if (go_Wave_f.transform.position.x - playerTransform.position.x >= 0)
        {
            Debug.Log("PLAYER DEAD");
            PlayerController.cl_PlaterController.b_IsDead = true;
            wave_fAnimator.SetBool("If_Player_IsDead", true);
        }

    }
}
