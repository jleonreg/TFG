using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creacionMensajes : MonoBehaviour
{
    public velocidadPrograma vP;
    public void crearMensaje(GameObject mensaje, float valorX, float valorY, float valorZ){
        mensaje.SetActive(true);

        float mensajeX = mensaje.transform.localScale.x;
        float mensajeY = mensaje.transform.localScale.y;
        float mensajeZ = mensaje.transform.localScale.z;
        if(mensaje.transform.localScale.x <= valorX)
            mensajeX = mensaje.transform.localScale.x + vP.getVelocidad();
        if(mensaje.transform.localScale.y <= valorY)
            mensajeY = mensaje.transform.localScale.y + vP.getVelocidad()*3;
        if(mensaje.transform.localScale.z <= valorZ)
            mensajeZ = mensaje.transform.localScale.z + vP.getVelocidad();
        mensaje.transform.localScale = new Vector3(mensajeX, mensajeY, mensajeZ);       
    }

    public bool comprobarMensaje(GameObject mensaje, float valorX, float valorY, float valorZ){
        bool mensajeEntero = true;
        if(mensaje.transform.localScale.x <= valorX)
            mensajeEntero = false;
        if(mensaje.transform.localScale.y <= valorY)
            mensajeEntero = false;
        if(mensaje.transform.localScale.z <= valorZ)
            mensajeEntero = false;

        return mensajeEntero;
    }
}
