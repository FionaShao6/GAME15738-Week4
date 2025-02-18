using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour

{
    public GameObject BrushPrefab;  //Drag in the brush prefab
    public Image brushSpot;         //Example preview in the lower left corner
    public float minDistance = 0.01f; // Minimum distance between two points


    GameObject currentLine; //Store all the points currently drawn
    Vector3 lastPointPosition;//Stores the position of the last drawn point

    private bool canDraw = false;  // Is drawing allowed?

    void Update()
    {
        if (!canDraw) return;
        if (Input.GetMouseButtonDown(0)) //if the left mouse button is pressed
        {

            StartNewLine();//start drawing
        }

        if (Input.GetMouseButton(0)) //if the left mouse button is held down,
        {
           
            UpdateLineDrawing();//Continuous drawing
        }
    }
    public void EnableDrawing()
    {
        canDraw = true;  // Allow drawing
        Debug.Log("Now you can start to draw!");
    }

    void StartNewLine()
    {
        

        // Let currentLine belong to a fixed parent object
        currentLine = new GameObject("Line");
       
        
        Vector3 mousePos = GetMouseWorldPosition();



        ///Instantiate first, then manually set the parent to ensure it does not detach from the currentLine
        GameObject firstPoint = Instantiate(BrushPrefab, mousePos, Quaternion.identity);
       

        firstPoint.transform.SetParent(currentLine.transform, true); // The second parameter true makes it keep world coordinates

        // Make sure the scaling is correct
        firstPoint.transform.localScale = brushSpot.transform.localScale;

        //Make sure the colors are correct
        SpriteRenderer firstRenderer = firstPoint.GetComponent<SpriteRenderer>();
        if (firstRenderer != null)
        {
            firstRenderer.color = brushSpot.color;
        }

        lastPointPosition = mousePos;

    }


    void UpdateLineDrawing()
    {
        Vector3 currentMousePos = GetMouseWorldPosition();
        //If the distance between the current point and the last point is greater than minDistance,
        ////create a new point
        if (Vector3.Distance(currentMousePos, lastPointPosition) > minDistance)
        {
            CreatePoint(currentMousePos);
            lastPointPosition = currentMousePos;
        }
    }

    void CreatePoint(Vector3 position)
    {
        //Instantiate a new brush point at the specified position and set its parent
        GameObject newBrush = Instantiate(BrushPrefab, position, Quaternion.identity, currentLine.transform);
        newBrush.transform.SetParent(currentLine.transform); // Add to current line
        newBrush.transform.localScale = brushSpot.transform.localScale; //Inherited size

        SpriteRenderer brushRenderer = newBrush.GetComponent<SpriteRenderer>();//Get components at runtime
        if (brushRenderer != null)
        {
            brushRenderer.color = brushSpot.color; // Inherited color
        }

    }

    Vector3 GetMouseWorldPosition()
    {
        //get the mouse position inscreen coordinates
        Vector3 mousePos = Input.mousePosition;
        //Caculate the mouse position in world coordinates
        mousePos.z = -Camera.main.transform.position.z;//Make it consistent with the camera's z
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

   
}

