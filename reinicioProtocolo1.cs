using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reinicioProtocolo1 : MonoBehaviour
{
    public programaProtocolo1 prog1;
    public controlLuz cL;
    public Temporizador temp;

    public GameObject textoPc1;
    public GameObject textoPc2;

    public GameObject tablaEnrutamientoPc1;
    public GameObject tablaEnrutamientoPc2;
    public GameObject tablaEnrutamientoRouter1;
    public GameObject tablaEnrutamientoRouter2;

    public GameObject pc1;
    public GameObject pc2;

    public GameObject[] paquetesPrimerMensajeEntrada;
    public GameObject[] paquetesPrimerMensajeLlegada;
    public GameObject[] paquetesSegundoMensajeEntrada;
    public GameObject[] paquetesSegundoMensajeLlegada;
    public GameObject[] paquetesTercerMensajeEntrada;
    public GameObject[] paquetesTercerMensajeLlegada1;
    public GameObject[] paquetesTercerMensajeLlegada2;
    public GameObject[] paquetesCuartoMensajeEntrada;
    public GameObject[] paquetesCuartoMensajeLlegada1;
    public GameObject[] paquetesCuartoMensajeLlegada2;
    public GameObject[] paquetesQuintoMensajeEntrada;
    public GameObject[] paquetesQuintoMensajeLlegada1;
    public GameObject[] paquetesQuintoMensajeLlegada2;
    public GameObject[] paquetesSextoMensajeEntrada;
    public GameObject[] paquetesSextoMensajeLlegada1;
    public GameObject[] paquetesSextoMensajeLlegada2;
    public GameObject mensaje1;
    public GameObject mensaje2;
    public GameObject mensaje3;
    public GameObject mensaje4;
    public GameObject mensaje5;
    public GameObject mensaje6;

    public void reiniciar(){
        prog1.setPaso(1);
        cL.setLuz(false);
        temp.reiniciarValores();

        reiniciarPCs();
        reiniciarTablasEnrutamiento();
        reiniciarPaquetes(paquetesPrimerMensajeEntrada);
        reiniciarPaquetes(paquetesPrimerMensajeLlegada);

        reiniciarPaquetes(paquetesSegundoMensajeEntrada);
        reiniciarPaquetes(paquetesSegundoMensajeLlegada);

        reiniciarPaquetes(paquetesTercerMensajeEntrada);
        reiniciarPaquetes(paquetesTercerMensajeLlegada1);
        reiniciarPaquetes(paquetesTercerMensajeLlegada2);

        reiniciarPaquetes(paquetesCuartoMensajeEntrada);
        reiniciarPaquetes(paquetesCuartoMensajeLlegada1);
        reiniciarPaquetes(paquetesCuartoMensajeLlegada2);

        reiniciarPaquetes(paquetesQuintoMensajeEntrada);
        reiniciarPaquetes(paquetesQuintoMensajeLlegada1);
        reiniciarPaquetes(paquetesQuintoMensajeLlegada2);

        reiniciarPaquetes(paquetesSextoMensajeEntrada);
        reiniciarPaquetes(paquetesSextoMensajeLlegada1);
        reiniciarPaquetes(paquetesSextoMensajeLlegada2);

        reiniciarMensajes();
    }

    private void reiniciarPCs(){
        textoPc1.SetActive(false);
        textoPc2.SetActive(false);
        pc1.transform.localScale = new Vector3(1,1,1);
        pc2.transform.localScale = new Vector3(1,1,1);
    }

    private void reiniciarTablasEnrutamiento(){
        tablaEnrutamientoPc1.SetActive(false);
        tablaEnrutamientoPc2.SetActive(false);
        tablaEnrutamientoRouter1.SetActive(false);
        tablaEnrutamientoRouter2.SetActive(false);
    }

    private void reiniciarPaquetes(GameObject[] paquetes){
        foreach(GameObject paquete in paquetes){
            paquete.SetActive(false);
        }
    }

    private void  reiniciarMensajes(){
        mensaje1.SetActive(false);
        mensaje1.transform.position = new Vector3(-7.85f, 0.6f, -4.03f);
        mensaje2.SetActive(false);
        mensaje2.transform.position = new Vector3(-5.66f, 0.6f, -1.96f);
        mensaje3.SetActive(false);
        mensaje3.transform.position = new Vector3(-7.85f, 0.6f, -4.03f);
        mensaje4.SetActive(false);
        mensaje4.transform.position = new Vector3(-2.636f, 0.6f, -1.96f);
        mensaje5.SetActive(false);
        mensaje5.transform.position = new Vector3(-7.85f, 0.6f, -4.03f);
        mensaje6.SetActive(false);
        mensaje6.transform.position = new Vector3(1.115f, 0.6f, -3.789f);
    }
}
