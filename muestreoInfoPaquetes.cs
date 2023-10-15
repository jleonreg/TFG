using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muestreoInfoPaquetes : MonoBehaviour
{
    public GameObject[] infoPaquetes;
    public GameObject info;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if(!info.activeSelf){
                        ocultarInfo();
                        info.SetActive(true);
                    }
                    else{
                        info.SetActive(false);
                    }
                }
            }
        }
    }

    private void ocultarInfo(){
        for(int i=0; i < infoPaquetes.Length; i++){
            infoPaquetes[i].SetActive(false);
        }
    }
}
