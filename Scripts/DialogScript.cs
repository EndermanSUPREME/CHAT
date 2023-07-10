using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogScript : MonoBehaviour
{
    [SerializeField] [TextArea(14, 10)] string[] dialogText;
    [SerializeField] int currentIndex, eventIndex;
    [SerializeField] Text AI_Text;

    [SerializeField] UnityEvent GameEvent = new UnityEvent();

    public string currentSentence;

    public bool TestSwitch;
    private bool EmailSent = false;

    void Start()
    {
        AI_Text.text = "";
        StartCoroutine(LoadText());
    }

    void Update()
    {
        // Tests fluidity of dialog transition
        if (TestSwitch == true)
        {
            GetNextText();
            TestSwitch = false;
        }

        // takes the object connected to the script (in this case a UI Text obj. and checks if the text EQUALS the string of the pulled array index values)
        if (AI_Text.text == dialogText[eventIndex] && EmailSent == false)
        {
            // allows me to hook objects that connect to scripts with public methods that I can execute
            GameEvent.Invoke();
            EmailSent = true;
        }
    }

    // this Coroutine is what generates the dialog one character or CHAR at a time per frame
    IEnumerator LoadText()
    {
        currentSentence = dialogText[currentIndex];

            if (AI_Text.text != currentSentence)
            {
                foreach (char letter in currentSentence.ToCharArray())
                {
                    AI_Text.text += letter;
                    yield return null;
                }
            }
    }

    // simply increases the index integer thats used to pull a desired index of the string[] (array) as well as resetting the UI_Text.text to blank and Starts the coroutine
    public void GetNextText()
    {
        if (AI_Text.text == currentSentence)
        {
            StopCoroutine(LoadText());
            if (currentIndex < (dialogText.Length - 1))
            {
                AI_Text.text = "";
                currentIndex++;
                
                StartCoroutine(LoadText());
            }
        }
    }
}//EndScript