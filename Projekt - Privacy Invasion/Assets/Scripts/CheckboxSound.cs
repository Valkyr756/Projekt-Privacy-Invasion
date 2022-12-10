using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckboxSound : MonoBehaviour//, IPointerDownHandler
{
    public AudioSource clickSound;
    public Toggle toggle;

    void Start()
    {
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        clickSound.Play();
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        clickSound.Play();
        toggle.onValueChanged.AddListener(delegate)
    }*/
}
