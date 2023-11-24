using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DropLiquid : MonoBehaviour
{
    public GameObject Liquid;

    private void Start()
    {
        Instantiate(Liquid, gameObject.transform);
    }

}
