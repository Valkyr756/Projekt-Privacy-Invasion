using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    private float limiteCerrarLibroY = 500;
    private float limiteCerrarLibroX = 900;

    public Image guia;

    public GameObject guiaAbierta;
    public GameObject guiaCerrada;
    public AudioSource abriendoGuia;
    public AudioSource cerrandoGuia;
    public RectTransform rectTransform;

    private void Awake()
    {
        guiaAbierta.SetActive(false);
        guiaCerrada.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (guiaAbierta.activeSelf) //La guia esta abierta
        {
            if (Mathf.Abs(guia.rectTransform.anchoredPosition.y) > limiteCerrarLibroY || Mathf.Abs(guia.rectTransform.anchoredPosition.x) > limiteCerrarLibroX)   //Si el libro esta en la parte baja de la pantalla
            {
                guiaAbierta.SetActive(false);
                guiaCerrada.SetActive(true);
                cerrandoGuia.Play();

               guia.rectTransform.anchoredPosition = new Vector2(0f, -700);
            }
        }

        if (guiaCerrada.activeSelf)
        {
            if (Mathf.Abs(guia.rectTransform.anchoredPosition.y) < limiteCerrarLibroY && Mathf.Abs(guia.rectTransform.anchoredPosition.x) < limiteCerrarLibroX)
            {
                guiaAbierta.SetActive(true);
                guiaCerrada.SetActive(false);
                abriendoGuia.Play();
            }

            else
            {
                guia.rectTransform.anchoredPosition = new Vector2(0f, -700);
            }
        }
    }
}
