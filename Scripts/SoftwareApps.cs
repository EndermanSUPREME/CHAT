using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftwareApps : MonoBehaviour
{
    private bool AppRunning, Minimize, Maximize;
    public GameObject ApplicationWindow, TaskBarIcon;
    public Transform Mouse, ComputerScreen;

    void Start()
    {
        AppRunning = false;
        Minimize = false;
        Maximize = false;
        ApplicationWindow.SetActive(false);
        TaskBarIcon.SetActive(false);
    }

    public void OpenApplication() // icon
    {
        AppRunning = true; // player clicks the app and the app loads
        ApplicationWindow.SetActive(true);
        TaskBarIcon.SetActive(true);
    }

    public void MaximizeWindow() // window
    {
        Maximize = true;
        Minimize = false;
    }

    public void MinimizeWindow() // window
    {
        Minimize = true;
        Maximize = false;
    }

    public void CloseApplication() // window
    {
        AppRunning = false;
        ApplicationWindow.SetActive(false);
        TaskBarIcon.SetActive(false);
    }

    public void MoveAppWindow() //click and hold
    {
        ApplicationWindow.transform.SetParent(Mouse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") == false)
        {
            ApplicationWindow.transform.parent = ComputerScreen;
        }
    }
}//EndScript