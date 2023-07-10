using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ComputerCommandConsoleAppScript : MonoBehaviour
{

    [SerializeField] Text consoleText, outputText;
    [SerializeField] InputField inputfield;
    [SerializeField] GameObject[] importedFiles, virusPages;
    public GameObject CHAT_Box, juliesInfo, fidosInfo, joesInfo, InternetApp;
    UnityEvent TriggerJulie, TriggerFido, TriggerJoe;

    void Start()
    {
        outputText.text = "Start with /help to learn your console";
        consoleText.color = Color.white;
        outputText.color = new Color(128, 128, 128);

        for (int i = 0; i < importedFiles.Length; i++)
        {
            importedFiles[i].SetActive(false);
        }

        TriggerJulie = new UnityEvent();
        TriggerFido = new UnityEvent();
        TriggerJoe = new UnityEvent();

        TriggerJulie.AddListener(JuliesEventTrigger);
        TriggerFido.AddListener(FidosEventTrigger);
        TriggerJoe.AddListener(JoesEventTrigger);
    }

    void Update()
    {
        bool Enter = Input.GetKeyDown(KeyCode. Return);
        if (Enter)
        {
            StartCoroutine(EnterLineToConsole(consoleText.text.ToLower()));
            clear();
        }
    }

    private IEnumerator LoadingImportedFiles(GameObject file)
    {
        yield return new WaitForSeconds(10);
        file.SetActive(true);
    }

    private IEnumerator EnterLineToConsole(string Command)
    {
        switch (Command)
        {
            case "/help":
                clear();
                outputText.text = "/phish [email]\n/link [device number]\n/color [green or white]\n/vscan [file name] (anti-virus software)\n/spoof (May reveal information)\n/inspect (May reveal info from website)\n/cleanup (cleans up viruses)";
            break;
            case "/phish joedanial1892@dmail.com":
                clear();
                outputText.text = "An email has been sent to JoeDanial1892@dmail.com. . .\nA file will be imported to your desktop shortly. . .";
                StartCoroutine(LoadingImportedFiles(importedFiles[2]));
            break;
            case "/phish i_love_dogs@gram.net":
                clear();
                outputText.text = "An email has been sent to I_love_dogs@gram.net. . .\nA file will be imported to your desktop shortly. . .";
                StartCoroutine(LoadingImportedFiles(importedFiles[1]));
            break;
            case "/phish blondefashion12@euro.com":
                clear();
                outputText.text = "An email has been sent to BlondeFashion12@euro.com. . .\nA file will be imported to your desktop shortly. . .";
                StartCoroutine(LoadingImportedFiles(importedFiles[0]));
            break;
            case "/link 142.24.144.928":
                clear();
                outputText.text = "Connection to 142.24.144.928 secured. . .\nsysFiles loaded to desktop. . .";
            break;
            case "/link 372.29.284.22":
                clear();
                outputText.text = "Connection to 372.29.284.22 secured. . .\nsysFiles loaded to desktop. . .";
            break;
            case "/link 82.241.536.33":
                clear();
                outputText.text = "Connection to 82.241.536.33 secured. . .\nsysFiles loaded to desktop. . .";
            break;
            case "/color white":
                clear();
                consoleText.color = Color.white;
                outputText.color = new Color(128, 128, 128);
            break;
            case "/color green":
                clear();
                consoleText.color = Color.green;
                outputText.color = new Color(21, 178, 0);
            break;
            case "/vscan omgLoL.mov":
                clear();
                outputText.text = "This file may contain maleware or other dangerous software. . .";
            break;
            case "/spoof":
                if (CHAT_Box.active == true && CHAT_Box.GetComponent<CHAT_app_script>() != null)
                {
                    // print("Box On");

                    if (CHAT_Box.GetComponent<CHAT_app_script>().Julie[0].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Julie[1].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Julie[2].active == true)
                    {
                        clear();
                        outputText.text = "Users Email : BlondeFashion12@euro.com";
                    }
                    if (CHAT_Box.GetComponent<CHAT_app_script>().Fido[0].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Fido[1].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Fido[2].active == true)
                    {
                        clear();
                        outputText.text = "Users Email : I_love_dogs@gram.net";
                    }
                    if (CHAT_Box.GetComponent<CHAT_app_script>().Joe[0].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Joe[1].active == true || CHAT_Box.GetComponent<CHAT_app_script>().Joe[2].active == true)
                    {
                        clear();
                        outputText.text = "Users Email : JoeDanial1892@dmail.com";
                    }
                }
                
                if (CHAT_Box.active == false && CHAT_Box.GetComponent<CHAT_app_script>() != null)
                {
                    // print("Box Off");

                    outputText.text = "Is CHAT currently running. . ?\nIf not run CHAT before using /spoof";
                    clear();
                }
            break;
            case "/inspect":
                if (InternetApp.active == true)
                {
                    switch (InternetApp.GetComponent<InternetPageScript>().websiteIndex)
                    {
                        case 1: // website about saving the waters
                            outputText.text = "Why are you here? You shouldn't be here";
                            TriggerJulie.Invoke();
                            clear();
                        break;
                        case 2: // website about cars
                            outputText.text = "If these people catch your snooping around. . .\n God rest your soul";
                            TriggerFido.Invoke();
                            clear();
                        break;
                        case 3: // website about computers
                            outputText.text = "What do you think you're doing\nDon't you know what your doing to yourself?";
                            TriggerJoe.Invoke();
                            clear();
                        break;
                        default: // error message for bad website search with /inspect
                            outputText.text = "<!DOCTYPE html>\n<html lang='en'>\n  <head>\n    <meta charset='UTF-8'>\n    <meta name='viewport' content='width=device-width, initial-scale=1.0'>\n  </head>\n<body>  <div id='filler'>\n    <p>\n      Theres no content here\n    </p>\n  </div>\n</body>\n<html>";
                            clear();
                        break;
                    }
                } else
                    {
                        outputText.text = "Website not detected. . .";
                        clear();
                    }
            break;
            case "/cleanup":
                outputText.text = "Virus Purge Initialize. . .";
                clear();

                for (int i = 0; i < virusPages.Length; i++)
                {
                    virusPages[i].SetActive(false);
                    if (i >= virusPages.Length)
                    {
                        outputText.text = "Virus Purge Completed. . .";
                        clear();
                    }
                }
            break;
            default:
                outputText.text = consoleText.text + " Executed Unsuccessfully please try again. . .\nTry /help to get a list of commands. . .";
                clear();
            break;
        }

        yield return new WaitForSeconds(1.5f);
    }

    void clear()
    {
        inputfield.Select();
        inputfield.text = "";
    }

    void JuliesEventTrigger()
    {
        CHAT_Box.GetComponent<CHAT_app_script>().JulieEvent();
    }

    void FidosEventTrigger()
    {
        CHAT_Box.GetComponent<CHAT_app_script>().FidoEvent();
    }

    void JoesEventTrigger()
    {
        CHAT_Box.GetComponent<CHAT_app_script>().JoeEvent();
    }
}//EndScript