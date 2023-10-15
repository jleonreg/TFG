using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class velocidadPrograma : MonoBehaviour
{
    float velocidad;
    public TextMeshProUGUI textoVelocidad;

    void Start(){
        velocidad=0.001f;
        actualizarTexto();
    }

    public void aumentarVelocidad(){
        velocidad=velocidad+0.001f;
        actualizarTexto();
    }

    public void disminuitVelocidad(){
        velocidad=velocidad-0.001f;
        actualizarTexto();
    }

    private void actualizarTexto(){
        float vel = velocidad;
        vel=vel*1000;
        textoVelocidad.text = vel.ToString();
    }

    public float getVelocidad(){
        return velocidad;
    }
}
