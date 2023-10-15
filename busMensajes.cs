using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busMensajes : MonoBehaviour
{
    Vector3 posInicialMensajesDatos = new Vector3(0,0,0);

    GameObject posicionSiguienteMensaje;

    GameObject[] grupoMensajes;
    int numMensaje1;
    int numMensaje2;
    bool envioInformacion;
    bool mensaje1;
    bool mensaje2;
    bool terminadoMensaje1;
    bool terminadoMensaje2;
    public movimientoMensaje mM1;
    public movimientoMensaje mM2;
    GameObject[] rutaMensajesAux1;
    GameObject[] rutaMensajesAux2;
    GameObject[] rutaMensajesAux3;
    GameObject[] rutaMensajesAux4;
    GameObject movilMN1;
    GameObject movilMN2;
    int numeroMensajes;
    int numeroMensajesLlegados1;
    int numeroMensajesLlegados2;

    // Start is called before the first frame update
    void Start(){
        numMensaje1=0;
        numMensaje2=4;
        mensaje1=false;
        mensaje2=true;
        envioInformacion=false;
        numeroMensajes=4;
        terminadoMensaje1 = false;
        terminadoMensaje2 = false;
        movilMN1=null;
        movilMN2=null;
        numeroMensajesLlegados1=0;
        numeroMensajesLlegados2=0;
    }

    public void setReinicio(){
        numMensaje1=0;
        numMensaje2=4;
        mensaje1=false;
        mensaje2=true;
        envioInformacion=false;
        numeroMensajes=4;
        terminadoMensaje1 = false;
        terminadoMensaje2 = false;
        movilMN1=null;
        movilMN2=null;
        numeroMensajesLlegados1=0;
        numeroMensajesLlegados2=0;
    }

    public int getNumeroMensajesLlegados1(){
        return numeroMensajesLlegados1;
    }

    public int getNumeroMensajesLlegados2(){
        return numeroMensajesLlegados2;
    }

    public void setGrupoMensajes(GameObject[] grupoMen){
        grupoMensajes = grupoMen;
    }

    public void setPosicionSiguienteMensaje(GameObject objeto){
        posicionSiguienteMensaje = objeto;
    }

    public void setPosInicialMensajesDatos(Vector3 posicion){
        posInicialMensajesDatos = posicion;
    }

    public bool getEnvioInformacion(){
        return envioInformacion;
    }

    public void setRutaMensajes1(GameObject[] ruta){
        rutaMensajesAux1 = ruta;
        rutaMensajesAux2 = ruta;
    }

    public void setRutaMensajes2(GameObject[] ruta){
        rutaMensajesAux3 = ruta;
        rutaMensajesAux4 = ruta;
    }

    public void setEnvioInformacion(bool envInfo){
        envioInformacion = envInfo;
    }

    public void setMoviles(GameObject MN1, GameObject MN2){
        movilMN1=MN1;
        movilMN2=MN2;
    }

    public int getNumeroMensajes(){
        return numeroMensajes;
    }

    public void setNumeroMensajes(int numMensajes){
        numeroMensajes = numMensajes;
    }

    public void envioMensajesContinuo(){
        if(rutaMensajesAux3==null && rutaMensajesAux4==null){
            if(mensaje2){
                mM1.moverMensaje(null, grupoMensajes[numMensaje1], rutaMensajesAux1, numMensaje1);
                terminadoMensaje1 = false;
                comprobarMensaje1Pos0();
            }
            if(mensaje1){
                mM2.moverMensaje(null, grupoMensajes[numMensaje2], rutaMensajesAux2, numMensaje2);
                terminadoMensaje2 = false;
                comprobarMensaje2Pos0();
            }
        }
        else{
            if(!terminadoMensaje1){
                if(mensaje2){
                    mM1.moverMensaje(null, grupoMensajes[numMensaje1], rutaMensajesAux1, numMensaje1);
                    terminadoMensaje1 = false;
                    comprobarMensaje1Pos0();
                }
            }
            else{
                if(mensaje2){
                    mM1.moverMensaje(null, grupoMensajes[numMensaje1], rutaMensajesAux3, numMensaje1);
                    comprobarMensaje3Pos0();
                }
            }
            if(!terminadoMensaje2){
                if(mensaje1){
                    mM2.moverMensaje(null, grupoMensajes[numMensaje2], rutaMensajesAux2, numMensaje2);
                    terminadoMensaje2 = false;
                    comprobarMensaje2Pos0();
                }
            }
            else{
                if(mensaje1){
                    mM2.moverMensaje(null, grupoMensajes[numMensaje2], rutaMensajesAux4, numMensaje2);
                    comprobarMensaje4Pos0();
                }
            }
        }
        if(grupoMensajes[numMensaje1].transform.position.x < posicionSiguienteMensaje.transform.position.x){
            mensaje1 = true;
        }
        if(grupoMensajes[numMensaje2].transform.position.x < posicionSiguienteMensaje.transform.position.x){
            mensaje2 = true;
        }
    }

    private void comprobarMensaje1Pos0(){
        if(comprobarValor(grupoMensajes[numMensaje1].transform.position.x, movilMN1.transform.position.x) && comprobarValor(
            grupoMensajes[numMensaje1].transform.position.z, movilMN1.transform.position.z)){
            int antiguoNumMensaje = numMensaje1;
            if(numMensaje1==3){
                numMensaje1=0;
            }
            else{
                numMensaje1++;
            }

            grupoMensajes[antiguoNumMensaje].SetActive(false);
            grupoMensajes[antiguoNumMensaje].transform.position = posInicialMensajesDatos;
            mensaje2=false;
            mM1.setObjetoRecorrido();
            numeroMensajes--;
            terminadoMensaje1 = true;
            numeroMensajesLlegados1++;
        }
    }

    private void comprobarMensaje2Pos0(){
        if(comprobarValor(grupoMensajes[numMensaje2].transform.position.x, movilMN1.transform.position.x) && comprobarValor(
            grupoMensajes[numMensaje2].transform.position.z, movilMN1.transform.position.z)){
            int antiguoNumMensaje = numMensaje2;
            if(numMensaje2==7){
                numMensaje2=4;
            }
            else{
                numMensaje2++;
            }

            grupoMensajes[antiguoNumMensaje].SetActive(false);
            grupoMensajes[antiguoNumMensaje].transform.position = posInicialMensajesDatos;
            mensaje1=false;
            mM2.setObjetoRecorrido();
            numeroMensajes--;
            terminadoMensaje2 = true;
            numeroMensajesLlegados1++;
        }
    }

    private void comprobarMensaje3Pos0(){
        if(comprobarValor(grupoMensajes[numMensaje1].transform.position.x, movilMN2.transform.position.x) && comprobarValor(
            grupoMensajes[numMensaje1].transform.position.z, movilMN2.transform.position.z)){
            int antiguoNumMensaje = numMensaje1;
            if(numMensaje1==3){
                numMensaje1=0;
            }
            else{
                numMensaje1++;
            }

            grupoMensajes[antiguoNumMensaje].SetActive(false);
            grupoMensajes[antiguoNumMensaje].transform.position = posInicialMensajesDatos;
            mensaje2=false;
            mM1.setObjetoRecorrido();
            numeroMensajes--;
            terminadoMensaje1 = true;
            numeroMensajesLlegados2++;
        }
    }

    private void comprobarMensaje4Pos0(){
        if(comprobarValor(grupoMensajes[numMensaje2].transform.position.x, movilMN2.transform.position.x) && comprobarValor(
            grupoMensajes[numMensaje2].transform.position.z, movilMN2.transform.position.z)){
            int antiguoNumMensaje = numMensaje2;
            if(numMensaje2==7){
                numMensaje2=4;
            }
            else{
                numMensaje2++;
            }

            grupoMensajes[antiguoNumMensaje].SetActive(false);
            grupoMensajes[antiguoNumMensaje].transform.position = posInicialMensajesDatos;
            mensaje1=false;
            mM2.setObjetoRecorrido();
            numeroMensajes--;
            terminadoMensaje2 = true;
            numeroMensajesLlegados2++;
        }
    }

    private bool comprobarValor(float pos, float valor){
        bool valorMovil=false;
        if(pos > 0){
            if(valor > 0){
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
            else{
                valorMovil = valor + pos > -0.1 && valor + pos < 0.1;
            }
        }
        else{
            if(valor > 0){
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
            else{
                valorMovil = valor - pos > -0.1 && valor - pos < 0.1;
            }
        }
        return valorMovil;
    }
}
