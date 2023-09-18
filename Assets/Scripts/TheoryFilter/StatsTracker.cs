using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    [SerializeField]
    private TextToPull textToPull;
    [SerializeField]
    private PlayerDamage playerDamage;
    private TMP_Text textGO;
    private void Awake()
    {
        textGO = gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        textGO.text = "Focus: " + playerDamage.Health  + "\nRelevant Theories: " + playerDamage.Relevant + "/" + textToPull.isBlock.Where(c => !c).Count();
    }//shows hp from playerdamage script, and shows current theories accepted out of total non-block theories
}