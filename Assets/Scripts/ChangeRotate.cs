using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
