using System.Collections;
using UnityEngine;
using Gamekit3D;


public class BoxCollisionController : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") {
        playerController.Die();
        }
    }



}