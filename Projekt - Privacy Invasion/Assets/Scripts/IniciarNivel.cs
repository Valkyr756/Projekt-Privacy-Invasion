using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarNivel : MonoBehaviour
{
    public void abrirNivel()
    {
        SceneManager.LoadScene(1);  //Cambiarlo a 1 cuando añadamos la escena de instrucciones
    }
}
