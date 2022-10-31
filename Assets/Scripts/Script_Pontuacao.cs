using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Pontuacao : MonoBehaviour
{
    public static Text textoPerdeu;

    // Start is called before the first frame update
    void Start()
    {
        textoPerdeu = GameObject.Find("Pontuacao").GetComponent<Text>();
        textoPerdeu.text = "Frutas: " + Script_HUD.frutas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
