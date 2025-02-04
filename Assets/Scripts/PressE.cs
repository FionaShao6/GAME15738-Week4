using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{
    public float speed=5f;
    public EnableDisable chest;
    public GameObject canva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed  * Time.deltaTime;
        transform.position = pos;


        if(Input.GetKeyDown(KeyCode.E))
        {
            chest.enabled = true;


        }
    }
}
