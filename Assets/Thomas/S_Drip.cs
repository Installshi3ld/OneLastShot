using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Drip : MonoBehaviour
{
    public Color dripColor;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite.color = dripColor;
    }

}
