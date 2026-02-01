using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    private int x;
    void Start()
    {
        x = PlayerPrefs.GetInt("savednum");
    }

    void Update()
    {
        x++;
        Debug.Log(x);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("savednum", x);
    }
}
