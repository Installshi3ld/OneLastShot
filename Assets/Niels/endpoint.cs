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
    public AudioSource winSound;
    public AudioSource HighSound;
    public AudioSource MedSound;
    public AudioSource BadSound;

    public AudioClip[] HighClips;
    public AudioClip[] MedClips;
    public AudioClip[] BadClips;

    public GameObject parentArm;
    public GameObject childGlass;

    public Animator ArmAnimator;
    public Animator DoigtAnimator;
    public Animator GameObjectAnimator;

    public S_PlayerSpeed playerSpeed;
    void Start()
    {
        HighSound.clip = HighClips[Random.Range(0, HighClips.Length)];
        MedSound.clip = MedClips[Random.Range(0, MedClips.Length)];
        BadSound.clip = BadClips[Random.Range(0, BadClips.Length)];
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
            childGlass.transform.parent = parentArm.transform;
            ArmAnimator.SetTrigger("animate");
            DoigtAnimator.SetTrigger("animate");
            GameObjectAnimator.SetTrigger("animate");

            playerSpeed.value =  0;

            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        
        //Play end sound array
        winSound.Play();
        tmpScore = CalculateFirstScore();
        SelectEndSound(tmpScore);
        yield return new WaitForSeconds(3);

        canvas.gameObject.SetActive(true);
// STOP TIME HERE
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
            score1 += 2;
            activeBool++;
        }
        if (insideGlass.gotChips == true)
        {
            score1 -= 1;
            activeBool++;
        }

        score1 = score1 + insideGlass.megotAmount * (-1);

        score2 = score1 * 100 / (activeBool + (insideGlass.megotAmount)/1);

        return score2;
    }

    void SelectEndSound(float pscore)
    {
        print(score2);
        if (pscore >= 75)
        {
            //High
            print("highscore");
            HighSound.Play();
        }
        else if(pscore >= 50){
            //Avg
            print("medium");
            MedSound.Play();
        }
        else {
            //Bad
            print("bad");
            BadSound.Play();
        }
    }
}
