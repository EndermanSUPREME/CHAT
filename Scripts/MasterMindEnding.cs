using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMindEnding : MonoBehaviour
{
    public GameObject GameScreen, EndingScreen;

    void Start()
    {
        GameScreen.SetActive(true);
        EndingScreen.SetActive(false);
    }

    public void MasterMindEndingFunct()
    {
        StartCoroutine(TrueEnd());
    }

    IEnumerator TrueEnd()
    {
        yield return new WaitForSeconds(2);

        GameScreen.SetActive(false);
        EndingScreen.SetActive(true);
    }
}//EndScript