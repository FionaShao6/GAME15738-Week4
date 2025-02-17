using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGreen : MonoBehaviour
{
    public Image brushSpot;
    // Start is called before the first frame update
   
    public void ChangeColorToGreen()
    {

        brushSpot.color = Color.green;
    }
}