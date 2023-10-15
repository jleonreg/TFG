using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoMensaje : MonoBehaviour{
    public velocidadPrograma vP;
    int objetoRecorrido;

    void Start(){
        objetoRecorrido=0;
    }

    public void setObjetoRecorrido(){
        objetoRecorrido=0;
    }

    public int moverMensaje(GameObject[] vectorPaquetes, GameObject mensaje, GameObject[] vectorObjetos, int paso){
        int pasoCircuito = paso;
        bool ejeX=false;
        bool ejeZ=false;
        if(vectorPaquetes != null){
            for(int i=0; i<vectorPaquetes.Length; i++){
                vectorPaquetes[i].SetActive(false);
            }
        }
        mensaje.SetActive(true);
        if(vectorObjetos != null){
            if(objetoRecorrido < vectorObjetos.Length){
                Renderer rendMensaje = mensaje.GetComponent<Renderer>();
                Renderer rendObjetivo = vectorObjetos[objetoRecorrido].GetComponent<Renderer>();
                moverObjeto(mensaje, vectorObjetos[objetoRecorrido], obtenerCasoMovimiento(rendMensaje, rendObjetivo));
                ejeX = comprobarEjeX(rendMensaje, rendObjetivo);
                ejeZ = comprobarEjeZ(rendMensaje, rendObjetivo);
                if(ejeX && ejeZ){
                    objetoRecorrido++;                    
                }
            }
            else{
                mensaje.SetActive(false);
                objetoRecorrido=0;
                pasoCircuito++;
            }
        }

        return pasoCircuito;
    }
    
    private bool comprobarEjeX(Renderer rendMensaje, Renderer rendObjetivo){
        bool ejeX=false;
        if(rendObjetivo.transform.position.x > 0){
            if(rendMensaje.transform.position.x > 0){
                ejeX = rendMensaje.transform.position.x-rendObjetivo.transform.position.x > -0.1 && rendMensaje.transform.position.x-rendObjetivo.transform.position.x < 0.1;
            }
            else{
                ejeX = rendMensaje.transform.position.x+rendObjetivo.transform.position.x > -0.1 && rendMensaje.transform.position.x+rendObjetivo.transform.position.x < 0.1;
            }
        }
        else{
            if(rendMensaje.transform.position.x > 0){
                ejeX = rendMensaje.transform.position.x-rendObjetivo.transform.position.x > -0.1 && rendMensaje.transform.position.x-rendObjetivo.transform.position.x < 0.1;
            }
            else{
                ejeX = rendMensaje.transform.position.x-rendObjetivo.transform.position.x > -0.1 && rendMensaje.transform.position.x-rendObjetivo.transform.position.x < 0.1;
            }
        }
        return ejeX;
    }

    private bool comprobarEjeZ(Renderer rendMensaje, Renderer rendObjetivo){
        bool ejeZ=false;
        if(rendObjetivo.transform.position.z > 0){
            if(rendMensaje.transform.position.z > 0){
                ejeZ = rendMensaje.transform.position.z-rendObjetivo.transform.position.z > -0.1 && rendMensaje.transform.position.z-rendObjetivo.transform.position.z < 0.1;
            }
            else{
                ejeZ = rendMensaje.transform.position.z+rendObjetivo.transform.position.z > -0.1 && rendMensaje.transform.position.z+rendObjetivo.transform.position.z < 0.1;
            }
        }
        else{
            if(rendMensaje.transform.position.z > 0){
                ejeZ = rendMensaje.transform.position.z-rendObjetivo.transform.position.z > -0.1 && rendMensaje.transform.position.z-rendObjetivo.transform.position.z < 0.1;
            }
            else{
                ejeZ = rendMensaje.transform.position.z-rendObjetivo.transform.position.z > -0.1 && rendMensaje.transform.position.z-rendObjetivo.transform.position.z < 0.1;
            }
        }
        return ejeZ;
    }

    private int obtenerCasoMovimiento(Renderer rendMensaje, Renderer rendObjetivo){
        int caso=0;
        bool ejeX = Mathf.Abs(rendMensaje.transform.position.x)-rendObjetivo.transform.position.x > -0.1 && Mathf.Abs(rendMensaje.transform.position.x)-rendObjetivo.transform.position.x < 0.1;
        bool ejeZ = Mathf.Abs(rendMensaje.transform.position.z)-rendObjetivo.transform.position.z > -0.1 && Mathf.Abs(rendMensaje.transform.position.z)-rendObjetivo.transform.position.z < 0.1;
        if(!ejeX){
            if(!ejeZ){
                if(rendMensaje.transform.position.x < rendObjetivo.transform.position.x){
                    if(rendMensaje.transform.position.z < rendObjetivo.transform.position.z){
                        caso=1;
                    }
                    else{
                        caso=2;
                    }
                }
                else{
                    if(rendMensaje.transform.position.z < rendObjetivo.transform.position.z){
                        caso=3;
                    }
                    else{
                        caso=4;
                    }
                }
            }
            else{
                if(rendMensaje.transform.position.x < rendObjetivo.transform.position.x){
                    caso=5;
                }
                else{
                    caso=6;
                }
            }
        }
        else{
            if(!ejeZ){
                if(rendMensaje.transform.position.z < rendObjetivo.transform.position.z){
                    caso=7;
                }
                else{
                    caso=8;
                }
            }
        }
        return caso;
    }

    private void moverObjeto(GameObject mensaje, GameObject objetivo, int caso){
        comprobarEnlace(mensaje, objetivo);
        Renderer rendMensaje = mensaje.GetComponent<Renderer>();
        Renderer rendObjetivo = objetivo.GetComponent<Renderer>();
        switch(caso){
            case 1:     //Caso en el que la X y la Z del mensaje es menor que la del objetivo
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x+vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z+vP.getVelocidad());
                break;
            case 2:     //Caso en el que la X del mensaje es menor que la del objetivo y la Z es mayor
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x+vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z-vP.getVelocidad());
                break;
            case 3:     //Caso en el que la X del mensaje es mayor que la del objetivo y la Z es menor  
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x-vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z+vP.getVelocidad());   
                break;
            case 4:     //Caso en el que la X y la Z del mensaje es mayor que la del objetivo
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x-vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z-vP.getVelocidad());
                break;
            case 5:     //Caso en el que la X es menor que la del objetivo y no hay Z
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x+vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z);
                break;
            case 6:     //Caso en el que la X es mayor que la del objetivo y no hay Z
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x-vP.getVelocidad(), rendMensaje.transform.position.y, rendMensaje.transform.position.z);
                break;
            case 7:     //Caso en el que la Z es menor que la del objetivo y no hay X
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x, rendMensaje.transform.position.y, rendMensaje.transform.position.z+vP.getVelocidad());
                break;
            case 8:     //Caso en el que la Z es mayor que la del objetivo y no hay X
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x, rendMensaje.transform.position.y, rendMensaje.transform.position.z-vP.getVelocidad());
                break;
        }
    }
    
    private void comprobarEnlace(GameObject mensaje, GameObject objetivo){
        Renderer rendMensaje = mensaje.GetComponent<Renderer>();
        Renderer rendObjetivo = objetivo.GetComponent<Renderer>();
        if(objetivo.tag == "Enlace"){
            if(rendMensaje.transform.position.y >= 0.4f)
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x, rendMensaje.transform.position.y-vP.getVelocidad(), rendMensaje.transform.position.z);
        }
        else{
            if(rendMensaje.transform.position.y <= 0.6f)
                rendMensaje.transform.position= new Vector3(rendMensaje.transform.position.x, rendMensaje.transform.position.y+vP.getVelocidad(), rendMensaje.transform.position.z);
        }
    }
}
