using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deformacionPaquete : MonoBehaviour
{
    public Temporizador temp;
    public velocidadPrograma vP;
    public controlPaquetes cP;

    int cambio;
    bool tamano;
    bool paquetesActivados;
    bool cambioTTL;
    int paqueteDeformado;
    int cambioDeformado;
    float tamanoMaximo;
    float tamanoMinimo;

    // Start is called before the first frame update
    void Start(){
        tamano=false;
        tamanoMaximo=0.25f;
        tamanoMinimo=0.2f;
        paquetesActivados=false;
        cambioTTL=false;
        cambioDeformado=0;
        cambio=0;
    }
    public int deformarPaquete(GameObject[] vectorPaquetes, GameObject[] mensajesPaquete, int caso, GameObject ttl, int paso){
        int pasoCircuito = paso;
        switch(caso){
            case 1:     //Caso de deformacion del paquete completo
                if(paqueteDeformado >= 0){
                    if(cambioDeformado<6){
                        mensajesPaquete[paqueteDeformado].SetActive(true);
                        cambiarTamano(vectorPaquetes[paqueteDeformado]);
                        temp.iniciarTemporizador(0.25f-(vP.getVelocidad()*10));
                    }
                    else{
                        temp.iniciarTemporizador(1f-(vP.getVelocidad()*10));
                        if(temp.getFinalizado()){
                            vectorPaquetes[paqueteDeformado].SetActive(false);
                            mensajesPaquete[paqueteDeformado].SetActive(false);
                            temp.reiniciarValores();
                            paqueteDeformado--;
                            cambioDeformado=0;
                            cambio=0;
                        }
                    }
                }
                else{
                    paquetesActivados=false;
                    pasoCircuito++;
                }
                break;
            case 2:     //Caso de deformacion del paquete hasta el nivel IP
                if(paqueteDeformado >= 0){
                    if(paqueteDeformado ==2){
                        if(cambioDeformado<6){
                            mensajesPaquete[paqueteDeformado].SetActive(true);
                            cambiarTamano(vectorPaquetes[paqueteDeformado]);
                            temp.iniciarTemporizador(0.25f-(vP.getVelocidad()*10));
                        }
                        else{
                            if(!cambioTTL){
                                temp.iniciarTemporizador(1f-(vP.getVelocidad()*10));
                                if(temp.getFinalizado()){
                                    vectorPaquetes[paqueteDeformado].SetActive(false);
                                    mensajesPaquete[paqueteDeformado].SetActive(false);
                                    ttl.SetActive(true);
                                    temp.reiniciarValores();
                                    cambioTTL=true;
                                }
                            }
                            else{
                                temp.iniciarTemporizador(1f-(vP.getVelocidad()*10));
                                if(temp.getFinalizado()){
                                    temp.reiniciarValores();
                                    paqueteDeformado= -1;
                                    cambio=0;
                                    cambioDeformado=0;
                                    ttl.SetActive(false);
                                }
                            }
                        }
                    }
                    else{
                        if(cambioDeformado<6){
                            mensajesPaquete[paqueteDeformado].SetActive(true);
                            cambiarTamano(vectorPaquetes[paqueteDeformado]);
                            temp.iniciarTemporizador(0.25f-(vP.getVelocidad()*10));
                        }
                        else{
                            temp.iniciarTemporizador(1f-(vP.getVelocidad()*10));
                            if(temp.getFinalizado()){
                                vectorPaquetes[paqueteDeformado].SetActive(false);
                                mensajesPaquete[paqueteDeformado].SetActive(false);
                                temp.reiniciarValores();
                                paqueteDeformado--;
                                cambioDeformado=0;
                                cambio=0;
                            }
                        }
                    }
                }
                else{
                    paquetesActivados=false;
                    cambioTTL=false;
                    cP.desactivarTodosPaquetes(vectorPaquetes);
                    cP.desactivarTodosPaquetes(mensajesPaquete);
                    pasoCircuito++;
                }
                break;
        }
        return pasoCircuito;
    }
    

    private void cambiarTamano(GameObject vectorObjetos){
        if(!vectorObjetos.activeSelf){
            vectorObjetos.SetActive(true);
        }
        Renderer rendererCubo = vectorObjetos.GetComponent<Renderer>();
        if(!tamano){
            rendererCubo.transform.localScale = new Vector3(tamanoMaximo, tamanoMaximo, tamanoMaximo);
            if(temp.getFinalizado()){
                tamano=true;
                temp.reiniciarValores();
                cambio++;
                cambioDeformado++;
            }
        }
        else{
            rendererCubo.transform.localScale = new Vector3(tamanoMinimo, tamanoMinimo, tamanoMinimo);
            if(temp.getFinalizado()){
                tamano=false;
                temp.reiniciarValores();
                cambio++;
                cambioDeformado++;
            }
        }
    }

    public void iniciarValores(int paqDef){
        paquetesActivados = true;
        paqueteDeformado = paqDef;
        cambioDeformado = 0;
    }

    public bool getPaquetesActivados(){
        return paquetesActivados;
    }
}
