using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class S_UmbrellaController : MonoBehaviour
{
    public float vitesseRotation = 5f;
    private Vector3 positionInitiale;
    private float totalRotation = 0f;

    public float gravityDefault;

    public bool isOpen = false;
    public PolygonCollider2D boxCollider;

    public Animator animator;
    public S_UmbrellaOpen umbrellaCanChange;

    public Rigidbody2D rb;
    private S_PlayerGravity gravity;
    void Start()
    {
        gravity.value = gravityDefault;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        positionInitiale = Input.mousePosition;
        umbrellaCanChange.value = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (umbrellaCanChange.value)
            {
                isOpen = !isOpen;
                StopAllCoroutines();
                StartCoroutine(WaitForOpeningClosingUmbrella());
                animator.SetBool("OpenUmbrella", isOpen);
                print(boxCollider.points[0]);
                umbrellaCanChange.value = false;
            }
        }

        if (isOpen)
        {
            rb.gravityScale = 8;
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = 0.5f;
            }
        }
        else
        {
            rb.gravityScale = gravityDefault;
        }

        float rotationX = (Input.mousePosition.x - positionInitiale.x) * vitesseRotation;

        totalRotation += rotationX * Time.deltaTime;
        totalRotation = Mathf.Clamp(totalRotation, -40f, 40f);

        Vector3 newRotation = new Vector3(0f, 0f, -totalRotation);

        transform.rotation = Quaternion.Euler(newRotation);

        positionInitiale = Input.mousePosition;
    }

    IEnumerator WaitForOpeningClosingUmbrella()
    {
        yield return new WaitForSeconds(0.15f);
        boxCollider.enabled = isOpen;
    }
}
