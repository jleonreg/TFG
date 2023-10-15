using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificacionTamanoPC : MonoBehaviour
{
    public velocidadPrograma vP;
    public Temporizador temp;

    bool tamMax;
    bool tamMin;
    bool textoMostrado;

    // Start is called before the first frame update
    void Start(){
        tamMax=false;
        tamMin=false;
        textoMostrado=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int tamanoPc(Renderer rendPc, GameObject textoPc, int paso){
        int pasoCircuito=paso;
        if(!tamMax){
            rendPc.transform.localScale = new Vector3(rendPc.transform.localScale.x+vP.getVelocidad()*3, rendPc.transform.localScale.y+vP.getVelocidad()*3, rendPc.transform.localScale.z+vP.getVelocidad()*3);
            if(rendPc.transform.localScale.x >= 4f)
                tamMax=true;
        }
        else{
            if(!tamMin){
                if(!textoMostrado){
                    textoPc.SetActive(true);
                    temp.iniciarTemporizador(2f);
                    if(temp.getFinalizado()){
                        textoMostrado=true;
                    }
                }
                else{
                    rendPc.transform.localScale = new Vector3(rendPc.transform.localScale.x-vP.getVelocidad()*3, rendPc.transform.localScale.y-vP.getVelocidad()*3, rendPc.transform.localScale.z-vP.getVelocidad()*3);
                    if(rendPc.transform.localScale.x <= 1f)
                        tamMin=true;
                }
            }
            else{
                pasoCircuito++;
                tamMax=false;
                textoMostrado=false;
                tamMin=false;
                temp.reiniciarValores();
            }
        }
        return pasoCircuito;
    }
}
