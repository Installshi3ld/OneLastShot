using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UmbrellaController : MonoBehaviour
{
    public float vitesseRotation = 5f;
    private Vector3 positionInitiale;
    private float totalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        positionInitiale = Input.mousePosition;
    }

    void Update()
    {
        float rotationX = (Input.mousePosition.x - positionInitiale.x) * vitesseRotation;

        totalRotation += rotationX * Time.deltaTime;
        totalRotation = Mathf.Clamp(totalRotation, -40f, 40f);

        Vector3 newRotation = new Vector3(0f, 0f, -totalRotation);

        transform.rotation = Quaternion.Euler(newRotation);

        positionInitiale = Input.mousePosition;
    }
}
