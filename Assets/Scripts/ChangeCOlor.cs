using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCOlor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        spriteRenderer.color = Random.ColorHSV();
    }
}
