using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour
{
    public Slider sizeSlider; 
    public Image brushSpot;
    


    void Start()
    {
        
    }
   void Update()
    {
        
        float size = sizeSlider.value;
        if (size < 0.1f)
        {
            size = 0.1f;  
        }
        //if (size > 1f)
        //{
        //    size = 1f; 
        //}
        brushSpot.transform.localScale = new Vector3(size, size, 1);
    }
}
