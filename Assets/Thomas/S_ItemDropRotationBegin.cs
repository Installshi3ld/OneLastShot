using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemDropRotationBegin : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(7f);
    }
}
