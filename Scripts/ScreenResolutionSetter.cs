using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("Width"), PlayerPrefs.GetInt("Height"), true);
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
    }
}//EndScript