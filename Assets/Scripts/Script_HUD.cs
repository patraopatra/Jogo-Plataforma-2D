using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_HUD : MonoBehaviour
{
    public static AudioSource somCome;
    public static int frutas = 0;
    public static Text texto;
    private void Start()
    {
        somCome = GetComponent<AudioSource>();
        texto = GameObject.Find("Texto_Frutas").GetComponent<Text>();
    }

    public static void addFrutas(int p)
    {
        frutas += p;
        somCome.Play();
        texto.text = "Frutas: " + frutas;
    }
}
