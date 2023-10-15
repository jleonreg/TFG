using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reinicioProtocolo3 : MonoBehaviour
{
    public programaProtocolo3 prog3;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public movimientoMensaje mM;
    public GameObject movilMN1;
    public GameObject movilMN2;
    public GameObject[] conexionMN1BS1;
    public GameObject[] conexionBS2MN2;
    public GameObject tuboIP;

    public GameObject mensajeBS1MAR1;
    public GameObject mensajeMAR1CMD;
    public GameObject mensajeCMDMAR1;
    public GameObject[] mensajesPC;
    public GameObject mensajeBS2MAR2;
    public GameObject mensajeMAR2CMD;
    public GameObject mensajeCMDMAR2;
    public GameObject mensajeCMDMAR1_2;
    public GameObject mensajeMAR1CMD1_2;

    public void reiniciar(){
        prog3.setPaso(1);
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

    private void reiniciarTubos(){
        tuboIP.transform.localScale = new Vector3(0, 0, 0);
        tuboIP.SetActive(false);
    }

    private void reiniciarMensajes(){
        mensajeBS1MAR1.transform.position = new Vector3(-8.62948f, 0.6f, -4.037878f);
        mensajeBS1MAR1.SetActive(false);
        
        mensajeMAR1CMD.transform.position = new Vector3(-5.998941f, 0.6f, -4.244766f);
        mensajeMAR1CMD.SetActive(false);
        
        mensajeCMDMAR1.transform.position = new Vector3(-0.32f, 0.6f, -2.02f);
        mensajeCMDMAR1.SetActive(false);
        
        mensajeBS2MAR2.transform.position = new Vector3(-6.431f, 0.6f, 0.205f);
        mensajeBS2MAR2.SetActive(false);
        
        mensajeMAR2CMD.transform.position = new Vector3(-4.44f, 0.6f, -1.35f);
        mensajeMAR2CMD.SetActive(false);
        
        mensajeCMDMAR2.transform.position = new Vector3(-0.32f, 0.6f, -2.02f);
        mensajeCMDMAR2.SetActive(false);
        
        mensajeCMDMAR1_2.transform.position = new Vector3(-0.32f, 0.6f, -2.02f);
        mensajeCMDMAR1_2.SetActive(false);
        
        mensajeMAR1CMD1_2.transform.position = new Vector3(-5.998941f, 0.6f, -4.244766f);
        mensajeMAR1CMD1_2.SetActive(false);

        foreach(GameObject elemento in mensajesPC){
            elemento.transform.position = new Vector3(4.070427f, 0.6f, -5.022083f);
            elemento.SetActive(false);
        }
    }
}
