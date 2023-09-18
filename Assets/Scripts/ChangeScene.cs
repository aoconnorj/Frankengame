using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    void OnEnable()
    {
        Countdown.TimesUp += SceneChange;
    }

    void OnDisable()
    {
        Countdown.TimesUp -= SceneChange;
    }

    // Update is called once per frame
    public void SceneChange()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
       
        SceneManager.LoadScene(y + 1);
        Debug.Log("hello");
    }
}
