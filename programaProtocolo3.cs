using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class programaProtocolo3 : MonoBehaviour
{
    float tamConexion = 0.15f;
    float tamMensajeX = 0.3f;
    float tamMensajeY = 0.2f;
    float tamMensajeZ = 0.1f;
    float tamTubo = 0.5f;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public creacionConexiones cC;
    public creacionMensajes cM;
    public movimientoMensaje mM;
    public moverMovil movMov;

    public GameObject movilMN1;
    public GameObject movilMN2;
    public Animator animMN1;
    public Animator animMN2;

    //Conexion MN1 - BS1
    public GameObject conexionMN1;
    public GameObject unionMN1BS1;
    public GameObject conexionBS1;

    //Creación mensaje BS1
    public GameObject mensajeBS1;
    
    //Envío mensaje BS1 - MAR1
    public GameObject[] recorridoMensajeBS1MAR1;

    //Creación mensaje MAR1
    public GameObject mensajeMAR1;

    //Envío mensaje MAR1 - CMD
    public GameObject[] recorridoMensajeMAR1CMD;

    //Creación mensaje CMD
    public GameObject mensajeCMD1;

    //Envío mensaje CMD - MAR1
    public GameObject[] recorridoMensajeCMDMAR1;

    //Envío mensajes CN - MN1
    public GameObject caminoCNMN1;
    public GameObject[] grupoMensajes;
    public GameObject[] rutaMensajesMN1;
    bool inicioRuta1;

    //Movimiento MN1 a posicion MN2
    bool primerMovimiento;
    bool segundoMovimiento;

    //Conexión MN2 - BS2
    public GameObject conexionMN2;
    public GameObject unionMN2BS2;
    public GameObject conexionBS2;

    //Creación BS2
    public GameObject mensajeBS2;

    //Envío mensaje BS2 - MAR2
    public GameObject[] recorridoMensajeBS2MAR2;

    //Creación mensaje MAR2
    public GameObject mensajeMAR2;

    //Envío mensaje MAR2 - CMD
    public GameObject[] recorridoMensajeMAR2CMD;

    //Creación mensaje CMD
    public GameObject mensajeCMD2;

    //Envío mensaje CMD - MAR2
    public GameObject[] recorridoMensajeCMDMAR2;

    //Creación mensaje MAR1_2
    public GameObject mensajeMAR1_2;

    //Envío mensaje CMD - MAR1_2
    public GameObject[] recorridoMensajeCMDMAR1_2;

    //Creación mensaje CMD
    public GameObject mensajeCMD1_2;

    //Envío mensaje MAR1_2 - CMD
    public GameObject[] recorridoMensajeMAR1CMD1_2;

    //Creación tunel IP-IP
    public GameObject tuboIP;

    //Envío mensajes CN - MN2
    public GameObject[] rutaMensajesMN2;
    bool inicioRuta2;


    int paso;

    // Start is called before the first frame update
    void Start(){
        paso=1;
        inicioRuta1=false;
        inicioRuta2=false;
        primerMovimiento=false;
        segundoMovimiento=false;
        bM.setGrupoMensajes(grupoMensajes);
        bM.setMoviles(movilMN1, movilMN2);
        bM.setPosInicialMensajesDatos(new Vector3(4.070427f, 0.6f, -5.022083f));
    }

    void Update(){
        if(cL.getLuz()){
            switch(paso){
                case 1:
                    cC.crearConexion(conexionMN1, tamConexion);
                    cC.crearConexion(conexionBS1, tamConexion);
                    temp.iniciarTemporizador(1f);
                    if(temp.getFinalizado()){
                        cC.crearUnion(unionMN1BS1, 0.1f, 0.6888379f, 0.1f);
                    }
                    if(cC.comprobarUnionCreada(unionMN1BS1, 0.1f, 0.6888379f, 0.1f)){
                        paso++;
                        temp.reiniciarValores();
                    }
                    break;
                case 2:
                    cM.crearMensaje(mensajeBS1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeBS1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 3:
                    paso = mM.moverMensaje(null, mensajeBS1, recorridoMensajeBS1MAR1, paso);
                    break;
                case 4:
                    cM.crearMensaje(mensajeMAR1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeMAR1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 5:
                    paso = mM.moverMensaje(null, mensajeMAR1, recorridoMensajeMAR1CMD, paso);
                    break;
                case 6:
                    cM.crearMensaje(mensajeCMD1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 7:
                    paso = mM.moverMensaje(null, mensajeCMD1, recorridoMensajeCMDMAR1, paso);
                    break;
                case 8:
                    animMN1.SetBool("Cargando", true);
                    paso++;
                    break;
                case 9:
                    bM.setMoviles(movilMN1, movilMN2);
                    bM.setPosicionSiguienteMensaje(caminoCNMN1);
                    bM.setEnvioInformacion(true);
                    if(!inicioRuta1){
                        bM.setRutaMensajes1(rutaMensajesMN1);
                        inicioRuta1=true;
                    }
                    if(bM.getNumeroMensajesLlegados1() == 1){
                        animMN1.SetBool("Cargando", false);
                        animMN1.SetBool("Video", true);
                    }
                    if(bM.getNumeroMensajes() <= 0){
                        movilMN1.SetActive(false);
                        movilMN2.SetActive(true);
                        animMN1.SetBool("Cargando", true);
                        animMN2.SetBool("Cargando", true);
                        animMN1.SetBool("Video", false);
                        bM.setNumeroMensajes(4);
                        paso++;
                    }
                    break;
                case 10:
                    cC.eliminarConexion(conexionMN1, 0f);
                    cC.eliminarConexion(conexionBS1, 0f);
                    temp.iniciarTemporizador(1f);
                    if(temp.getFinalizado()){
                        cC.eliminarUnion(unionMN1BS1, 0f, 0f, 0f);
                    }
                    if(cC.comprobarUnionEliminada(unionMN1BS1, 0f, 0f, 0f)){
                        paso++;
                        temp.reiniciarValores();
                    }
                    break;
                case 11:
                    if(!primerMovimiento)
                        movMov.movimientoMovil(movilMN2, -12.59f, -0.15f, -1.69f);    

                    if(movMov.comprobarMovil(movilMN2, -12.59f, -0.15f, -1.69f))
                        primerMovimiento=true;

                    if(primerMovimiento && !segundoMovimiento)
                        movMov.movimientoMovil(movilMN2, -10.37f, -0.15f, -0.82f);

                    if(movMov.comprobarMovil(movilMN2, -10.37f, -0.15f, -0.82f))
                        segundoMovimiento=true;
                        
                    if(movMov.comprobarMovil(movilMN2, -10.37f, -0.15f, -0.82f))
                        paso++;
                    break;
                case 12:
                    cC.crearConexion(conexionMN2, tamConexion);
                    cC.crearConexion(conexionBS2, tamConexion);
                    temp.iniciarTemporizador(1f);
                    if(temp.getFinalizado()){
                        cC.crearUnion(unionMN2BS2, 0.1f, 0.6611307f, 0.1f);
                    }
                    if(cC.comprobarUnionCreada(unionMN2BS2, 0.1f, 0.6611307f, 0.1f)){
                        paso++;
                        temp.reiniciarValores();
                    }
                    break;
                case 13: 
                    cM.crearMensaje(mensajeBS2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeBS2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 14:
                    paso = mM.moverMensaje(null, mensajeBS2, recorridoMensajeBS2MAR2, paso);
                    break;
                case 15:
                    cM.crearMensaje(mensajeMAR2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeMAR2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 16:
                    paso = mM.moverMensaje(null, mensajeMAR2, recorridoMensajeMAR2CMD, paso);
                    break;
                case 17:
                    cM.crearMensaje(mensajeCMD2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 18:
                    paso = mM.moverMensaje(null, mensajeCMD2, recorridoMensajeCMDMAR2, paso);
                    break;
                case 19:
                    cM.crearMensaje(mensajeMAR1_2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeMAR1_2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 20:
                    paso = mM.moverMensaje(null, mensajeMAR1_2, recorridoMensajeCMDMAR1_2, paso);
                    break;
                case 21:
                    cM.crearMensaje(mensajeCMD1_2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD1_2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 22:
                    paso = mM.moverMensaje(null, mensajeCMD1_2, recorridoMensajeMAR1CMD1_2, paso);
                    break;
                case 23:
                    cC.crearUnion(tuboIP, tamTubo, tamTubo, 0.2894201f);
                    if(cC.comprobarUnionCreada(tuboIP, tamTubo, tamTubo, 0.2894201f))
                        paso++;
                    break;
                case 24:
                    animMN2.SetBool("Cargando", true);
                    paso++;
                    break;
                case 25:
                    if(!inicioRuta2){
                        bM.setPosicionSiguienteMensaje(tuboIP);
                        bM.setRutaMensajes2(rutaMensajesMN2);
                        inicioRuta2=true;
                    }
                    if(bM.getNumeroMensajesLlegados2() == 1){
                        animMN2.SetBool("Cargando", false);
                        animMN2.SetBool("Video", true);
                    }
                    break;
            }
            if(bM.getEnvioInformacion()){
                bM.envioMensajesContinuo();
            }
        }
    }

    public void setPaso(int pasoCircuito){
        paso=pasoCircuito;
    }

}

