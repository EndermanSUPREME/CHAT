using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Script : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool Opened = false;
    public GameObject MainClip;
    public GameObject[] Videos;
    int i = 0;

    void Start()
    {
        videoPlayer.enabled = false;
        MainClip.SetActive(false);
        for (int i = 0; i < Videos.Length; i++)
        {
            Videos[i].SetActive(false);
        }
    }

    // private IEnumerator Pause()
    // {
    //     // yield return new WaitForSeconds(3.25f); // after the video ends something happens
    // }
    public void OpenVideo()
    {
        videoPlayer.enabled = true;

        MainClip.SetActive(true);

        if (Opened == false)
        {
            StartCoroutine(Hack());
            Opened = true;
        }
    }

    private IEnumerator Hack()
    {
        yield return new WaitForSeconds(0.65f);

        if (i < Videos.Length)
        {
            Videos[i].SetActive(true);
            i++;
            StartCoroutine(Hack());
        }
    }
}//EndScript