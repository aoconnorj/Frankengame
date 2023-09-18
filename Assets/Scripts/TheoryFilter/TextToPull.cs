using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToPull : MonoBehaviour
{
    //this script stores the text that is pulled for each line, the blocking data, and the delay before playing the next line. Each 'string' entry must have a corresponding delay entry and block bool.
    
    public List<string> Lines; //the line to display for the text component

    public List<int> Delay; //the delay for the next spawn on the list. set to 0 for similtaneous spawns

    public List<bool> isBlock; //should this text be blocked? if true, yes.

    [Header("0 Left, 1 Middle, 2 Right")]
    public List<int> spawnPos; //sets the position for spawning the text, 0 is left, 1 is middle, 2 is right. by default, spawns left.
}