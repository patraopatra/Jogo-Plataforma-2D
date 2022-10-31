using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Camera : MonoBehaviour
{
    public GameObject pc;
    private float offsetY = 1;
    private float offsetX = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(pc.transform.position.x + offsetX, pc.transform.position.y + offsetY, -10);
        transform.position = pos;
    }
}
