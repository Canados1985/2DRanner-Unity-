using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBox : MonoBehaviour {

    public static PostBox cl_PostBox;

    public GameObject go_PostBox;

    public Transform PostBoxTransform;
    private Transform playerTransform;

    void Start () {
        PostBoxTransform.GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").transform;
    }
	
	
	void Update () {
        if (playerTransform.position.x - PostBoxTransform.position.x >= 50)
        {
            float f_random;
            f_random = Random.Range(30, 50);
            go_PostBox.transform.position = new Vector3(PostBoxTransform.position.x + f_random + f_random, PostBoxTransform.position.y, PostBoxTransform.position.z);
        }
    }
}
