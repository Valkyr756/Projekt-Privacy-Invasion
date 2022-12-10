using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponderRecado : MonoBehaviour
{
    public GameObject panelRespuesta;
    public int idRecado;

    public void Responder()
    {
        Destroy(gameObject);

        panelRespuesta.SetActive(true);
    }
}
