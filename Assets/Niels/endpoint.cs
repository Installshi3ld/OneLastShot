using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D col2d;
    public Rigidbody2D playerRef;

    public Canvas canvas;

    public S_GlassFilling insideGlass;
    private int score1 = 0;
    private int activeBool = 0;
    private float score2 = 0.0f;
    private float tmpScore;

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
        tmpScore = CalculateFirstScore();
        SelectEndSound(tmpScore);
        yield return new WaitForSeconds(3);

        canvas.gameObject.SetActive(true);
        //Redirect to next level menu
        Time.timeScale = 0;
    }

    float CalculateFirstScore()
    {
        if (insideGlass.gotIce == true)
        {
            score1 += 2;
            activeBool++;
        }
        if (insideGlass.gotLemon == true)
        {
            score1 += 3;
            activeBool++;
        }
        if (insideGlass.gotChips == true)
        {
            score1 -= 1;
            activeBool++;
        }

        score1 = score1 + insideGlass.megotAmount * (-1);

        score2 = score1 * 100 / (activeBool + insideGlass.megotAmount);

        return score2;
    }

    void SelectEndSound(float pscore)
    {
        //Score based on Bool Ice/Lemon/Chips and megot int
        // Ice = 2, Lemon = 3, Chips = -1, and each int of megot = -1
        //Score_1*100/(NumberOfTrueBools+megotInt)
        print(score2);
        if (pscore >= 75)
        {
            //High
            print("highscore");
        }
        else if(pscore >= 50){
            //Avg
            print("madium");
        }
        else {
            //Bad
            print("bad");
        }
    }
}
