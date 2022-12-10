using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionInicio : MonoBehaviour
{
    public Animator transitionPantalla;
    public Animator transitionElementos;

    public GameObject[] gameObjects;

    void Update()
    {
        if (Input.anyKey)
        {
            transitionPantalla.SetTrigger("Iniciar");
            transitionElementos.SetTrigger("Iniciar");
            
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }

            //Destroy(gameObject);
        }
        
    }
}