using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    private int clockTime;
    [SerializeField] Text clockDisplay;
    [SerializeField] UnityEvent EmailEvent, EmailEventTwo;
    [SerializeField] GameObject Game, Credits;
    private bool emailSent = false, emailSent2 = false;

    // Start is called before the first frame update
    void Start()
    {
        clockDisplay = this.GetComponent<Text>();
        clockTime = 0;
        SetClock();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(36);
        clockTime++;
        SetClock();
        StartCoroutine(Timer());
    }

    void SetClock()
    {
        switch (clockTime)
        {
            case 0:
                clockDisplay.text = "12:00";
            break;
            case 1:
                clockDisplay.text = "12:15";
            break;
            case 2:
                clockDisplay.text = "12:30";
            break;
            case 3:
                clockDisplay.text = "12:45";
            break;
            case 4:
                clockDisplay.text = "1:00";
            break;
            case 5:
                clockDisplay.text = "1:15";
            break;
            case 6:
                clockDisplay.text = "1:30";
            break;
            case 7:
                clockDisplay.text = "1:45";
            break;
            case 8:
                clockDisplay.text = "2:00";
            break;
            case 9:
                clockDisplay.text = "2:15";
                if (emailSent == false)
                {
                    EmailEvent.Invoke();
                    emailSent = true;
                }
            break;
            case 10:
                clockDisplay.text = "2:30";
            break;
            case 11:
                clockDisplay.text = "2:45";
            break;
            case 12:
                clockDisplay.text = "3:00";
            break;
            case 13:
                clockDisplay.text = "3:15";
            break;
            case 14:
                clockDisplay.text = "3:30";
                if (emailSent2 == false)
                {
                    EmailEventTwo.Invoke();
                    emailSent2 = true;
                }
            break;
            case 15:
                clockDisplay.text = "3:45";
            break;
            case 16:
                clockDisplay.text = "4:00";
            break;
            case 17:
                clockDisplay.text = "4:15";
            break;
            case 18:
                clockDisplay.text = "4:30";
            break;
            case 19:
                clockDisplay.text = "4:45";
            break;
            case 20:
                clockDisplay.text = "5:00";
            break;
            case 21:
                clockDisplay.text = "5:15";
            break;
            case 22:
                clockDisplay.text = "5:30";
            break;
            case 23:
                clockDisplay.text = "5:45";
            break;
            case 24:
                clockDisplay.text = "6:00";
                // Run time over
                Game.SetActive(false);
                Credits.SetActive(true);
            break;
            default:
            break;
        }
    }
}//EndScript