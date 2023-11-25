using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_GlassFilling : MonoBehaviour
{
    public S_FillingData glassFilling = default(S_FillingData);
    public TextMeshProUGUI glassFillingText;

    public GameObject glass, liquid, glassLiquidBack, glassLiquidBaackContour;
    public Sprite[] glassLiquid;
    public Sprite[] glassOutside;
    public Sprite[] liquidBack;
    public Sprite[] liquidBaackContour;

    public int megotAmount = 0;
    public List<Transform> anchorMegot;

    public GameObject iceAnchor, lemonAnchor, chipsAnchor;
    public bool gotIce, gotLemon, gotChips;

    float[] tmpPos = { -2.1f, -0.98f, 0.77f, 2.55f };
    private void Start()
    {
        glassFilling.value = 0;
    }

    private void Update()
    {
        print(megotAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "drip")
        {
            Destroy(collision.gameObject);
            if(glassFillingText)
                glassFillingText.text = glassFilling.value.ToString();

            var liquidSprite = liquid.GetComponent<SpriteRenderer>();
            liquidSprite.sprite = glassLiquid[(int)glassFilling.value];
            liquidSprite.color = collision.gameObject.GetComponent<S_Drip>().dripColor;
            glass.GetComponent<SpriteRenderer>().sprite = glassOutside[(int)glassFilling.value];

            glassLiquidBack.GetComponent<SpriteRenderer>().sprite = liquidBack[(int)glassFilling.value];
            glassLiquidBack.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<S_Drip>().dripColor;

            glassLiquidBaackContour.GetComponent<SpriteRenderer>().sprite = liquidBaackContour[(int)glassFilling.value];

            /*
            iceAnchor.transform.position = new Vector3(iceAnchor.transform.position.x,
                tmpPos[(int)glassFilling.value],
                iceAnchor.transform.position.z);

            lemonAnchor.transform.position = new Vector3(lemonAnchor.transform.position.x,
                tmpPos[(int)glassFilling.value],
                lemonAnchor.transform.position.z);

            if(tmpPos[(int)glassFilling.value] > 1)
                chipsAnchor.transform.position = new Vector3(chipsAnchor.transform.position.x,
                tmpPos[(int)glassFilling.value] / 2,
                chipsAnchor.transform.position.z);
            
            print(glassFilling.value);
        */
            glassFilling.value = Mathf.Clamp(glassFilling.value + 1, 0, 4);
        }
        if(collision.gameObject.tag == "megot")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            if(megotAmount < anchorMegot.Count)
            {
                collision.gameObject.transform.position = anchorMegot[megotAmount].position;
                collision.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
                megotAmount++;
            }
        }


        if(collision.gameObject.tag == "ice")
        {
            gotIce = true;
            resetCollision(collision, iceAnchor);
        }

        if (collision.gameObject.tag == "lemon")
        {
            gotLemon = true;
            resetCollision(collision, lemonAnchor);
        }
        if (collision.gameObject.tag == "chips")
        {
            gotLemon = true;
            resetCollision(collision, chipsAnchor);
        }

    }

    void resetCollision(Collider2D collision, GameObject obj)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        collision.gameObject.transform.position = obj.transform.position;
        obj.transform.parent = obj.transform;
        collision.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
    }
}
