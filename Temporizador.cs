using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    float tiempoInicio;
    float tiempoFin;
    bool iniciado;
    bool finalizado;
    
    void Start(){
        tiempoInicio = 0;
        tiempoFin = 0;
        iniciado = false;
        finalizado = false;
    }

    public void reiniciarValores(){
        tiempoInicio = 0;
        tiempoFin = 0;
        iniciado = false;
        finalizado = false;
    }

    public void iniciarTemporizador(float tiempo){
        if(!iniciado){
            finalizado=false;
            tiempoInicio = Time.deltaTime;
            tiempoFin = tiempoInicio + tiempo;
            iniciado=true;
        }
        tiempoInicio += Time.deltaTime;
        if(tiempoInicio > tiempoFin){
            finalizado=true;
        }
    }

    public bool getIniciado(){
        return iniciado;
    }

    public bool getFinalizado(){
        return finalizado;
    }
}
