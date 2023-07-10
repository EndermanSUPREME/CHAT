using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginComputer : MonoBehaviour
{
    [SerializeField] Text userTxt, pswdTxt;
    [SerializeField] GameObject InvalidUsername, InvalidPassword, Desktop;
    [SerializeField] Animator LoginPageAnim, stickyNote;

    void Start()
    {
        InvalidUsername.SetActive(false);
        InvalidPassword.SetActive(false);
        Desktop.SetActive(false);
    }

    public void SubmitCredentials()
    {
        if (userTxt.text != "admin" || userTxt.text != "Admin" || userTxt.text != "ADMIN")
        {
            // log in unsuccessful
            InvalidUsername.SetActive(true);
        }

        if (pswdTxt.text != "nimda321" || pswdTxt.text != "NIMDA321")
        {
            // log in unsuccessful
            InvalidPassword.SetActive(true);
        }

        if (userTxt.text == "admin" || userTxt.text == "Admin" || userTxt.text == "ADMIN" && pswdTxt.text == "nimda321" || pswdTxt.text == "NIMDA321")
        {
            // log in successful
            InvalidUsername.SetActive(false);
            InvalidPassword.SetActive(false);

            LoginPageAnim.Play("LoggingIn");
            stickyNote.Play("falling");
            Desktop.SetActive(true);
        }
    }
}//EndScript