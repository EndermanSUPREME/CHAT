using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetPageScript : MonoBehaviour
{
    [SerializeField] Text consoleText, addressBar;
    [SerializeField] InputField inputfield;
    [SerializeField] GameObject[] WebResults;
    public GameObject InternetContentPage;
    public int websiteIndex;

    void Start()
    {
        if (InternetContentPage.active == false)
        {
            addressBar.text = "Enter web address";

            for (int i = 0; i < WebResults.Length; i++)
            {
                WebResults[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        bool Enter = Input.GetKeyDown(KeyCode. Return);
        if (Enter && consoleText.text != "")
        {
            StartCoroutine(EnterLineToConsole(consoleText.text));
            clear();
        }
    }

    private IEnumerator EnterLineToConsole(string webAddress)
    {
        addressBar.text = webAddress;

        switch (webAddress)
        {
            case "215.524.16.244":
                websiteIndex = 1;
                // WebResults[1].SetActive(true);
            break;
            case "152.24.168.89":
                websiteIndex = 2;
                // WebResults[2].SetActive(true);
            break;
            case "198.16.220.118":
                websiteIndex = 3;
                // WebResults[3].SetActive(true);
            break;
            default:
                clear();
                websiteIndex = 0;
                // WebResults[0].SetActive(true); //Object carried pretyped error code
            break;
        }

        for (int i = 0; i < WebResults.Length; i++)
        {
            if (WebResults[websiteIndex] == WebResults[i])
            {
                WebResults[i].SetActive(true);
            } else
                {
                    WebResults[i].SetActive(false);
                }
        }

        yield return new WaitForSeconds(1);
    }

    void clear()
    {
        inputfield.Select();
        inputfield.text = "";
    }
}//EndScript