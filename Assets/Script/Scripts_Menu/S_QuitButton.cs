using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        StartCoroutine(SoundQuit());
    }
    
    public IEnumerator SoundQuit()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
       
    }
}
