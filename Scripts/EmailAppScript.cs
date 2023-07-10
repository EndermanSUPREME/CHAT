using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailAppScript : MonoBehaviour
{
    [SerializeField] Text EmailBodyText, EmailTitle;
    [SerializeField] Transform[] emailSlots;
    public GameObject MyCursor, Clock, ChatApp;
    public GameObject[] EmailSelection;// [0, 8]
    private int EmailSlotNumber = 0;

    void Start()
    {
        Clock.SetActive(true);

        for (int i = 0; i < EmailSelection.Length; i++)
        {
            EmailSelection[i].SetActive(false);
        }
    }

    public void RecieveEmail(int index)
    {
        EmailSelection[index].transform.position = emailSlots[EmailSlotNumber].position;
        EmailSelection[index].SetActive(true);
        if (EmailSlotNumber < emailSlots.Length)
        {
            EmailSlotNumber++;
        }
    }

    public void ReadEmail()
    {
        StartCoroutine(EmailConfig());
        // print("Fizz");
    }

    private IEnumerator EmailConfig()
    {
        // print("Buzz");

        if (MyCursor.GetComponent<ComputerCursor>() != null)
        {
            // print("Fizz_Buzz");
            if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[0].transform)
            {
                EmailTitle.text = "Phish Results";
                EmailBodyText.text = "IP : 215.524.16.244 Port: 80 - Open\n[Type IP into browser to view]\nSystem OS : Tmr80 Version - 1.23.5f2\nNetwork ID : JuliesNetwork\nDevices Connected : myPhone, desktop#z5md21, JuliesSmartFridge";
            } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[1].transform)
                {
                    EmailTitle.text = "Phish Results";
                    EmailBodyText.text = "IP : 152.24.168.89 Port: 80 - Open\n[Type IP into browser to view]\nSystem OS : VM-Sys32 Version - 1.32\nNetwork ID : DawgHowse\nDevices Connected : QuietDogCollar, myGPS, Suit_LED_Lighting, RazorX_QuadDrone";
                } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[2].transform)
                    {
                        EmailTitle.text = "Phish Results";
                        EmailBodyText.text = "IP : 198.16.220.118 Port: 80 - Open\n[Type IP into browser to view]\nSystem OS : NexOS Version - 2.42.14f7\n Network ID : ==EndOfLine==\nDevices Connected : owo, -w-, :p, ;3, <3, ^-^";
                    } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[3].transform)
                        {
                            EmailTitle.text = "From Mom";
                            EmailBodyText.text = "Dear Eldest,\nHello dear, I wanted to remind you about your fathers birthday coming up in these next 2 weeks. When you're avaliable I need to talk with you about how we're setting the party up for him. Can't wait for the family to get together again soon.\nI Love You Dear - Mom";
                        } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[4].transform)
                            {
                                EmailTitle.text = "Work Message";
                                EmailBodyText.text = "Garret,\nHey dude, I hate to do this to you, but I need you to come in tomorrow at 4PM to help test our servers to ensure this honeypot idea from the higher ups doesn't backfire and we run into complications like last month, you remember how much crap corporate gave us for the backups failing.\nPS Gary, June, Markus, and Sal will also be there so you're not alone tomorrow";
                            } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[5].transform) // triggered when at least two people are triggered at least once
                                {
                                    EmailTitle.text = "Unknown Sender";
                                    EmailBodyText.text = "[REDACTED]\nYou're being curious, I'm only going to ask that you'd stop.\nNext time if I have to come to you it will not be this friendly.";
                                } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[6].transform) // triggered via dialogue after a Fido Trigger Event
                                    {
                                        EmailTitle.text = "Clip from Fido";
                                        EmailBodyText.text = "omgLoL.mov (1.83MB)";
                                    } else if (MyCursor.GetComponent<ComputerCursor>().objectHit == EmailSelection[7].transform)
                                        {
                                            EmailTitle.text = "Why are you doing this?"; // triggered when all 3 about triggered twice
                                            EmailBodyText.text = "So. . .\nGuess you're not quick to the memo. . .\nFine then, if you havent already, come then. . .\nChannel Four, I'll be waiting. . .";
                                            ChatApp.transform.GetComponent<CHAT_app_script>().MasterMindEnding();
                                            Clock.SetActive(false);
                                        };
        }

        yield return new WaitForSeconds(1.5f);
    }
}//EndScript