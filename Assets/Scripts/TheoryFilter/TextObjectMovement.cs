using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextObjectMovement : MonoBehaviour
{
    public static event Action<GameObject> Collision; // call whenever blocker hits an object
    public float moveSpeed = 2f;

    private void Update()
    {
        Vector3 movement = Vector3.down * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }//moves text down at spawn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blocker"))
        {
            BlockerController blocker = collision.GetComponent<BlockerController>();//looks for blocker component on collision
            //Debug.Log("Collided with a blocker!");
            if (blocker != null && blocker.isBlocking) // Handle collision with blocking object, calls event with the text gameobject
            {
                Collision.Invoke(gameObject);
            }
        }
    }
}