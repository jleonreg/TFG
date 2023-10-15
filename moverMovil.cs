using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverMovil : MonoBehaviour
{
    public velocidadPrograma vP;

    public void movimientoMovil(GameObject movil, float valorX, float valorY, float valorZ){
        float movilX = movil.transform.position.x;
        float movilY = movil.transform.position.y;
        float movilZ = movil.transform.position.z;
        if(!comprobarValor(movil.transform.position.x, valorX))
            movilX = calcularValor(movil.transform.position.x, valorX);
        if(!comprobarValor(movil.transform.position.y, valorY))
            movilY = calcularValor(movil.transform.position.y, valorY);
        if(!comprobarValor(movil.transform.position.z, valorZ))
            movilZ = calcularValor(movil.transform.position.z, valorZ);
        movil.transform.position = new Vector3(movilX, movilY, movilZ);     
    }

    public bool comprobarMovil(GameObject movil, float valorX, float valorY, float valorZ){
        bool movilEntero = true;
        if(!comprobarValor(movil.transform.position.x, valorX))
            movilEntero = false;
        if(!comprobarValor(movil.transform.position.y, valorY))
            movilEntero = false;
        if(!comprobarValor(movil.transform.position.z, valorZ))
            movilEntero = false;

        return movilEntero;
    }

    private bool comprobarValor(float pos, float valor){
        bool valorMovil=false;
        if(pos > 0){
            if(valor > 0){
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
            else{
                valorMovil = valor + pos > -0.1 && valor + pos < 0.1;
            }
        }
        else{
            if(valor > 0){
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
            else{
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
        }
        return valorMovil;
    }

    private float calcularValor(float pos, float valor){
        float movil = 0;
        if(pos > 0){
            if(valor > 0){
                if(pos > valor)
                    movil = pos - vP.getVelocidad();
                else
                    movil = pos + vP.getVelocidad();
            }
            else{
                movil = pos - vP.getVelocidad();
            }
        }
        else{
            if(valor > 0){
                movil = pos + vP.getVelocidad();
            }
            else{
                if(pos > valor)
                    movil = pos - vP.getVelocidad();
                else{
                    movil = pos + vP.getVelocidad();
                }
            }
        }
        return movil;
    }
}
