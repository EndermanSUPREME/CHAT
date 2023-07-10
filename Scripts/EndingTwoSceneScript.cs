using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingTwoSceneScript : MonoBehaviour
{
    public GameObject bloodSplat, Credits, EndingTwoScreen;
    public Image FadeObj;
    public AudioSource gunshotSound;
    private bool startToFade;
    public float alpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        Credits.SetActive(false);
        gunshotSound.volume = PlayerPrefs.GetFloat("SFXVol");
        bloodSplat.SetActive(false);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3.25f);
        gunshotSound.Play();
        bloodSplat.SetActive(true);
        startToFade = true;
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;

        if (startToFade == true)
        {
            Color currentColor = new Color(0, 0, 0, alpha);
            FadeObj.color = currentColor;
            alpha += 0.008f;
        }

        if (alpha >= 1)
        {
            EndingTwoScreen.SetActive(false);
            Credits.SetActive(true);
        }
    }
}//EndScript