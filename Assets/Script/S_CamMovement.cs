using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_CamMovement : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x,0,transform.position.z);
    }
}
