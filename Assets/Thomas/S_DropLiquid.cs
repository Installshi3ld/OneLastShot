using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DropLiquid : MonoBehaviour
{
    public GameObject Liquid;

    private void Start()
    {
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(Liquid, gameObject.transform.position, Quaternion.identity);
        }
    }



}
