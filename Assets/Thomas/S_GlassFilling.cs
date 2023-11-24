using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GlassFilling : MonoBehaviour
{
    public S_FillingData glassFilling = default(S_FillingData);
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
            glassFilling.value += 1;
        }
    }
}
