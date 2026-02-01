using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_script : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        gameObject.GetComponent<Rigidbody>().mass = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
