using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHAT_app_script : MonoBehaviour
{
    public GameObject[] Julie, Fido, Joe; // Various Sprites of the AI
    public GameObject MasterMind, DefaultPersonSprite, ChannelFourDialogue;
    [SerializeField] GameObject[] JuliesDialogue, FidosDialogue, JoesDialogue; // Objects that hold the dialogueScript
    public int JulieIndex, FidoIndex, JoeIndex;

    [SerializeField] Text NameOfRecipiant, consoleText, AI_Text;
    [SerializeField] InputField inputfield;

    [SerializeField] private bool OpenChannelFour = false;

    void Start()
    {
        JulieIndex = 0;
        FidoIndex = 0;
        JoeIndex = 0;

        // no chats are opened
        for (int i = 0; i < JuliesDialogue.Length; i++)
        {
            JuliesDialogue[i].SetActive(false);
        }

        for (int i = 0; i < FidosDialogue.Length; i++)
        {
            FidosDialogue[i].SetActive(false);
        }

        for (int i = 0; i < JoesDialogue.Length; i++)
        {
            JoesDialogue[i].SetActive(false);
        }

        ChannelFourDialogue.SetActive(false);
    }

    void Update()
    {
        bool Enter = Input.GetKeyDown(KeyCode. Return);
        if (Enter)
        {
            StartCoroutine(EnterLine());
        }
    }
// =========================================================================================== //
    private IEnumerator EnterLine()
    {
        if (consoleText.text.ToLower() != "")
        {
            clear();
        }
        yield return new WaitForSeconds(1);
    }

    private void clear()
    {
        SubmitText();
        inputfield.Select();
        inputfield.text = "";
    }
// =========================================================================================== //
    private void SubmitText()
    {
        // run dialogue
        if (Julie[JulieIndex].active == true)
        {
            JuliesDialogue[JulieIndex].transform.GetComponent<DialogScript>().GetNextText(); // this system allows for when events cause the index to change the dialogue also changes
        }
        if (Fido[FidoIndex].active == true)
        {
            FidosDialogue[FidoIndex].transform.GetComponent<DialogScript>().GetNextText();
        }
        if (Joe[JoeIndex].active == true)
        {
            JoesDialogue[JoeIndex].transform.GetComponent<DialogScript>().GetNextText();
        }
        if (ChannelFourDialogue.active == true)
        {
            ChannelFourDialogue.transform.GetComponent<DialogScript>().GetNextText();
        }
    }
// =========================================================================================== //
    public void ChannelOne() // when the chat buttons are clicked the code below allows everything to be surfed through so only the AI being talked to is active
    {
        NameOfRecipiant.text = "Julie";
        AI_Text.text = JuliesDialogue[JulieIndex].GetComponent<DialogScript>().currentSentence;

        for (int i = 0; i < Julie.Length; i++)
        {
            if (Julie[i] == Julie[JulieIndex])
            {
                Julie[i].SetActive(true);
            } else
                {
                    Julie[i].SetActive(false);
                }

            Fido[i].SetActive(false);
            Joe[i].SetActive(false);
        }

        for (int i = 0; i < JuliesDialogue.Length; i++)
        {
            if (JuliesDialogue[i] == JuliesDialogue[JulieIndex])
            {
                JuliesDialogue[i].SetActive(true);
            } else
                {
                    JuliesDialogue[i].SetActive(false);
                }
        }

        for (int i = 0; i < FidosDialogue.Length; i++)
        {
            FidosDialogue[i].SetActive(false);
        }

        for (int i = 0; i < JoesDialogue.Length; i++)
        {
            JoesDialogue[i].SetActive(false);
        }

        MasterMind.SetActive(false);
        DefaultPersonSprite.SetActive(false);

        ChannelFourDialogue.SetActive(false);
    }

    public void ChannelTwo()
    {
        NameOfRecipiant.text = "Fido";
        
        for (int i = 0; i < Fido.Length; i++)
        {
            if (Fido[i] == Fido[FidoIndex])
            {
                Fido[i].SetActive(true);
            } else
                {
                    Fido[i].SetActive(false);
                }

            Julie[i].SetActive(false);
            Joe[i].SetActive(false);
        }

        for (int i = 0; i < JuliesDialogue.Length; i++)
        {
            JuliesDialogue[i].SetActive(false);
        }

        for (int i = 0; i < FidosDialogue.Length; i++)
        {
            if (FidosDialogue[i] == FidosDialogue[FidoIndex])
            {
                FidosDialogue[i].SetActive(true);
            } else
                {
                    FidosDialogue[i].SetActive(false);
                }
        }

        for (int i = 0; i < JoesDialogue.Length; i++)
        {
            JoesDialogue[i].SetActive(false);
        }

        MasterMind.SetActive(false);
        DefaultPersonSprite.SetActive(false);

        ChannelFourDialogue.SetActive(false);
    }

    public void ChannelThree()
    {
        NameOfRecipiant.text = "Joe";
        
        for (int i = 0; i < Joe.Length; i++)
        {
            if (Joe[i] == Joe[JoeIndex])
            {
                Joe[i].SetActive(true);
            } else
                {
                    Joe[i].SetActive(false);
                }

            Fido[i].SetActive(false);
            Julie[i].SetActive(false);
        }

        for (int i = 0; i < JuliesDialogue.Length; i++)
        {
            JuliesDialogue[i].SetActive(false);
        }

        for (int i = 0; i < FidosDialogue.Length; i++)
        {
            FidosDialogue[i].SetActive(false);
        }

        for (int i = 0; i < JoesDialogue.Length; i++)
        {
            if (JoesDialogue[i] == JoesDialogue[JoeIndex])
            {
                JoesDialogue[i].SetActive(true);
            } else
                {
                    JoesDialogue[i].SetActive(false);
                }
        }

        MasterMind.SetActive(false);
        DefaultPersonSprite.SetActive(false);

        ChannelFourDialogue.SetActive(false);
    }

    public void ChannelFour()
    {
        if (OpenChannelFour == true)
        {
            NameOfRecipiant.text = "==o^o==";
            MasterMind.SetActive(true);
            DefaultPersonSprite.SetActive(false);
            ChannelFourDialogue.SetActive(true);
        } else
            {
                NameOfRecipiant.text = "Unavaliable";
                MasterMind.SetActive(false);
                DefaultPersonSprite.SetActive(false);
            }

        for (int i = 0; i < JuliesDialogue.Length; i++)
        {
            JuliesDialogue[i].SetActive(false);
        }

        for (int i = 0; i < FidosDialogue.Length; i++)
        {
            FidosDialogue[i].SetActive(false);
        }

        for (int i = 0; i < JoesDialogue.Length; i++)
        {
            JoesDialogue[i].SetActive(false);
        }

        for (int i = 0; i < Joe.Length; i++)
        {
            Joe[i].SetActive(false);
            Fido[i].SetActive(false);
            Julie[i].SetActive(false);
        }
    }
// =========================================================================================== //
    public void JulieEvent() // eventOne is triggered with /spoof and the file is viewed, eventTwo is triggered with the /inspect
    {
        if (JulieIndex < Julie.Length)
        {
            JulieIndex = JulieIndex + 1;
        }

        //print("Julies");
    }

    public void FidoEvent()
    {
        if (FidoIndex < Fido.Length)
        {
            FidoIndex = FidoIndex + 1;
        }

        //print("Fidos");
    }
    
    public void JoeEvent()
    {
        if (JoeIndex < Joe.Length)
        {
            JoeIndex = JoeIndex + 1;
        }

        //print("Joes");
    }
    //========================================================================================= //
    public void ResetCHATAPP()
    {
        for (int i = 0; i < Julie.Length; i++)
        {
            Joe[i].SetActive(false);
            Fido[i].SetActive(false);
            Julie[i].SetActive(false);
            NameOfRecipiant.text = "CHAT";
            AI_Text.text = "";
            DefaultPersonSprite.SetActive(true);
        }
    }

    public void MasterMindEnding()
    {
        OpenChannelFour = true;
    }
}//EndScript