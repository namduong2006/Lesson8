using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Player player;
    public bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            player.MoveLeft();
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
