using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSimulador : MonoBehaviour
{
    public GameObject menu;
    public GameObject primerDiagrama;
    public GameObject segundoDiagrama;
    public GameObject tercerDiagrama;
    public GameObject cuartoDiagrama;

    public Animator animPrimerDiag;
    public Animator animSegundoDiag;
    public Animator animTercerDiag;
    public Animator animCuartoDiag;


    public GameObject botonDirecciones;
    public GameObject botonBack;
    public GameObject botonPlay;
    public GameObject botonAumentar;
    public GameObject botonDisminuir;
    public GameObject luz;
    public GameObject velocidad;

    public reinicioProtocolo1 rc1;
    public reinicioProtocolo2 rc2;
    public reinicioProtocolo3 rc3;
    public reinicioProtocolo4 rc4;

    public void eleccionPrimerDiagrama(){
        menu.SetActive(false);
        primerDiagrama.SetActive(true);
        activarInterfaz();
    }

    public void eleccionSegundoDiagrama(){
        menu.SetActive(false);
        segundoDiagrama.SetActive(true);
        activarInterfaz();
    }

    public void eleccionTercerDiagrama(){
        menu.SetActive(false);
        tercerDiagrama.SetActive(true);
        activarInterfaz();
    }

    public void eleccionCuartoDiagrama(){
        menu.SetActive(false);
        cuartoDiagrama.SetActive(true);
        activarInterfaz();
    }

    public void back(){
        menu.SetActive(true);
        desactivarInterfaz();
        primerDiagrama.SetActive(false);
        segundoDiagrama.SetActive(false);
        tercerDiagrama.SetActive(false);
        cuartoDiagrama.SetActive(false);
        rc1.reiniciar();
        rc2.reiniciar();
        rc3.reiniciar();
        rc4.reiniciar();
    }

    private void activarInterfaz(){
        botonDirecciones.SetActive(true);
        botonBack.SetActive(true);
        botonPlay.SetActive(true);
        botonAumentar.SetActive(true);
        botonDisminuir.SetActive(true);
        luz.SetActive(true);
        velocidad.SetActive(true);
    }

    private void desactivarInterfaz(){
        botonDirecciones.SetActive(false);
        botonBack.SetActive(false);
        botonPlay.SetActive(false);
        botonAumentar.SetActive(false);
        botonDisminuir.SetActive(false);
        luz.SetActive(false);
        velocidad.SetActive(false);
    }
}
