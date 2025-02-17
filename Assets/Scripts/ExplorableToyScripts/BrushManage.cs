using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrushManage : MonoBehaviour
{
    public Image brushSpot;  //This is the brush example on the bottom left.
    public GameObject brushPrefab;  // This is the player controlled Brush Prefab
    public Transform canvasTransform; // Canvas posistion

    void Update()
    {
       
    }
    public void Draw(Vector2 position)
    {
        GameObject newBrush = Instantiate(brushPrefab, position, Quaternion.identity, canvasTransform);
        newBrush.transform.localScale = brushSpot.transform.localScale; // Inherit size

        SpriteRenderer sr = newBrush.GetComponent<SpriteRenderer>(); //Get SpriteRenderer
        if (sr != null)
        {
            sr.color = brushSpot.color; //Inherit color
            Instantiate(brushPrefab, position, Quaternion.identity);//Colone prefab
        }


    }
    

}