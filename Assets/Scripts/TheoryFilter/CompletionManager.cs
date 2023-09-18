using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompletionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endCanvas;
    [SerializeField]
    private PlayerDamage playerDamage;
    [SerializeField]
    private TextToPull textToPull;
    private void OnEnable()
    { TextObjectControl.FinalText += EndCycle; }
    private void OnDisable()
    { TextObjectControl.FinalText -= EndCycle; }
    private void EndCycle(bool isEnd)
    {
        endCanvas.SetActive(isEnd);
        if (playerDamage.Relevant != textToPull.isBlock.Where(c => !c).Count()) {
            endCanvas.GetComponentInChildren<TMP_Text>().text = "There must be something missing..."+ "\nI should go over these clues again.";
            endCanvas.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = "Try Again";
    }
        else
        {
            endCanvas.GetComponentInChildren<TMP_Text>().text = "These theories seem to match the evidence!"+"\nGreat job.";
            endCanvas.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = "Next Level";
        }//checks if the relevant theories is equal to the number that should be passed through, and sets win condition accordingly.
        playerDamage.Health = 5;
        playerDamage.Relevant = 0;
    } 
}