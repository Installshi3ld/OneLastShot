using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Drip : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300f, ForceMode2D.Force);
        }
    }

    private void Start()
    {
        StartCoroutine(KillAfterTime());
    }

    IEnumerator KillAfterTime()
    {
        yield return new WaitForSeconds(4f);
    }
}