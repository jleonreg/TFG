using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlLuz : MonoBehaviour
{
    bool activado;

    void Start(){
        activado=false;
    }

    public void cambiarColor(){
        if(!activado){
            activado=true;
            var colors = GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            GetComponent<Button>().colors = colors;
        }
        else{
            activado=false;
            var colors = GetComponent<Button>().colors;
            colors.normalColor = Color.red;
            GetComponent<Button>().colors = colors;
        }
    }

    public void setLuz(bool luz){
        activado = luz;
    }

    public bool getLuz(){
        return activado;
    }
}
