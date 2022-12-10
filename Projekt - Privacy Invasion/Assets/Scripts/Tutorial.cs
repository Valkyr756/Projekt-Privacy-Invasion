using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject instrucciones;

    public void abrirTutorial()
    {
        instrucciones.SetActive(true);
    }

    public void cerrarTutorial()
    {
        instrucciones.SetActive(false);
    }
}
