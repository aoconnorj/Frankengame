using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int Health = 5; //no actual death state yet, can probably just call "FinalText" event or something...
    public int Relevant = 0; //the number of relevant statements currently parsed.
    private void OnTriggerEnter2D(Collider2D collision)
    {
            TextObjectControl textGO = collision.GetComponent<TextObjectControl>();//looks for textcontroller on trigger enter
            if (textGO.isBlock) // deletes text and checks for isblock, damages if true.
            {
                Health--;
            }
            else
            {
                Relevant++;
            }
        Destroy(textGO.gameObject);
    }
}