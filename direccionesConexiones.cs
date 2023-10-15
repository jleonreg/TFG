using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direccionesConexiones : MonoBehaviour
{
    public GameObject[] TablaConexion;

    public void mostrarTablaConexion(){
        bool mostrados=false;

        for(int i=0; i<TablaConexion.Length; i++){
            if(TablaConexion[i].activeSelf){
                mostrados=true;
            }
        }

        if(!mostrados){
            for(int i=0; i<TablaConexion.Length; i++){
                TablaConexion[i].SetActive(true);
            }
        }
        else{
            for(int i=0; i<TablaConexion.Length; i++){
                TablaConexion[i].SetActive(false);
            }
        }
    }
}
