using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name == "Left") //When touching the left screen
        {
            playerMove.SetMoveLeft(true);
        }
        else //When touching the right
        {
            playerMove.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
    }
}
