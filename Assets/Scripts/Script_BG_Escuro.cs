using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BG_Escuro : MonoBehaviour
{
    public MeshRenderer mr;
    public float speed=0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
