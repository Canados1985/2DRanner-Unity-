using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    public GameObject go_Moon;

    private Transform playerTransform;
    public Transform moonTransform;

    void Start () {

        playerTransform = GameObject.Find("Player").transform;
        moonTransform = GameObject.Find("Moon").transform;
    }


    void Update()
    {

    }
}
