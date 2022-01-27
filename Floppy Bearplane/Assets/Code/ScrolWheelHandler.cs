using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScrolWheelHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    float initialTouchYPos;
    float currentTouchYPos;
    float initialWheelZRot;
    bool canScroll;
    [SerializeField] Transform wheel;
    [SerializeField] Transform bear;

    public void OnPointerDown(PointerEventData eventData)
    {
        canScroll = true;
        initialTouchYPos = Input.mousePosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canScroll = false;
        initialWheelZRot = wheel.eulerAngles.z;
    }

    void Update()
    {
        if (canScroll)
        {
            currentTouchYPos = Input.mousePosition.y;
            wheel.eulerAngles = new Vector3(0, 0, initialWheelZRot + (currentTouchYPos - initialTouchYPos));
            bear.eulerAngles = wheel.eulerAngles;
        }
    }
}
