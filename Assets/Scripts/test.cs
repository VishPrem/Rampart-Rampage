using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    public GameObject game; 
    public UnityEvent<int> testEvent;
    // Start is called before the first frame update
    void Start()
    {
        game.GetComponent<Light>().color = Color.red;
        game.transform.position = new Vector3(20, 50, 40);
        gameObject.transform.position = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
