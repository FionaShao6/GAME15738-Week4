using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRed : MonoBehaviour
{
    public Image brushSpot;
    // Start is called before the first frame update
    

    // Update is called once per frame
    
    public void ChangeColorToRed()
    {

        brushSpot.color = Color.red;
    }
}
