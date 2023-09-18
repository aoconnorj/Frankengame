using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    private TextToPull textToPull;
    public GameObject textPrefab;
    public Transform[] spawnTargets;
    public float spawnDelay;
    private int currentIndex;

    public void StartSpawns()
    {
        StopAllCoroutines();
        textToPull = GetComponent<TextToPull>();
        spawnDelay = textToPull.Delay[0];
        currentIndex = 0;
        StartCoroutine(SpawnObjectsWithDelay());
        
    }
    private IEnumerator SpawnObjectsWithDelay()
    {
        for (currentIndex = 0; currentIndex < textToPull.Lines.Count; currentIndex++)
        {
            SpawnObject();
            yield return new WaitForSeconds(textToPull.Delay[currentIndex]);
        }
        Debug.Log("End of Lines Reached!");
    }//spawns text using spawnDelay in order of first to last in list.
    private void SpawnObject()
    {
        Vector3 spawnPosition = spawnTargets[textToPull.spawnPos[currentIndex]].position;
        GameObject textSpawn = Instantiate(textPrefab, spawnPosition, Quaternion.identity);
        textSpawn.GetComponentInChildren<TMP_Text>().text = textToPull.Lines[currentIndex];
        textSpawn.GetComponent<TextObjectControl>().isBlock = textToPull.isBlock[currentIndex];
        spawnDelay = textToPull.Delay[currentIndex];
        Debug.Log("Delay" +textToPull.Delay[currentIndex]);
        if (currentIndex + 1 == textToPull.Lines.Count)
        {
            textSpawn.GetComponent<TextObjectControl>().isLast = true;
            //Debug.Log("Last is" + textToPull.Lines[currentIndex]);
        }
    }//spawns text and gives it the data of the text's index as stored on TextToPull
}