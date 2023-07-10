using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReadImportedFileTrigger : MonoBehaviour
{
    public Transform chatApp;
    public bool FileRead = false;

    public void JulieFile()
    {
        if (FileRead == false)
        {
            chatApp.GetComponent<CHAT_app_script>().JulieEvent();
            FileRead = true;
        }
    }

    public void FidoFile()
    {
        if (FileRead == false)
        {
            chatApp.GetComponent<CHAT_app_script>().FidoEvent();
            FileRead = true;
        }
    }

    public void JoeFile()
    {
        if (FileRead == false)
        {
            chatApp.GetComponent<CHAT_app_script>().JoeEvent();
            FileRead = true;
        }
    }
}//EndScript