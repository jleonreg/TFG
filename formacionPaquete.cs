using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formacionPaquete : MonoBehaviour
{
    public Temporizador temp;
    public velocidadPrograma vP;
    public controlPaquetes cP;

    bool tamano;
    float tamanoMaximo;
    float tamanoMinimo;
    int paquete;
    int cambio;

    // Start is called before the first frame update
    void Start(){
        tamano=false;
        tamanoMaximo=0.25f;
        tamanoMinimo=0.2f;
        paquete=0;
        cambio=0;
    }

    public int formarPaquete(GameObject[] vectorPaquetes, GameObject[] mensajesPaquete, int paso){
        int pasoCircuito = paso;
        if(paquete<vectorPaquetes.Length){
            cP.desactivarPaquetes(mensajesPaquete, paquete);
            mensajesPaquete[paquete].SetActive(true);
            if(cambio<6){
                cambiarTamano(vectorPaquetes[paquete]);
                temp.iniciarTemporizador(0.25f-(vP.getVelocidad()*10));
            }
            else{
                temp.iniciarTemporizador(1f-(vP.getVelocidad()*10));
                if(temp.getFinalizado()){
                    mensajesPaquete[paquete].SetActive(false);
                    temp.reiniciarValores();
                    paquete++;
                    cambio=0;
                }
            }
        }
        else{
            paquete=0;
            pasoCircuito++;
            cP.desactivarTodosPaquetes(vectorPaquetes);
            cP.desactivarTodosPaquetes(mensajesPaquete);
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
            }
        }
        else{
            rendererCubo.transform.localScale = new Vector3(tamanoMinimo, tamanoMinimo, tamanoMinimo);
            if(temp.getFinalizado()){
                tamano=false;
                temp.reiniciarValores();
                cambio++;
            }
        }
    }
}
