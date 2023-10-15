using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reinicioProtocolo4 : MonoBehaviour
{
    public programaProtocolo4 prog4;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public movimientoMensaje mM;
    public movimientoMensaje mM1;
    public GameObject movilMN1;
    public GameObject movilMN2;
    public GameObject[] conexionMN1BS1;
    public GameObject[] conexionBS2MN2;

    public GameObject mensajeBS1GW1;
    public GameObject mensajeGW1CMD;
    public GameObject mensajeCMDGW1;
    public GameObject[] mensajesPC;
    public GameObject mensajeBS2GW2;
    public GameObject mensajeGW2CMD;
    public GameObject mensajeCMD2_1;
    public GameObject mensajeCMD2_2;
    public GameObject mensajeCMD2;

    public void reiniciar(){
        prog4.setPaso(1);
        cL.setLuz(false);
        temp.reiniciarValores();
        bM.setReinicio();
        mM.setObjetoRecorrido();
        mM1.setObjetoRecorrido();
        
        reiniciarMoviles();
        reiniciarConexiones();
        reiniciarMensajes();
    }

    private void reiniciarMoviles(){
        movilMN1.SetActive(true);
        movilMN1.transform.position = new Vector3(-10.93f, -0.15f, -6.7f);
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

    private void reiniciarMensajes(){
        mensajeBS1GW1.transform.position = new Vector3(-8.62948f, 0.6f, -4.037878f);
        mensajeBS1GW1.SetActive(false);
        
        mensajeGW1CMD.transform.position = new Vector3(-6.041883f, 0.6f, -4.218649f);
        mensajeGW1CMD.SetActive(false);
        
        mensajeCMDGW1.transform.position = new Vector3(-0.1851454f, 0.6f, -1.873028f);
        mensajeCMDGW1.SetActive(false);
        
        mensajeBS2GW2.transform.position = new Vector3(-6.431f, 0.6f, 0.205f);
        mensajeBS2GW2.SetActive(false);
        
        mensajeGW2CMD.transform.position = new Vector3(-4.499f, 0.6f, -1.222f);
        mensajeGW2CMD.SetActive(false);
        
        mensajeCMD2_1.transform.position = new Vector3(-0.1851454f, 0.6f, -1.873028f);
        mensajeCMD2_1.SetActive(false);
        
        mensajeCMD2_2.transform.position = new Vector3(-0.1851454f, 0.6f, -1.873028f);
        mensajeCMD2_2.SetActive(false);
        
        mensajeCMD2.transform.position = new Vector3(-0.1851454f, 0.6f, -1.873028f);
        mensajeCMD2.SetActive(false);

        foreach(GameObject elemento in mensajesPC){
            elemento.transform.position = new Vector3(4.070427f, 0.6f, -5.022083f);
            elemento.SetActive(false);
        }
    }
}
