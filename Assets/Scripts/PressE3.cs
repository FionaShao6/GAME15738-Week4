using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE3 : MonoBehaviour
{
    public EnableDisable chest;
    public GameObject canva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            chest.enabled = true;


        }
    }
}

