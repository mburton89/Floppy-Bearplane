using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SliderDemo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Transform wheel;

    [SerializeField] private float _onPressedValue;
    [SerializeField] private float _onReleasedValue;
    [SerializeField] private float _currentValue;
    private bool _canUpdateSlider;

    public void OnPointerDown(PointerEventData eventData)
    {

        _onPressedValue = slider.value;
        _currentValue = _onPressedValue - _onReleasedValue;
        print("DOWN " + _currentValue);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _onReleasedValue = slider.value;
        print("UP " + _onReleasedValue);
    }

    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);

    //    // Your code here
    //}



    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            text.text = v.ToString("0.00");
            wheel.eulerAngles = new Vector3(0, 0, _currentValue + v);
        });
    }
}
