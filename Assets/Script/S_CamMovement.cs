using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CamMovement : MonoBehaviour
{
    public S_PlayerSpeed camSpeed;
    private void Update()
    {
        Vector3 desiredPos = new Vector3(transform.position.x + 1,transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, camSpeed.value * Time.deltaTime);
    }
}
