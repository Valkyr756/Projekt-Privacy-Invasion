using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int diaActual;
    private int recadosTotalesDiaActual = 0;

    private int recadosCompletadosHoy = 0;

    private int puntosTotales = 0;  //--VARIABLE PARA EXPERIMENTAR//

    private int puntosPositivos = 0;
    private int puntosNegativos = 0;
    private int numeroAleatorio;

    [HideInInspector]
    public bool tratoSicarioAceptado = false;
    [HideInInspector]
    public bool llamadaAnonimaAcabada = false;
    [HideInInspector]
    public bool abrirPuerta = false;
    [HideInInspector]
    public bool llamadaPuertaAcabada = false;

    private Animator transitionDia;
    private Animator transitionFinales;
    private Animator transitionPuerta;
    private Animator transitionLlamada;

    public int numeroFinalZombies;
    public int alquiler;
    public Slider reputación;
    public Slider dinero;
    public Image bloqueadorPantalla;
    public Button respuestaSicarioBuena;
    public Button respuestaSicarioMala;
    public GameObject llamadaAnonima;
    public GameObject visitaPuertaSicario;
    public AudioSource llamadaSonando;
    public AudioSource llamadaDescolgada;
    public AudioSource llamadaColgada;
    public AudioSource puertaSonando;
    public AudioSource puertaAbriendo;
    public AudioSource puertaCerrando;
    public ButtonManager buttonManager;

    public GameObject[] finales;            //Exito[0] Puente[1] Prision[2] Sicario[3] Oficina[4] Zombies[5] 
    public GameObject[] cambioDia;          //Almacena los gameobject de las transiciones entre dias

    public GameObject[] recadosDia1;        //AÑADI ARRAY DE RECADOS PARA CADA DIA. ASI SERA MAS FACIL MOVERSE A TRAVES DE ELLOS EN VEZ DE TENER QUE MOVERSE POR UN SOLO ARRAY
    public GameObject[] recadosDia2;
    public GameObject[] recadosDia3;

    public List<GameObject> recadosCompletados;

    private void Awake()
    {
        nuevoDia();
    }

    private void Update()
    {
        if (diaActual == 3 && llamadaAnonimaAcabada)
        {

            llamadaColgada.Play();

            if (tratoSicarioAceptado)
            {
                finalPrision();

                llamadaAnonimaAcabada = false;
                llamadaAnonima.SetActive(false);
                bloqueadorPantalla.gameObject.SetActive(false);
            }

            else if (!tratoSicarioAceptado)
            {
                llamadaAnonimaAcabada = false;
                llamadaAnonima.SetActive(false);
                bloqueadorPantalla.gameObject.SetActive(false);

                recadosTotalesDiaActual = recadosDia3.Length;

                for (int i = 0; i < recadosDia3.Length; i++)
                {
                    recadosDia3[i].SetActive(true);
                }
            }
        }

        if (diaActual == 3 && llamadaPuertaAcabada)
        {
            if (abrirPuerta)
            {
                puertaAbriendo.Play();

                finalSicario();

                llamadaPuertaAcabada = false;
                visitaPuertaSicario.SetActive(false);
                bloqueadorPantalla.gameObject.SetActive(false);
            }

            else if (!abrirPuerta)
            {
                puertaCerrando.Play();

                finalExito();

                llamadaPuertaAcabada = false;
                visitaPuertaSicario.SetActive(false);
                bloqueadorPantalla.gameObject.SetActive(false);
            }
        }
    }

    public void nuevoDia()
    {
        if (diaActual == 2)         //Se muestra la transicion del dia 2
        {
            cambioDia[0].SetActive(true);
            transitionDia = cambioDia[0].GetComponent<Animator>();
            transitionDia.SetTrigger("Iniciar");
            buttonManager.cerrarGmail();
            buttonManager.cerrarInstagram();
            buttonManager.cerrarMensajes();
            buttonManager.cerrarTwitter();
        }

        else if (diaActual == 3)    //Se muestra la transicion del dia 3
        {
            cambioDia[0].SetActive(false);
            cambioDia[1].SetActive(true);
            transitionDia = cambioDia[1].GetComponent<Animator>();
            transitionDia.SetTrigger("Iniciar");
            buttonManager.cerrarGmail();
            buttonManager.cerrarInstagram();
            buttonManager.cerrarMensajes();
            buttonManager.cerrarTwitter();
        }    

       //Se accede a la ventana de mensajes para activar los correspondientes al nuevo dia

       //Se establecen la cantidad de recados que hay en este dia

       recadosCompletadosHoy = 0;

        numeroAleatorio = Random.Range(1, 100);

        if (numeroAleatorio == numeroFinalZombies && diaActual != 1)
        {
            finalZombies();
            return;
        }

        else if (diaActual == 1)
        {
            recadosTotalesDiaActual = recadosDia1.Length;

            for (int i = 0; i < recadosDia1.Length; i++)
            {
                recadosDia1[i].SetActive(true);
            }
        }

        else if (diaActual == 2)
        {
            recadosTotalesDiaActual = recadosDia2.Length;

            for (int i = 0; i < recadosDia2.Length; i++)
            {
                recadosDia2[i].SetActive(true);
            }
        }

        else if (diaActual == 3)
        {
            llamadaExtorsión();

            /*if (tratoSicarioAceptado)
            {
                finalPrision();
                return;
            }

            else
            {
                recadosTotalesDiaActual = recadosDia3.Length;

                for (int i = 0; i < recadosDia3.Length; i++)
                {
                    recadosDia3[i].SetActive(true);
                }
            }*/
        }
    }

    //LO QUE CAMBIO EL DANIEL
    public void recadoAceptado(int idRecado)    //--Version anterior: reacadoAceptado y recadoTerminado sin parametro, y responderRecado() habilitado
    {
        if (diaActual == 1)
        {
            for (int i = 0; i < recadosDia1.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia1[i]))
                    recadosDia1[i].transform.GetChild(2).GetComponent<Button>().interactable = false;
            }

            recadosDia1[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }

        if (diaActual == 2)
        {
            for (int i = 0; i < recadosDia2.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia2[i]))
                    recadosDia2[i].transform.GetChild(2).GetComponent<Button>().interactable = false;
            }

            recadosDia2[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }

        if (diaActual == 3)
        {
            for (int i = 0; i < recadosDia3.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia3[i]))
                    recadosDia3[i].transform.GetChild(2).GetComponent<Button>().interactable = false;
            }

            recadosDia3[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    /*public void responderRecado()
    {
        //La funcion llama a una corutina que esperara a que el boton de "Enviar" sea pulsado
        recadoTerminado();
    }*/

    public void recadoTerminado(int idRecado, int reputacionGanada, int dineroGanado)
    {
        recadosCompletadosHoy += 1;

        //Calculo de dinero y reputación
        dinero.value += dineroGanado;
        reputación.value += reputacionGanada;

        if (diaActual == 1)
        {
            recadosCompletados.Add(recadosDia1[idRecado]);  //Meti esto aqui dentro porque son los recados del dia 1 (DANIEL)
            for (int i = 0; i < recadosDia1.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia1[i]))
                    //Se activa el boton de "Aceptar" del resto de recados
                    recadosDia1[i].transform.GetChild(2).GetComponent<Button>().interactable = true;
            }

            //Se activa la imagen de "Completar" en el recado completado
            if (dineroGanado != 0)
                recadosDia1[idRecado].transform.GetChild(2).gameObject.SetActive(true);
            else
                recadosDia1[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }

        else if (diaActual == 2)
        {
            recadosCompletados.Add(recadosDia2[idRecado]);  //Copie y pegue lo de arriba y cambie el nombre a dia 2 (DANIEL)
            for (int i = 0; i < recadosDia2.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia2[i]))
                    //Se activa el boton de "Aceptar" del resto de recados
                    recadosDia2[i].transform.GetChild(2).GetComponent<Button>().interactable = true;    //Esto estaba puesto a false, supongo que era un fallo (DANIEL)
            }

            //Se activa la imagen de "Completar" en el recado completado
            if (dineroGanado != 0)
                recadosDia2[idRecado].transform.GetChild(2).gameObject.SetActive(true);
            else
                recadosDia2[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }

        else if (diaActual == 3)
        {
            recadosCompletados.Add(recadosDia3[idRecado]);  //Copie y pegue lo de arriba y cambie el nombre a dia 2 (DANIEL)
            for (int i = 0; i < recadosDia3.Length; i++)
            {
                if (i != idRecado && !recadosCompletados.Contains(recadosDia3[i]))
                    //Se activa el boton de "Aceptar" del resto de recados
                    recadosDia3[i].transform.GetChild(2).GetComponent<Button>().interactable = true;    //Esto estaba puesto a false, supongo que era un fallo (DANIEL)
            }

            //Se activa la imagen de "Completar" en el recado completado
            if (dineroGanado != 0)
                recadosDia3[idRecado].transform.GetChild(2).gameObject.SetActive(true);
            else
                recadosDia3[idRecado].transform.GetChild(3).gameObject.SetActive(true);
        }

        if (recadosCompletadosHoy == recadosTotalesDiaActual)
        {
            diaTerminado();
        }
    }

    //FINAL DE LO QUE CAMBIO EL DANIEL
    public void diaTerminado()
    {
        //Se activa una pantalla negra

        //Se muestra por pantalla el aumento/descenso de la reputacion y el dinero

        //Se desactiva la pantalla negra

        //Se inicia el nuevo dia

        if (diaActual == 3 && reputación.value > 90)
        {
            visitaSicario();
            buttonManager.cerrarGmail();
            buttonManager.cerrarInstagram();
            buttonManager.cerrarMensajes();
            buttonManager.cerrarTwitter();
            return;
        }

        else if (diaActual == 3 && reputación.value <= 90)
        {
            finalOficina();
            buttonManager.cerrarGmail();
            buttonManager.cerrarInstagram();
            buttonManager.cerrarMensajes();
            buttonManager.cerrarTwitter();
            return;
        }

        dinero.value -= alquiler;

        if (dinero.value != 0)
        {
            diaActual += 1;
            nuevoDia();
        }

        else
        {
            finalPuente();
            return;
        }
    }

    public void llamadaExtorsión()
    {
        //Se activa el bloqueador de pantalla
        bloqueadorPantalla.gameObject.SetActive(true);

        //Se activa el sonido de una llamada telefonica y se espera a que termine
        StartCoroutine(EsperaTelefono(llamadaSonando, llamadaDescolgada, llamadaAnonima));

        //Se activa el sonido de descolgar una llamada telefonica y se espera a que termine

        //Aparece un texto con la amenaza del Sicario y dos botones, uno para aceptarla y otro para rechazarla

        //La funcion llama a una corutina que esperara a que uno de los dos botones sea pulsado
        //Si el boton de aceptar el trato es pulsado, la variable "tratoSicarioAceptado" se pondre a true

    }

    IEnumerator EsperaTelefono(AudioSource sonido1, AudioSource sonido2, GameObject trastoActivar)
    {
        sonido1.Play();
        yield return new WaitForSeconds(sonido1.clip.length);

        sonido2.Play();
        trastoActivar.SetActive(true);
        transitionLlamada = llamadaAnonima.GetComponent<Animator>();
        transitionLlamada.SetTrigger("Iniciar");
        //yield return new WaitForSeconds(sonido2.clip.length);
    }

    public void visitaSicario()
    {
        bloqueadorPantalla.gameObject.SetActive(true);
        StartCoroutine(EsperaPuerta(puertaSonando, visitaPuertaSicario));
    }

    IEnumerator EsperaPuerta(AudioSource sonido1, GameObject trastoActivar)
    {
        sonido1.Play();
        yield return new WaitForSeconds(sonido1.clip.length);
        trastoActivar.SetActive(true);
        transitionPuerta = visitaPuertaSicario.GetComponent<Animator>();
        transitionPuerta.SetTrigger("Iniciar");
    }

    public void finalExito()
    {
        //Se activa el bloqueador de pantalla

        //Se aumentan las barras de reputacion y dinero al máximo

        //Se le asigna la imagen correspondiente al final en el que te contrata el gobierno con un texto explicativo
        finales[0].SetActive(true);
        transitionFinales = finales[0].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
        //Se sale del juego despues de esperar 1 minuto
    }

    public void finalPuente()
    {
        //Se activa el bloqueador de pantalla

        //Se disminuyen las barras de reputacion y dinero minimo

        //Se le asigna la imagen correspondiente al final en el que acabas bajo un puente con un texto explicativo
        finales[1].SetActive(true);
        transitionFinales = finales[1].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
        //Se sale del juego despues de esperar 1 minuto
    }

    public void finalPrision()
    {
        //Se activa el bloqueador de pantalla

        //Se disminuyen las barras de reputacion y dinero minimo

        //Se le asigna la imagen correspondiente al final en el que acabas en la prisión con un texto explicativo
        finales[2].SetActive(true);
        transitionFinales = finales[2].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
        //Se sale del juego despues de esperar 1 minuto
    }

    public void finalSicario()
    {
        //Se activa el bloqueador de pantalla

        //Se disminuyen las barras de reputacion y dinero minimo

        //Se le asigna la imagen correspondiente al final en el que el sicario te encuentra con un texto explicativo
        finales[3].SetActive(true);
        transitionFinales = finales[3].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
        //Se sale del juego despues de esperar 1 minuto
    }

    public void finalOficina()
    {
        finales[4].SetActive(true);
        transitionFinales = finales[4].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
    }

    public void finalZombies()
    {
        Debug.Log("Anna esta fatal");
        //Se activa el bloqueador de pantalla

        //Se activa el sonido de una explosion y se espera a que termine

        //Se le asigna la imagen correspondiente al final en el que el sicario te encuentra con un texto explicativo...o en este caso una muletilla chistosa
        finales[5].SetActive(true);
        transitionFinales = finales[5].GetComponent<Animator>();
        transitionFinales.SetTrigger("Iniciar");
        //Se sale del juego despues de esperar 1 minuto
    }
}
