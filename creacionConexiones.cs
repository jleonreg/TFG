using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creacionConexiones : MonoBehaviour
{
    public velocidadPrograma vP;
    public void crearConexion(GameObject elemento, float valor){
        elemento.SetActive(true);
        if(!comprobarConexionCreada(elemento, valor)){
            float valorX = elemento.transform.localScale.x + vP.getVelocidad();
            float valorY = elemento.transform.localScale.y + vP.getVelocidad();
            float valorZ = elemento.transform.localScale.z + vP.getVelocidad();
            elemento.transform.localScale = new Vector3(valorX, valorY, valorZ);  
        }     
    }
    public void crearUnion(GameObject union, float valorX, float valorY, float valorZ){
        union.SetActive(true);
        float unionX = union.transform.localScale.x;
        float unionY = union.transform.localScale.y;
        float unionZ = union.transform.localScale.z;
        if(!comprobarUnionCreada(union, valorX, valorY, valorZ)){
            if(union.transform.localScale.x <= valorX)
                unionX = union.transform.localScale.x + vP.getVelocidad();
            if(union.transform.localScale.y <= valorY)
                unionY = union.transform.localScale.y + vP.getVelocidad()*3;
            if(union.transform.localScale.z <= valorZ)
                unionZ = union.transform.localScale.z + vP.getVelocidad();

            union.transform.localScale = new Vector3(unionX, unionY, unionZ);  
        }
    }
    public void eliminarConexion(GameObject elemento, float valor){
        elemento.SetActive(true);
        if(!comprobarConexionEliminada(elemento, valor)){
            float valorX = elemento.transform.localScale.x - vP.getVelocidad();
            float valorY = elemento.transform.localScale.y - vP.getVelocidad();
            float valorZ = elemento.transform.localScale.z - vP.getVelocidad();
            elemento.transform.localScale = new Vector3(valorX, valorY, valorZ);  
        }     
    }
    public void eliminarUnion(GameObject union, float valorX, float valorY, float valorZ){
        union.SetActive(true);
        float unionX = union.transform.localScale.x;
        float unionY = union.transform.localScale.y;
        float unionZ = union.transform.localScale.z;
        if(!comprobarUnionEliminada(union, valorX, valorY, valorZ)){
            if(union.transform.localScale.x >= valorX)
                unionX = union.transform.localScale.x - vP.getVelocidad();
            if(union.transform.localScale.y >= valorY)
                unionY = union.transform.localScale.y - vP.getVelocidad()*3;
            if(union.transform.localScale.z >= valorZ)
                unionZ = union.transform.localScale.z - vP.getVelocidad();

            union.transform.localScale = new Vector3(unionX, unionY, unionZ);  
        }
    }

    public bool comprobarConexionCreada(GameObject conexion, float valor){
        bool conexionEntera = true;
        if(conexion.transform.localScale.x <= valor)
            conexionEntera = false;
        if(conexion.transform.localScale.y <= valor)
            conexionEntera = false;
        if(conexion.transform.localScale.z <= valor)
            conexionEntera = false;

        return conexionEntera;
    }

    public bool comprobarUnionCreada(GameObject union, float valorX, float valorY, float valorZ){
        bool unionEntera = true;
        if(union.transform.localScale.x <= valorX)
            unionEntera = false;
        if(union.transform.localScale.y <= valorY)
            unionEntera = false;
        if(union.transform.localScale.z <= valorZ)
            unionEntera = false;

        return unionEntera;
    }

    public bool comprobarConexionEliminada(GameObject conexion, float valor){
        bool conexionEntera = true;
        if(conexion.transform.localScale.x >= valor)
            conexionEntera = false;
        if(conexion.transform.localScale.y >= valor)
            conexionEntera = false;
        if(conexion.transform.localScale.z >= valor)
            conexionEntera = false;

        return conexionEntera;
    }

    public bool comprobarUnionEliminada(GameObject union, float valorX, float valorY, float valorZ){
        bool unionEntera = true;
        if(union.transform.localScale.x >= valorX)
            unionEntera = false;
        if(union.transform.localScale.y >= valorY)
            unionEntera = false;
        if(union.transform.localScale.z >= valorZ)
            unionEntera = false;

        return unionEntera;
    }
}
