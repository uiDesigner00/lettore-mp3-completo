using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class controllo_video : MonoBehaviour
{
    VideoPlayer gestore_video;

    int video_attuale = 0;

    public VideoClip[] nome_video;

    private bool stop = false;

    public Slider metraggio_brano, cursore_brano;

    void Start()
    {
        gestore_video = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (!stop)
        {
            if (metraggio_brano.value >= gestore_video.clip.length)
            {
                if (video_attuale >= nome_video.Length)
                {
                    video_attuale = 0;

                    produci_video_singolo();
                }
            }
        }
    }

    public void produci_video_singolo(int cambia_video = 0)
    {
        video_attuale += cambia_video;

        foreach (var variableName in nome_video)
        {
            video_attuale = cambia_video;
        }

        if (stop)
        {
            stop = false;
        }

        gestore_video.clip = nome_video[video_attuale];

        gestore_video.Play();
    }

    public void produci_video_playlist(int cambia_video = 0)
    {
        video_attuale += cambia_video;

        if (video_attuale >= nome_video.Length)
        {
            video_attuale = 0;
        }

        else if (video_attuale < 0)
        {
            video_attuale = nome_video.Length - 1;
        }

        if (gestore_video.isPlaying && cambia_video == 0)
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        gestore_video.clip = nome_video[video_attuale];

        gestore_video.Play();
    }
}
