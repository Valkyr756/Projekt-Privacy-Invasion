using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebButtonManager : MonoBehaviour
{
    public GameObject Mensajes;
    public GameObject Perfil;

    public void onTop()
    {
        if (gameObject.name.Contains("Mensajes"))
        {
            Mensajes.SetActive(true);
            Perfil.SetActive(false);
        }

        else if (gameObject.name.Contains("Perfil"))
        {
            Mensajes.SetActive(false);
            Perfil.SetActive(true);
        }
    }
}
