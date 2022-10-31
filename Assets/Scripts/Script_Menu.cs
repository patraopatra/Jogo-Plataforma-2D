using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }
    public void Iniciar()
    {
        Script_Controlador_Pause.pausado = false;
        SceneManager.LoadScene("Main");
        Script_HUD.frutas = 0;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
