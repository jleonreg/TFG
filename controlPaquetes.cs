using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPaquetes : MonoBehaviour{
    public void desactivarPaquetes(GameObject[] mensajesPaquete, int paquete){
        for(int i=0; i<mensajesPaquete.Length; i++){
            if(i!=paquete && mensajesPaquete[paquete].activeSelf){
                mensajesPaquete[i].SetActive(false);
            }
        }
    }

    public void desactivarTodosPaquetes(GameObject[] mensajesPaquete){
        for(int i=0; i<mensajesPaquete.Length; i++){
            if(mensajesPaquete[i].activeSelf){
                mensajesPaquete[i].SetActive(false);
            }
        }
    }

    public void activarPaquetes(GameObject[] mensajesPaquete){
        for(int i=0; i<mensajesPaquete.Length; i++){
            if(!mensajesPaquete[i].activeSelf){
                mensajesPaquete[i].SetActive(true);
            }
        }
    }
}
