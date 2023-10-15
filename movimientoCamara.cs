using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movimientoCamara : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    private Transform target;
    [Range (0, 1)] public float lerpValue;
    public GameObject camara;

    Vector3 rotacion = new Vector3();
    Vector3 posZero = new Vector3();
    bool alphaZero;
    bool betaZero;
    bool gammaZero;
    float alpha = 0;
    float beta = 0;
    float gamma = 0;


    void Start(){
        target = player.transform;
        rotacion = camara.transform.eulerAngles;
        alphaZero=false;
        betaZero=false;
        gammaZero=false;
    }

    void Update(){
        actualizarRotacion();
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
    }

    public void actualizarRotacion(){
        float rotacionAlpha=0;
        float rotacionBeta=0;
        float rotacionGamma=0;
        
        rotacionAlpha = hacerCuentas(beta, posZero.y);
        rotacionBeta = hacerCuentas(gamma, posZero.z);
        rotacionGamma = hacerCuentas(alpha, posZero.x);

        rotacion = new Vector3(rotacionBeta, -rotacionGamma, -rotacionAlpha);
        camara.transform.rotation = Quaternion.Euler(rotacion);

        rotacion = camara.transform.eulerAngles;
    }

    private float hacerCuentas(float valor1, float valor2){     //Valor1 es el valor que entra por el giroscopio y Valor2 es el valor de la posicion inicial
        if(valor1 >= 0){
            if(valor1 >= valor2){
                return valor1 - valor2;
            }
            else{
                return valor1 - valor2;
            }
        }
        else{
            if(valor1 >= -valor2){
                return valor1 - valor2;
            }
            else{
                return valor1 - valor2;
            }
        }
    }

    public void OnDeviceAlpha(string alphaJSON){
        if(!alphaZero){
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinAlpha = 0;

            if(alphaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinAlpha = alphaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinAlpha = alphaJSON.IndexOf(fin) + fin.Length;
            }

            int indiceInicioAlpha = alphaJSON.IndexOf(inicio) + 1;
            int longitudAlpha = 0;
            string subStringAlpha = "";

            if (indiceInicioAlpha != -1 && indiceFinAlpha != -1){
                longitudAlpha = indiceFinAlpha - indiceInicioAlpha;

                subStringAlpha = alphaJSON.Substring(indiceInicioAlpha, longitudAlpha);
            }

            alpha = float.Parse(subStringAlpha);
            if(alphaJSON.IndexOf(".") >= 0){
                alpha = alpha/10f;
            }
            posZero.x = alpha;
            alphaZero=true;
        }
        else{
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinAlpha = 0;

            if(alphaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinAlpha = alphaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinAlpha = alphaJSON.IndexOf(fin) + fin.Length;
            }

            int indiceInicioAlpha = alphaJSON.IndexOf(inicio) + 1;
            int longitudAlpha = 0;
            string subStringAlpha = "";

            if (indiceInicioAlpha != -1 && indiceFinAlpha != -1){
                longitudAlpha = indiceFinAlpha - indiceInicioAlpha;

                subStringAlpha = alphaJSON.Substring(indiceInicioAlpha, longitudAlpha);
            }

            alpha = float.Parse(subStringAlpha);
            if(alphaJSON.IndexOf(".") >= 0){
                alpha = alpha/10f;
            }
        }
    }

    public void OnDeviceBeta(string betaJSON){
        if(!betaZero){
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinBeta = 0;

            if(betaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinBeta = betaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinBeta = betaJSON.IndexOf(fin) + fin.Length;
            }
        
            int indiceInicioBeta = betaJSON.IndexOf(inicio) + 1;       
            int longitudBeta = 0;     
            string subStringBeta = ""; 

            if (indiceInicioBeta != -1 && indiceFinBeta != -1){
                longitudBeta = indiceFinBeta - indiceInicioBeta;

                subStringBeta = betaJSON.Substring(indiceInicioBeta, longitudBeta);
            }
            beta = float.Parse(subStringBeta);
            beta = beta/10f;
            posZero.y = beta;
            betaZero=true;
        }
        else{
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinBeta = 0;

            if(betaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinBeta = betaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinBeta = betaJSON.IndexOf(fin) + fin.Length;
            }
        
            int indiceInicioBeta = betaJSON.IndexOf(inicio) + 1;       
            int longitudBeta = 0;     
            string subStringBeta = ""; 

            if (indiceInicioBeta != -1 && indiceFinBeta != -1){
                longitudBeta = indiceFinBeta - indiceInicioBeta;

                subStringBeta = betaJSON.Substring(indiceInicioBeta, longitudBeta);
            }
            beta = float.Parse(subStringBeta);
            if(betaJSON.IndexOf(".") >= 0){
                beta = beta/10f;
            }
        }
    }

    public void OnDeviceGamma(string gammaJSON){
        if(!gammaZero){
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinGamma = 0;

            if(gammaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinGamma = gammaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinGamma = gammaJSON.IndexOf(fin) + fin.Length;
            }
    
            int indiceInicioGamma = gammaJSON.IndexOf(inicio) + 1;  
            int longitudGamma = 0;
            string subStringGamma = "";

            if (indiceInicioGamma != -1 && indiceFinGamma != -1){
                longitudGamma = indiceFinGamma - indiceInicioGamma;

                subStringGamma = gammaJSON.Substring(indiceInicioGamma, longitudGamma);
            }

            gamma = float.Parse(subStringGamma);
            gamma = gamma/10f;

            posZero.z = gamma;
            gammaZero=true;
        }
        else{
            string inicio = ":"; // Caracter donde comienza la subcadena
            string fin = null;
            int indiceFinGamma = 0;

            if(gammaJSON.IndexOf(".") >= 0){
                fin = "."; // Caracter donde termina la subcadena
                indiceFinGamma = gammaJSON.IndexOf(fin) + fin.Length + 1;
            }
            else{
                fin = "}"; // Caracter donde termina la subcadena
                indiceFinGamma = gammaJSON.IndexOf(fin) + fin.Length;
            }
    
            int indiceInicioGamma = gammaJSON.IndexOf(inicio) + 1;  
            int longitudGamma = 0;
            string subStringGamma = "";

            if (indiceInicioGamma != -1 && indiceFinGamma != -1){
                longitudGamma = indiceFinGamma - indiceInicioGamma;

                subStringGamma = gammaJSON.Substring(indiceInicioGamma, longitudGamma);
            }

            gamma = float.Parse(subStringGamma);
            if(gammaJSON.IndexOf(".") >= 0){
                gamma = gamma/10f;
            }
        }
    }

}
