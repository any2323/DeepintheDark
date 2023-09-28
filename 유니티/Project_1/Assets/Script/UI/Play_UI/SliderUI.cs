using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderUI : MonoBehaviour, IPointerClickHandler
{
    public Slider slider;
    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.Use();

        print(slider.value);
    }
}
