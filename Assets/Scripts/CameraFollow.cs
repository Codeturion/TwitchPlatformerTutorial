using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, 
        offset.z); // Camera follows the player with specified offset position
    }





}
