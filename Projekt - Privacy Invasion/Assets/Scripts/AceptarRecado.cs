using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AceptarRecado : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject recadoActivar;
    public int idRecado;

    public void RecadoAceptado()
    {
        Destroy(gameObject);    //Desactiva el objeto, asi cuando en el GameManager se activen o desactiven las interactuabilidad de los botones los recados ya realizados no se veran afectados

        recadoActivar.SetActive(true);
        gameManager.recadoAceptado(idRecado);
    }

}
