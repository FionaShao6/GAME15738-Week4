using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBlack : MonoBehaviour
{
    public Image brushSpot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeColorToBlack()
    {

        brushSpot.color = Color.black;
    }
}