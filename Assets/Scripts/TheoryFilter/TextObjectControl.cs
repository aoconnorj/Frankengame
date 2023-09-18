using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextObjectControl : MonoBehaviour
{
    public static event Action<bool> FinalText;
    public bool isBlock; //if true, this text object should be blocked by the blockers
    public bool isLast; //if true, this is the last in the textToPull list.
    private TMP_Text textGO;
    private void Awake()
    {
        textGO = gameObject.GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {/*if (isBlock == true)
        {textGO.color = Color.red;}
        else
        {textGO.color = Color.green;}*/
    } //sets text you block to red, text you let through to green.
    private void OnEnable()
    {TextObjectMovement.Collision += Destruct;}
    private void OnDisable()
    {TextObjectMovement.Collision -= Destruct;}
    private void Destruct (GameObject destructGO)
    {
        if (destructGO == gameObject)
        {
            Destroy(gameObject);
            Debug.Log("DESTROYED " + gameObject);
        }//destroys this text game object if event GO matches this one
    }
    private void OnDestroy()
    { if(isLast == true)
        {
            FinalText.Invoke(true);//calls finalText event when this is the last text GO (used for resetting scene).
        } }
}