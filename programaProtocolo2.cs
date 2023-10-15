using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class programaProtocolo2 : MonoBehaviour
{
    float tamConexion = 0.15f;
    float tamTubo = 0.6f;
    float tamMensajeX = 0.3f;
    float tamMensajeY = 0.2f;
    float tamMensajeZ = 0.1f;

    public busMensajes bM;
    public controlLuz cL;
    public Temporizador temp;
    public creacionConexiones cC;
    public creacionMensajes cM;
    public movimientoMensaje mM;
    public moverMovil movMov;

    //Conexion MN1 - BS1
    public GameObject conexionMN1;
    public GameObject unionMN1BS1;
    public GameObject conexionBS1;

    //Creación mensaje BS1
    public GameObject mensajeBS1;

    //Envío mensaje BS1 - MAG1
    public GameObject[] recorridoMensajeBS1MAG1;

    //Creación mensaje MAG1
    public GameObject mensajeMAG1;

    //Envío mensaje MAG1 - LMA
    public GameObject[] recorridoMensajeMAG1LMA;

    //Creación mensaje LMA
    public GameObject mensajeLMA1;

    //Envío mensaje LMA - MAG1
    public GameObject[] recorridoMensajeLMAMAG1;

    //Creación tubo IP - IP 1
    public GameObject tuboIP1;
    
    //Envios mensajes PC - MN1
    public GameObject[] grupoMensajes;
    public GameObject[] rutaMensajesMN1;
    bool inicioRuta1;
    
    //Movimiento MN1 a posicion MN2
    public GameObject movilMN1;
    public GameObject movilMN2;
    public Animator animMN1;
    public Animator animMN2;
    bool primerMovimiento;
    bool segundoMovimiento;
    
    //Conexion MN2 - BS2
    public GameObject conexionMN2;
    public GameObject unionMN2BS2;
    public GameObject conexionBS2;

    //Creación mensaje BS2
    public GameObject mensajeBS2;
    
    //Envío mensaje BS2 - MAG2
    public GameObject[] recorridoMensajeBS2MAG2;
    
    //Creación mensaje MAG2
    public GameObject mensajeMAG2;
    
    //Envío mensaje MAG2 - LMA
    public GameObject[] recorridoMensajeMAG2LMA;
    
    //Creación mensaje LMA
    public GameObject mensajeLMA2;
    
    //Envío mensaje LMA - MAG2
    public GameObject[] recorridoMensajeLMAMAG2;
    
    //Creación tubo IP - IP 2
    public GameObject tuboIP2;
    
    //Envios mensajes PC - MN2
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
        bM.setMoviles(movilMN1, movilMN2);
        bM.setGrupoMensajes(grupoMensajes);
        bM.setPosInicialMensajesDatos(new Vector3(5.193f, 0.7326394f, -2.24f));
    }

    void Update(){
        if(cL.getLuz()){
            switch(paso){
                case 1:
                    cC.crearConexion(conexionMN1, tamConexion);
                    cC.crearConexion(conexionBS1, tamConexion);
                    temp.iniciarTemporizador(1f);
                    if(temp.getFinalizado()){
                        cC.crearUnion(unionMN1BS1, 0.1f, 1.110683f, 0.1f);
                    }
                    if(cC.comprobarUnionCreada(unionMN1BS1, 0.1f, 1.110683f, 0.1f)){
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
                    paso = mM.moverMensaje(null, mensajeBS1, recorridoMensajeBS1MAG1, paso);
                    break;
                case 4:
                    cM.crearMensaje(mensajeMAG1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeMAG1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 5:
                    paso = mM.moverMensaje(null, mensajeMAG1, recorridoMensajeMAG1LMA, paso);
                    break;
                case 6:
                    cM.crearMensaje(mensajeLMA1, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeLMA1, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 7:
                    paso = mM.moverMensaje(null, mensajeLMA1, recorridoMensajeLMAMAG1, paso);
                    break;
                case 8:
                    cC.crearUnion(tuboIP1, tamTubo, tamTubo, tamTubo);
                    if(cC.comprobarUnionCreada(tuboIP1, tamTubo, tamTubo, tamTubo))
                        paso++;
                    break;
                case 9:
                    animMN1.SetBool("Cargando", true);
                    paso++;
                    break;
                case 10:
                    bM.setPosicionSiguienteMensaje(tuboIP1);
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
                case 11:
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
                case 12:
                    if(!primerMovimiento)
                        movMov.movimientoMovil(movilMN2, -15.27f, -0.15f, -2.14f);    

                    if(movMov.comprobarMovil(movilMN2, -15.27f, -0.15f, -2.14f))
                        primerMovimiento=true;

                    if(primerMovimiento && !segundoMovimiento)
                        movMov.movimientoMovil(movilMN2, -8.59f, -0.15f, 0.01f);

                    if(movMov.comprobarMovil(movilMN2, -8.59f, -0.15f, 0.01f))
                        segundoMovimiento=true;
                        
                    if(movMov.comprobarMovil(movilMN2, -8.597805f, -0.15f, 0.01213694f))
                        paso++;
                    break;
                case 13: 
                    cC.crearConexion(conexionMN2, tamConexion);
                    cC.crearConexion(conexionBS2, tamConexion);
                    temp.iniciarTemporizador(1f);
                    if(temp.getFinalizado()){
                        cC.crearUnion(unionMN2BS2, 0.1f, 0.8f, 0.1f);
                    }
                    if(cC.comprobarUnionCreada(unionMN2BS2, 0.1f, 0.8f, 0.1f)){
                        paso++;
                        temp.reiniciarValores();
                    }
                    break;
                case 14:
                    cM.crearMensaje(mensajeBS2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeBS2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 15:
                    paso = mM.moverMensaje(null, mensajeBS2, recorridoMensajeBS2MAG2, paso);
                    break;
                case 16:
                    cM.crearMensaje(mensajeMAG2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeMAG2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 17:
                    paso = mM.moverMensaje(null, mensajeMAG2, recorridoMensajeMAG2LMA, paso);
                    break;
                case 18:
                    cM.crearMensaje(mensajeLMA2, tamMensajeX, tamMensajeY, tamMensajeZ);
                    if(cM.comprobarMensaje(mensajeLMA2, tamMensajeX, tamMensajeY, tamMensajeZ))
                        paso++;
                    break;
                case 19:
                    paso = mM.moverMensaje(null, mensajeLMA2, recorridoMensajeLMAMAG2, paso);
                    break;
                case 20:
                    cC.crearUnion(tuboIP2, tamTubo, tamTubo, tamTubo);
                    if(cC.comprobarUnionCreada(tuboIP2, tamTubo, tamTubo, tamTubo))
                        paso++;
                    break;
                case 21:
                    animMN2.SetBool("Cargando", true);
                    paso++;
                    break;
                case 22:
                    if(!inicioRuta2){
                        bM.setPosicionSiguienteMensaje(tuboIP2);
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

