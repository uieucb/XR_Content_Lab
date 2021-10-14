using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int puntaje=0;

     void OnCollisionEnter(Collision collision){
        if(collision.collider.name=="min"){
            Debug.Log("Chocamos con el valor min + 20pts");
            puntaje+=20;
        }else if(collision.collider.name=="medium"){
            Debug.Log("Chocamos con el valor medium  + 30pts");
            puntaje+=30;
        }if(collision.collider.name=="max"){
            Debug.Log("Chocamos con el valor max  + 40pts");
            puntaje+=40;
        }

        Debug.Log("Su ultimo puntaje: "+puntaje);
      
    }
}
