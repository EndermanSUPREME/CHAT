using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerBootUp : MonoBehaviour
{
    [SerializeField] Image ComputerBody;
    [SerializeField] Sprite ComputerOff, ComputerOn, ComputerLoaded;
    [SerializeField] Text UI_Text;
    [SerializeField] Scrollbar bar;
    [SerializeField] string beginningDialogue, ComputerBootUpText;
    [SerializeField] GameObject TextPannelForBootUp, LoginObject;
    public float delay, bumper;
    public int systemOn = 0;
    private bool StartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        ComputerBody.sprite = ComputerOff;
        TextPannelForBootUp.SetActive(true);
        LoginObject.SetActive(false);
        UI_Text.text = "";
        StartCoroutine(LoadDialogue(beginningDialogue));
    }

    private IEnumerator LoadDialogue(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            UI_Text.text += letter;
            if (UI_Text.text == "Shutting Down. . .")
            {
                Application.Quit();
            } else if (UI_Text.text == ComputerBootUpText)
                {
                    CoreGame();
                }
            yield return new WaitForSeconds(delay);
        }
    }

    void Update()
    {
        AutoScroll();

        bool Enter = Input.GetKeyDown(KeyCode. Return); // KeyCode.Return => EnterKey
        if (Enter && StartGame != true)
        {
            CoreGame();
        }
    }

    private void AutoScroll()
    {
        if (systemOn == 2)
        {
            if (bar.value > 0)
            {
                bar.value -= (bumper / 1500); // 0.05 or lower
            } else
                {
                    bar.value = 0;
                }
        }
    }

    private void CoreGame()
    {
        UI_Text.text = "";
        TextPannelForBootUp.SetActive(false);
        StartGame = true;
        ComputerBody.sprite = ComputerLoaded;
        LoginObject.SetActive(true);
        transform.GetComponent<ComputerBootUp>().enabled = false;
        StopAllCoroutines();
    }

    public void PowerOn()
    {
        switch (systemOn)
        {
            case 1:
                UI_Text.text = "";
                delay = delay / 25;
                StartCoroutine(LoadDialogue(ComputerBootUpText));
                systemOn++;
                ComputerBody.sprite = ComputerOn;
            break;
            case 2:
                StopAllCoroutines();
                systemOn++;
                UI_Text.text = "";
                bar.value = 1;
                delay = 0.075f;
                StartCoroutine(LoadDialogue("Shutting Down. . ."));
            break;
            default:
            break;
        }
    }
}//EndScript