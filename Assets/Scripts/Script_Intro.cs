using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Intro : MonoBehaviour
{
    void ProximaCena()
    {
        SceneManager.LoadScene("Inicio");
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Invoke("ProximaCena", 12);
    }
}
