using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
    public bool isBlocking = false;
    private SpriteRenderer sr;
    private Color baseColor;

    [SerializeField]
    private KeyCode blockerKey; //set in inspector for each blocker.
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        baseColor = sr.color; //gets base color for showing if blocking is active.
    }
    void Update()
    {
        if (Input.GetKey(blockerKey))
        {
            sr.color = baseColor;
            isBlocking = true;
        }
        else
        {
            sr.color = Color.grey;
            isBlocking = false;
        }//visual feedback for if blocking is active on a blocker.
    }
}
