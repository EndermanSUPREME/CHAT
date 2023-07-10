using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEmail : MonoBehaviour
{
    public int EmailBeingRecieved; // connects with the emails array in EmailAppScript
    public Transform EmailAppObj;

    public void SendEmailToEmail() // triggered via computerEventHandlerScript
    {
        EmailAppObj.GetComponent<EmailAppScript>().RecieveEmail(EmailBeingRecieved);
    }
}//EndScript