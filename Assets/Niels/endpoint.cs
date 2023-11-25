using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D col2d;
    public Rigidbody2D playerRef;

    public Canvas canvas;

    public S_PlayerSpeed playerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("helloend");
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        //Stop player velocity
        //getPlayerCurrentScore and select a end sound
        //Play end sound array
        yield return new WaitForSeconds(3);

        canvas.gameObject.SetActive(true);
        //Redirect to next level menu
        Time.timeScale = 0;
    }

    void SelectEndSound(int pscore)
    {
        if(pscore >= 2)
        {
            //High
        }
        else if(pscore >= 1){
            //Avg
        }
        else { 
            //Bad
        }
    }
}
