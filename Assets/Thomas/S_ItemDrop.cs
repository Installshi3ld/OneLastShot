using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class S_ItemDrop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f, ForceMode2D.Force);
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
