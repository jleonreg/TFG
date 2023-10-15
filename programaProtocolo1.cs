using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class programaProtocolo1 : MonoBehaviour
{
    public velocidadPrograma vP;
    public controlLuz cL;
    public Temporizador temp;
    public modificacionTamanoPC mT;
    public controlPaquetes cP;
    public movimientoMensaje mM;
    public formacionPaquete fP;
    public deformacionPaquete dP;

    public GameObject pc1;  //Variable enlazada con el primer PC
    public GameObject pc2;  //Variable enlazada con el primer PC
    Renderer rendPc1;   //Renderer del primer PC
    Renderer rendPc2;   //Renderer del primer PC

    public GameObject textoPc1; //Variable enlazada con el texto que aparecerá en el primer PC
    public GameObject textoPc2; //Variable enlazada con el texto que aparecerá en el segundo PC

    public GameObject[] formacionPaquete1;  //Variable enlazada con la creación del primer mensaje
    public GameObject[] deformacionPaquete1;  //Variable enlazada con la apertura del primer mensaje
    public GameObject[] formacionPaquete2;  //Variable enlazada con la creación del segundo mensaje
    public GameObject[] deformacionPaquete2;  //Variable enlazada con la apertura del segundo mensaje
    public GameObject[] formacionPaquete3;  //Variable enlazada con la creación del tercer mensaje
    public GameObject[] deformacionPaquete3_1;  //Variable enlazada con la apertura del tercer mensaje
    public GameObject[] deformacionPaquete3_2;  //Variable enlazada con la apertura del tercer mensaje
    public GameObject[] formacionPaquete4;  //Variable enlazada con la creación del cuarto mensaje
    public GameObject[] deformacionPaquete4_1;  //Variable enlazada con la apertura del cuarto mensaje
    public GameObject[] deformacionPaquete4_2;  //Variable enlazada con la apertura del cuarto mensaje
    public GameObject[] formacionPaquete5;  //Variable enlazada con la creación del quinto mensaje
    public GameObject[] deformacionPaquete5_1;  //Variable enlazada con la apertura del quinto mensaje
    public GameObject[] deformacionPaquete5_2;  //Variable enlazada con la apertura del quinto mensaje
    public GameObject[] formacionPaquete6;  //Variable enlazada con la creación del sexto mensaje
    public GameObject[] deformacionPaquete6_1;  //Variable enlazada con la apertura del sexto mensaje
    public GameObject[] deformacionPaquete6_2;  //Variable enlazada con la apertura del sexto mensaje

    public GameObject[] mensajesPaqueteFormado1;  //Vector de mensajes para la formacion del primer mensaje
    public GameObject[] mensajesPaqueteDeformado1;  //Vector de mensajes para la deformacion del primer mensaje
    public GameObject TTLDeformado1;  //Mensaje UDP para la deformacion del primer mensaje
    public GameObject[] mensajesPaqueteFormado2;  //Vector de mensajes para la formacion del segundo mensaje
    public GameObject[] mensajesPaqueteDeformado2;  //Vector de mensajes para la deformacion del segundo mensaje
    public GameObject[] mensajesPaqueteFormado3;  //Vector de mensajes para la formacion del tercer mensaje
    public GameObject[] mensajesPaqueteDeformado3_1;  //Vector de mensajes para la deformacion del tercer mensaje
    public GameObject TTLDeformado3_1;  //Vector de mensajes para la deformacion del tercer mensaje
    public GameObject[] mensajesPaqueteDeformado3_2;  //Vector de mensajes para la deformacion del tercer mensaje
    public GameObject TTLDeformado3_2;  //Vector de mensajes para la deformacion del tercer mensaje
    public GameObject[] mensajesPaqueteFormado4;  //Vector de mensajes para la formacion del cuarto mensaje
    public GameObject[] mensajesPaqueteDeformado4_1;  //Vector de mensajes para la deformacion del cuarto mensaje
    public GameObject TTLDeformado4_1;  //Vector de mensajes para la deformacion del cuarto mensaje
    public GameObject[] mensajesPaqueteDeformado4_2;  //Vector de mensajes para la deformacion del cuarto mensaje
    public GameObject[] mensajesPaqueteFormado5;  //Vector de mensajes para la formacion del quinto mensaje
    public GameObject[] mensajesPaqueteDeformado5_1;  //Vector de mensajes para la deformacion del quinto mensaje
    public GameObject TTLDeformado5_1;  //Vector de mensajes para la deformacion del quinto mensaje
    public GameObject[] mensajesPaqueteDeformado5_2;  //Vector de mensajes para la deformacion del quinto mensaje
    public GameObject TTLDeformado5_2;  //Vector de mensajes para la deformacion del quinto mensaje
    public GameObject[] mensajesPaqueteFormado6;  //Vector de mensajes para la formacion del sexto mensaje
    public GameObject[] mensajesPaqueteDeformado6_1;  //Vector de mensajes para la deformacion del sexto mensaje
    public GameObject TTLDeformado6_1;  //Vector de mensajes para la deformacion del sexto mensaje
    public GameObject[] mensajesPaqueteDeformado6_2;  //Vector de mensajes para la deformacion del sexto mensaje
    public GameObject TTLDeformado6_2;  //Vector de mensajes para la deformacion del sexto mensaje

    public GameObject mensaje1;     //Variable enlazada con el primer mensaje
    public GameObject mensaje2;     //Variable enlazada con el segundo mensaje
    public GameObject mensaje3;     //Variable enlazada con el tercer mensaje
    public GameObject mensaje4;     //Variable enlazada con el cuarto mensaje
    public GameObject mensaje5;     //Variable enlazada con el quinto mensaje
    public GameObject mensaje6;     //Variable enlazada con el sexto mensaje

    public GameObject[] recorridoMensaje1;        //Variable enlazada con el recorrido del primer mensaje
    public GameObject[] recorridoMensaje2;        //Variable enlazada con el recorrido del segundo mensaje
    public GameObject[] recorridoMensaje3_1;        //Variable enlazada con el recorrido del tercer mensaje
    public GameObject[] recorridoMensaje3_2;        //Variable enlazada con el recorrido del tercer mensaje
    public GameObject[] recorridoMensaje4_1;        //Variable enlazada con el recorrido del cuarto mensaje
    public GameObject[] recorridoMensaje4_2;        //Variable enlazada con el recorrido del cuarto mensaje
    public GameObject[] recorridoMensaje5_1;        //Variable enlazada con el recorrido del quinto mensaje
    public GameObject[] recorridoMensaje5_2;        //Variable enlazada con el recorrido del quinto mensaje
    public GameObject[] recorridoMensaje5_3;        //Variable enlazada con el recorrido del quinto mensaje
    public GameObject[] recorridoMensaje6_1;        //Variable enlazada con el recorrido del sexto mensaje
    public GameObject[] recorridoMensaje6_2;        //Variable enlazada con el recorrido del sexto mensaje
    public GameObject[] recorridoMensaje6_3;        //Variable enlazada con el recorrido del sexto mensaje

    int paso;


    void Start(){
        rendPc1 = pc1.GetComponent<Renderer>();
        rendPc2 = pc2.GetComponent<Renderer>();
        paso=1;

        temp.reiniciarValores();
    }

    void Update(){
        if(cL.getLuz()){
            switch(paso){
                case 1:
                    paso = mT.tamanoPc(rendPc1, textoPc1, paso);
                    break;
                //Primer TTL envio
                case 2:
                    paso = fP.formarPaquete(formacionPaquete1, mensajesPaqueteFormado1, paso);
                    break;
                case 3:
                    paso = mM.moverMensaje(formacionPaquete1, mensaje1, recorridoMensaje1, paso);
                    break;
                case 4:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete1);
                        dP.iniciarValores(deformacionPaquete1.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete1, mensajesPaqueteDeformado1, 2, TTLDeformado1, paso);
                    break;
                //Primer TTL recepcion
                case 5:
                    paso = fP.formarPaquete(formacionPaquete2, mensajesPaqueteFormado2, paso);
                    break;
                case 6:
                    paso = mM.moverMensaje(formacionPaquete2, mensaje2, recorridoMensaje2, paso);
                    break;
                case 7:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete2);
                        dP.iniciarValores(deformacionPaquete2.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete2, mensajesPaqueteDeformado2, 1, null, paso);
                    break;
                //Segundo TTL envio
                case 8:
                    paso = mT.tamanoPc(rendPc1, textoPc1, paso);
                    break;
                case 9:
                    paso = fP.formarPaquete(formacionPaquete3, mensajesPaqueteFormado3, paso);
                    break;
                case 10:
                    paso = mM.moverMensaje(formacionPaquete3, mensaje3, recorridoMensaje3_1, paso);
                    Debug.Log(mensaje3.transform.position);
                    break;
                case 11:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete3_1);
                        dP.iniciarValores(deformacionPaquete3_1.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete3_1, mensajesPaqueteDeformado3_1, 2, TTLDeformado3_1, paso);
                    break;
                case 12:
                    paso = mM.moverMensaje(formacionPaquete3, mensaje3, recorridoMensaje3_2, paso);
                    break;
                case 13:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete3_2);
                        dP.iniciarValores(deformacionPaquete3_2.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete3_2, mensajesPaqueteDeformado3_2, 2, TTLDeformado3_2, paso);
                    break;
                //Segundo TTL recepcion
                case 14:
                    paso = fP.formarPaquete(formacionPaquete4, mensajesPaqueteFormado4, paso);
                    break;
                case 15:
                    paso = mM.moverMensaje(formacionPaquete4, mensaje4, recorridoMensaje4_1, paso);
                    break;
                case 16:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete4_1);
                        dP.iniciarValores(deformacionPaquete4_1.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete4_1, mensajesPaqueteDeformado4_1, 2, TTLDeformado4_1, paso);
                    break;
                case 17:
                    paso = mM.moverMensaje(formacionPaquete4, mensaje4, recorridoMensaje4_2, paso);
                    break;
                case 18:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete4_2);
                        dP.iniciarValores(deformacionPaquete4_2.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete4_2, mensajesPaqueteDeformado4_2, 1, null, paso);
                    break;
                //Tercer TTL envio
                case 19:
                    paso = mT.tamanoPc(rendPc1, textoPc1, paso);
                    break;
                case 20:
                    paso = fP.formarPaquete(formacionPaquete5, mensajesPaqueteFormado5, paso);
                    break;
                case 21:
                    paso = mM.moverMensaje(formacionPaquete5, mensaje5, recorridoMensaje5_1, paso);
                    break;
                case 22:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete5_1);
                        dP.iniciarValores(deformacionPaquete5_1.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete5_1, mensajesPaqueteDeformado5_1, 2, TTLDeformado5_1, paso);
                    break;
                case 23:
                    paso = mM.moverMensaje(formacionPaquete5, mensaje5, recorridoMensaje5_2, paso);
                    break;
                case 24:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete5_2);
                        dP.iniciarValores(deformacionPaquete5_2.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete5_2, mensajesPaqueteDeformado5_2, 2, TTLDeformado5_2, paso);
                    break;
                case 25:
                    paso = mM.moverMensaje(formacionPaquete5, mensaje5, recorridoMensaje5_3, paso);
                    break;
                //Tercer TTL recepcion
                case 26:
                    paso = mT.tamanoPc(rendPc2, textoPc2, paso);
                    break;
                case 27:
                    paso = fP.formarPaquete(formacionPaquete6, mensajesPaqueteFormado6, paso);
                    break;
                case 28:
                    paso = mM.moverMensaje(formacionPaquete6, mensaje6, recorridoMensaje6_1, paso);
                    break;
                case 29:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete6_1);
                        dP.iniciarValores(deformacionPaquete6_1.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete6_1, mensajesPaqueteDeformado6_1, 2, TTLDeformado6_1, paso);
                    break;
                case 30:
                    paso = mM.moverMensaje(formacionPaquete6, mensaje6, recorridoMensaje6_2, paso);
                    break;
                case 31:
                    if(!dP.getPaquetesActivados()){
                        cP.activarPaquetes(deformacionPaquete6_2);
                        dP.iniciarValores(deformacionPaquete6_2.Length - 1);
                    }
                    paso = dP.deformarPaquete(deformacionPaquete6_2, mensajesPaqueteDeformado6_2, 2, TTLDeformado6_2, paso);
                    break;
                case 32:
                    paso = mM.moverMensaje(formacionPaquete6, mensaje6, recorridoMensaje6_3, paso);
                    break;
                case 33:
                    paso = mT.tamanoPc(rendPc1, textoPc1, paso);
                    break;
            }
        }
    }

    public void setPaso(int pasoCircuito){
        paso=pasoCircuito;
    }
}
