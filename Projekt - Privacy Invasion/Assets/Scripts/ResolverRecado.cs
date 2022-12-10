using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolverRecado : MonoBehaviour
{
    public GameManager gameManager;  //Referencia al GameManager para poder llamar a sus funciones
    public int idRecado;            //Identificador del recado
    public Toggle[] checkbox;       //Los checkbox del recado
    public bool[] comprobarToggle;  //Defines en el editor como deben estar las checkbox para que te den puntos
    public GameObject recadoActivar;
    public GameObject panelRespuesta;

    private bool perfecto = true;
    private int emptyCheks = 0;
    private int reputacion = 0;
    private int dinero = 0;

    public void RecadoFinalizado()
    {

        for (int i = 0; i < checkbox.Length; i++)
        {
            Debug.Log(i);
            if (checkbox[i].isOn && comprobarToggle[i])
            {
                reputacion += 4;
            }

            else if (checkbox[i].isOn && !comprobarToggle[i] /*|| !checkbox[i].isOn && comprobarToggle[i]*/)
            {
                perfecto = false;
                reputacion -= 4;
            }

            else if(!checkbox[i].isOn && comprobarToggle[i])
            {
                perfecto = false;
            }

            else if (!checkbox[i].isOn)
            {
                emptyCheks += 1;
                Debug.Log(emptyCheks);
            }

            //if (checkbox[i].isOn && comprobarToggle[i])         //Si la opcion correcta es "checkeada" y el jugador tiene la casilla checkeada
            //    puntos += 5;
            //else if (!checkbox[i].isOn && !comprobarToggle[i])  //Si la opcion correcta es "no checkeada" y el jugador no tiene la casilla checkeada
            //    puntos += 5;
            //else                                                //Si la opción es una y el jugador ha escogido la otra
            //    puntos -= 1;
        }


        if (emptyCheks == checkbox.Length)
        {
            perfecto = false;
            reputacion -= 4;
        }

        if (perfecto)
            dinero = 20;
        else
            dinero = 0;

        Destroy(panelRespuesta);
        Destroy(recadoActivar);

        gameManager.recadoTerminado(idRecado, reputacion, dinero);   //Le pasa su identificador para que ponga el resto de recados no interactuables y habilite la resolucion de este
    }
}
