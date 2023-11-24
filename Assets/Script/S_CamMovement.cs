using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_CamMovement : MonoBehaviour
{
    public S_PlayerSpeed playerSpeed;

    private void Update()
    {
        transform.position += Vector3.right * playerSpeed.value * Time.deltaTime;
    }
}
