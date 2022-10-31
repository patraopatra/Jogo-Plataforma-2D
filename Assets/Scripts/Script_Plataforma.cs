using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Plataforma : MonoBehaviour
{
    private float deslocamento = 1.2f;
    private float cont = 0;
    private Vector2 posIni;
    private float raioX = 3;
    private float raioY = 10;
    // Start is called before the first frame update
    void Start()
    {
        posIni = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(cont)*raioX;
        float y = Mathf.Cos(cont)*raioY;

        transform.position = new Vector2(posIni.x + x, posIni.y + y);
        cont += deslocamento * Time.deltaTime;

        if(cont >=2 * Mathf.PI)
        {
            cont = 0;
        }
    }
}
