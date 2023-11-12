using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxController : MonoBehaviour
{
    public Animator boxAnimator;


    private void Start()
    {
        // Get the Animator component attached to this GameObject
        boxAnimator = GetComponent<Animator>();
    }

    // This method is called when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            // Start rotating the box
            boxAnimator.SetBool("IsNear", true);
        }
    }

    // This method is called when something exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop rotating the box
            boxAnimator.SetBool("IsNear", false);
        }
    }
}