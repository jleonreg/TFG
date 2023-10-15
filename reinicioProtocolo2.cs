using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reinicioProtocolo2 : MonoBehaviour
{
    public programaProtocolo2 prog2;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public movimientoMensaje mM;
    public GameObject movilMN1;
    public GameObject[] conexionMN1BS1;
    public GameObject tuboIP1;
    public GameObject tuboIP2;
    public GameObject[] conexionBS2MN2;
    public GameObject movilMN2;

    public GameObject mensajeMN1BS1;
    public GameObject mensajeBS1MAG1;
    public GameObject mensajeMAG1LMA;
    public GameObject mensajeLMAMAG1;
    public GameObject[] mensajesPC;
    public GameObject mensajeMN2BS2;
    public GameObject mensajeBS2MAG2;
    public GameObject mensajeMAG2LMA;
    public GameObject mensajeLMAMAG2;

    public void reiniciar(){
        prog2.setPaso(1);
        cL.setLuz(false);
        temp.reiniciarValores();
        bM.setReinicio();
        mM.setObjetoRecorrido();
        
        reiniciarMoviles();
        reiniciarConexiones();
        reiniciarTubos();
        reiniciarMensajes();
    }

    private void reiniciarMoviles(){
        movilMN1.SetActive(true);
        movilMN1.transform.position = new Vector3(-11.8178f, -0.15f, -8.692863f);
        movilMN2.SetActive(false);
    }

    private void reiniciarConexiones(){
        foreach(GameObject elemento in conexionMN1BS1){
            elemento.transform.localScale = new Vector3(0, 0, 0);
            elemento.SetActive(false);
        }
        foreach(GameObject elemento in conexionBS2MN2){
            elemento.transform.localScale = new Vector3(0, 0, 0);
            elemento.SetActive(false);
        }
    }

    private void reiniciarTubos(){
        tuboIP1.transform.localScale = new Vector3(0, 0, 0);
        tuboIP1.SetActive(false);

        tuboIP2.transform.localScale = new Vector3(0, 0, 0);
        tuboIP2.SetActive(false);
    }

    private void reiniciarMensajes(){
        mensajeMN1BS1.transform.position = new Vector3(-11.59374f, 0.6f, -7.763051f);
        mensajeMN1BS1.SetActive(false);
        
        mensajeBS1MAG1.transform.position = new Vector3(-9.657821f, 0.6f, -3.366999f);
        mensajeBS1MAG1.SetActive(false);
        
        mensajeMAG1LMA.transform.position = new Vector3(-5.888865f, 0.6f, -3.643479f);
        mensajeMAG1LMA.SetActive(false);
        
        mensajeLMAMAG1.transform.position = new Vector3(-1.087818f, 0.6f, -5.740999f);
        mensajeLMAMAG1.SetActive(false);
        
        mensajeMN2BS2.transform.position = new Vector3(-7.93f, 0.6f, 0.3800011f);
        mensajeMN2BS2.SetActive(false);
        
        mensajeBS2MAG2.transform.position = new Vector3(-5.632999f, 0.6f, 1.656001f);
        mensajeBS2MAG2.SetActive(false);
        
        mensajeMAG2LMA.transform.position = new Vector3(-4.158f, 0.6f, -0.9700001f);
        mensajeMAG2LMA.SetActive(false);
        
        mensajeLMAMAG2.transform.position = new Vector3(-1.172f, 0.6f, -5.73f);
        mensajeLMAMAG2.SetActive(false);

        foreach(GameObject elemento in mensajesPC){
            elemento.transform.position = new Vector3(5.193f, 0.6f, -2.24f);
            elemento.SetActive(false);
        }
    }
}
