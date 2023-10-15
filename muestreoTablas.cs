using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muestreoTablas : MonoBehaviour
{
    public GameObject tablaEnrutamiento;

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if(!tablaEnrutamiento.activeSelf){
                        tablaEnrutamiento.SetActive(true);
                    }
                    else{
                        tablaEnrutamiento.SetActive(false);
                    }
                }
            }
        }
    }
}
