using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUp : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Player player;
    public bool isPressed = false;
    
    void Start()
    {
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        
    }
    void Update()
    {
        if (isPressed==true)
        {
            player.MoveUp();
        }
    }
}
