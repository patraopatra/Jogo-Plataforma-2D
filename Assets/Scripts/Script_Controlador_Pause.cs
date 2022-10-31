using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Controlador_Pause : MonoBehaviour
{
    static public bool pausado = false;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (pausado == false)
        {
            Time.timeScale = 1;
        }

        // Pausar o game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausado = !pausado;
            if (pausado == true)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                menu.SetActive(pausado);
            }
            else
            {
                Cursor.visible = false;
                Time.timeScale = 1;
                menu.SetActive(pausado);
            }
        }
    }
}
