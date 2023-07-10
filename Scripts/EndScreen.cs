using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private string startString;

    void Start()
    {
        startString = transform.GetComponent<Text>().text;
        StartCoroutine(LoadText(transform.GetComponent<Text>().text));
    }

    private IEnumerator LoadText(string sentence)
    {
        string newText = "";
        foreach (char letter in sentence.ToCharArray())
        {
            newText += letter;
            transform.GetComponent<Text>().text = newText;
            yield return new WaitForSeconds(0.085f);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}//EndScript