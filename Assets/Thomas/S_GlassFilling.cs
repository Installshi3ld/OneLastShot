using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_GlassFilling : MonoBehaviour
{
    public S_FillingData glassFilling = default(S_FillingData);
    public TextMeshProUGUI glassFillingText;

    public GameObject glass;
    public GameObject liquid;
    public Sprite[] glassLiquid;
    public Sprite[] glassOutside;

    private void Start()
    {
        glassFilling.value = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "drip")
        {
            Destroy(collision.gameObject);
            glassFilling.value = Mathf.Clamp(glassFilling.value + 1, 0, 99);
            glassFillingText.text = glassFilling.value.ToString();

            liquid.GetComponent<SpriteRenderer>().sprite = glassLiquid[(int)glassFilling.value / 25];
            glass.GetComponent<SpriteRenderer>().sprite = glassOutside[(int)glassFilling.value / 25];
        }
    }
}
