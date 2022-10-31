using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tutorial : MonoBehaviour
{

    public GameObject tutorial;

    private void Sumir()
    {
        tutorial.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Escape) 
            || Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("Sumir", 2);
        }
    }
}
