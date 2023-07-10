using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmailTriggerScript : MonoBehaviour
{
    public Transform ChatAppObject;
    private int Jul, Fid, Jo;
    private bool MasterEmailTrigger = false, MasterEmailTriggerTwo = false;
    [SerializeField] private UnityEvent EmailEvent, EmailEventTwo;

    void Update()
    {
        Jul = ChatAppObject.GetComponent<CHAT_app_script>().JulieIndex;
        Fid = ChatAppObject.GetComponent<CHAT_app_script>().FidoIndex;
        Jo = ChatAppObject.GetComponent<CHAT_app_script>().JoeIndex;

        if (MasterEmailTrigger == false)
        {
            if (Jul >= 1 && Fid >= 1 || Fid >= 1 && Jo >= 1 || Jul >= 1 && Jo >= 1)
            {
                SendFirstWarning();
            }
        }

        if (MasterEmailTriggerTwo == false)
        {
            if (Jul >= 2 && Fid >= 2 && Jo >= 2)
            {
                SendSecondWarning();
            }
        }
    }

    private void SendFirstWarning()
    {
        EmailEvent.Invoke();
        MasterEmailTrigger = true;
    }

    private void SendSecondWarning()
    {
        EmailEventTwo.Invoke();
        MasterEmailTriggerTwo = true;
    }
}//EndScript