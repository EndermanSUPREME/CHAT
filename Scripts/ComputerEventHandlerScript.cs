using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComputerEventHandlerScript : MonoBehaviour
{
    public UnityEvent GameEvent;

    public void VirtualMouseClick()
    {
        GameEvent.Invoke();
    }

    public void VirtualMouseClickAndHold()
    {
        GameEvent.Invoke();
    }
}//EndScript