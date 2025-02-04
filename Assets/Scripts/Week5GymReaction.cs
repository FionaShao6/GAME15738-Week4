using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5GymReaction : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical")* speed * Time.deltaTime;
        transform.position = pos;
    }
}
