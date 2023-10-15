using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class programaProtocolo4 : MonoBehaviour
{
    float tamConexion = 0.15f;
    float tamMensajeX = 0.3f;
    float tamMensajeY = 0.2f;
    float tamMensajeZ = 0.1f;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public creacionConexiones cC;
    public creacionMensajes cM;
    public movimientoMensaje mM;
    public movimientoMensaje mM1;
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
    
    //Envío mensaje BS1 - GW1
    public GameObject[] recorridoMensajeBS1GW1;

    //Creación mensaje GW1
    public GameObject mensajeGW1;

    //Envío mensaje GW1 - CMD
    public GameObject[] recorridoMensajeGW1CMD;

    //Creación mensaje CMD
    public GameObject mensajeCMD1;

    //Envío mensaje CMD - GW1
    public GameObject[] recorridoMensajeCMDGW1;

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

    //Envío mensaje BS2 - GW2
    public GameObject[] recorridoMensajeBS2GW2;

    //Creación mensaje GW2
    public GameObject mensajeGW2;

    //Envío mensaje GW2 - CMD
    public GameObject[] recorridoMensajeGW2CMD;

    //Creación mensaje CMD2_
    public GameObject mensajeCMD2_1;
    public GameObject mensajeCMD2_2;
    bool llegadoCMD2_1;
    bool llegadoCMD2_2;

    //Envío mensaje CMD - GW2
    public GameObject[] recorridoMensajeCMDGW2;
    int paso1;
    int paso2;

    //Creación mensaje CMD2
    public GameObject mensajeCMD2;

    //Envío mensajes CN - MN2
    public GameObject[] rutaMensajesMN2;
    public GameObject caminoCNMN2;
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
        llegadoCMD2_1 = false;
        llegadoCMD2_2 = false;
        paso1=0;
        paso2=0;
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
                    paso = mM.moverMensaje(null, mensajeBS1, recorridoMensajeBS1GW1, paso);
                    break;
                case 4:
                    cM.crearMensaje(mensajeGW1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeGW1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 5:
                    paso = mM.moverMensaje(null, mensajeGW1, recorridoMensajeGW1CMD, paso);
                    break;
                case 6:
                    cM.crearMensaje(mensajeCMD1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 7:
                    paso = mM.moverMensaje(null, mensajeCMD1, recorridoMensajeCMDGW1, paso);
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
                        movMov.movimientoMovil(movilMN2, -11.84f, -0.15f, -1.27f);    

                    if(movMov.comprobarMovil(movilMN2, -11.84f, -0.15f, -1.27f))
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
                    paso = mM.moverMensaje(null, mensajeBS2, recorridoMensajeBS2GW2, paso);
                    break;
                case 15:
                    cM.crearMensaje(mensajeGW2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeGW2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 16:
                    paso = mM.moverMensaje(null, mensajeGW2, recorridoMensajeGW2CMD, paso);
                    break;
                case 17:
                    cM.crearMensaje(mensajeCMD2_1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD2_1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        llegadoCMD2_1 = true;
                    
                    cM.crearMensaje(mensajeCMD2_2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD2_2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        llegadoCMD2_2 = true;
                    if(llegadoCMD2_1 && llegadoCMD2_2)
                        paso++;
                    break;
                case 18:
                    if(paso1 != 19)
                        paso1 = mM1.moverMensaje(null, mensajeCMD2_1, recorridoMensajeCMDGW1, paso);
                    if(paso2 != 19)
                        paso2 = mM.moverMensaje(null, mensajeCMD2_2, recorridoMensajeCMDGW2, paso);

                    if(paso1 == 19 && paso2 == 19)
                        paso++;
                    break;
                case 19:
                    cM.crearMensaje(mensajeCMD2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeCMD2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 20:
                    paso = mM.moverMensaje(null, mensajeCMD2, recorridoMensajeCMDGW2, paso);
                    break;
                case 21:
                    animMN2.SetBool("Cargando", true);
                    paso++;
                    break;
                case 22:
                    if(!inicioRuta2){
                        bM.setPosicionSiguienteMensaje(caminoCNMN2);
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

