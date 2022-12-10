using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HmailButtonManager : MonoBehaviour
{
    public GameObject correoAbierto;
    public GameObject Recibidos;
    public GameObject Enviados;
    public GameObject Spam;
    public GameObject Papelera;

    public void abrirCorreoRecibido()
    {
        correoAbierto.SetActive(true);
    }

    public void cerrarCorreoRecibido()
    {
        correoAbierto.SetActive(false);
    }

    public void onTop()
    {
        correoAbierto.SetActive(false);

        if (gameObject.name.Contains("Recibidos"))
        {
            Recibidos.SetActive(true);
            Enviados.SetActive(false);
            Spam.SetActive(false);
            Papelera.SetActive(false);
        }

        else if (gameObject.name.Contains("Enviados"))
        {
            Recibidos.SetActive(false);
            Enviados.SetActive(true);
            Spam.SetActive(false);
            Papelera.SetActive(false);
        }

        else if (gameObject.name.Contains("Spam"))
        {
            Recibidos.SetActive(false);
            Enviados.SetActive(false);
            Spam.SetActive(true);
            Papelera.SetActive(false);
        }

        else if (gameObject.name.Contains("Papelera"))
        {
            Recibidos.SetActive(false);
            Enviados.SetActive(false);
            Spam.SetActive(false);
            Papelera.SetActive(true);
        }
    }
}
