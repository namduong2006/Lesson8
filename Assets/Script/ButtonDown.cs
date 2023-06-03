using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDown : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Player player;
    public bool isPressed=false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed==true) 
        {
            player.MoveDown();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
}
