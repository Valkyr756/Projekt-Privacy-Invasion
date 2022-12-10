using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Image MSG;
    public Image Hmail;
    public Image Tertwii;
    public Image Tangram;

    public GameObject FlechaDerecha;
    public GameObject FlechaIzquierda;

    public GameManager GM;

    public GameObject[] PaginasGuia;

    private void Awake()
    {
        FlechaIzquierda.SetActive(false);
    }

    public void cederAmenaza()
    {
        GM.tratoSicarioAceptado = true;
        GM.llamadaAnonimaAcabada = true;
    }

    public void llamarPolicia()
    {
        GM.tratoSicarioAceptado = false;
        GM.llamadaAnonimaAcabada = true;
    }

    public void abrirPuerta()
    {
        GM.abrirPuerta = true;
        GM.llamadaPuertaAcabada = true;
    }

    public void noResponder()
    {
        GM.abrirPuerta = false;
        GM.llamadaPuertaAcabada = true;
    }

    public void abrirMensajes()
    {
        MSG.rectTransform.anchoredPosition = new Vector2(0f, 20f);
        MSG.transform.SetSiblingIndex(4);
    }

    public void abrirGmail()
    {
        Hmail.rectTransform.anchoredPosition = new Vector2(0f, 20f);
        Hmail.transform.SetSiblingIndex(4);
    }

    public void abrirTwitter()
    {
        Tertwii.rectTransform.anchoredPosition = new Vector2(0f, 20f);
        Tertwii.transform.SetSiblingIndex(4);
    }

    public void abrirInstagram()
    {
        Tangram.rectTransform.anchoredPosition = new Vector2(0f, 20f);
        Tangram.transform.SetSiblingIndex(4);
    }

    public void cerrarMensajes()
    {
        MSG.rectTransform.anchoredPosition = new Vector2(2000f, 0f);
    }

    public void cerrarGmail()
    {
        Hmail.rectTransform.anchoredPosition = new Vector2(-2000f, 0f);
    }

    public void cerrarTwitter()
    {
        Tertwii.rectTransform.anchoredPosition = new Vector2(1000f, 1000f);
    }

    public void cerrarInstagram()
    {
        Tangram.rectTransform.anchoredPosition = new Vector2(-1000f, 1000f);
    }

    public void paginaSiguiente()
    {
        FlechaIzquierda.SetActive(true);

        for (int i = 0; i < PaginasGuia.Length; i++)
        {
            if (i == PaginasGuia.Length - 1)
            {
                break;
            }

            else if (PaginasGuia[i].activeSelf == true)
            {
                PaginasGuia[i].SetActive(false);
                PaginasGuia[i + 1].SetActive(true);

                if (i+1 == PaginasGuia.Length - 1)
                {
                    FlechaDerecha.SetActive(false);
                }

                break;
            }
        }
    }

    public void paginaAnterior()
    {
        FlechaDerecha.SetActive(true);

        for (int i = PaginasGuia.Length - 1; i > -1; i--)
        {
            if (i == 0)
            {
                break;
            }

            else if (PaginasGuia[i].activeSelf == true)
            {
                PaginasGuia[i].SetActive(false);
                PaginasGuia[i - 1].SetActive(true);

                if (i - 1 == 0)
                {
                    FlechaIzquierda.SetActive(false);
                }

                break;
            }
        }
    }
}
