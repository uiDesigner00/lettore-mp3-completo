using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class lettore_mp3 : MonoBehaviour
{
    AudioSource gestore_canzoni;

    int brano_attuale = 0;

    public AudioClip[] nome_brano;

    public RawImage[] nome_immagine;

    public TMP_Text txt_aggiornamento_canzone, txt_durata_canzone, txt_aggiornamento_canzone_zoom, txt_durata_canzone_zoom, txt_nome_canzone;

    public Slider metraggio_brano, cursore_brano;

    public RawImage img_album_generico;

    private bool stop = false;

    void Start()
    {
        gestore_canzoni = GetComponent<AudioSource>();

        img_album_generico = GetComponent<RawImage>();
    }

    void Update()
    {
        if (!stop)
        {   
            metraggio_brano.value = gestore_canzoni.time;

            cursore_brano.value = gestore_canzoni.time;

            txt_aggiornamento_canzone.text = metraggio_brano.value.ToString();

            txt_aggiornamento_canzone_zoom.text = metraggio_brano.value.ToString();

            if (metraggio_brano.value >= gestore_canzoni.clip.length)
            {
                if (brano_attuale >= nome_brano.Length)
                {
                    brano_attuale = 0;

                    produci_brano_singolo();
                }
            }
        }
    }

    public void produci_brano_singolo(int cambia_brano = 0)
    {
        brano_attuale += cambia_brano;

        gestore_canzoni.loop = false;

        foreach(var variableName in nome_brano)
        {
            brano_attuale = cambia_brano;
        }

        if (stop)
        {
            stop = false;
        }

        gestore_canzoni.clip = nome_brano[brano_attuale];

        txt_nome_canzone.text = gestore_canzoni.clip.name;

        txt_durata_canzone.text = gestore_canzoni.clip.length.ToString();

        txt_durata_canzone_zoom.text = gestore_canzoni.clip.length.ToString();

        metraggio_brano.maxValue = gestore_canzoni.clip.length;

        cursore_brano.maxValue = gestore_canzoni.clip.length;

        metraggio_brano.value = 0.00f;

        cursore_brano.value = 0.00f;

        gestore_canzoni.Play();
    }

    public void produci_brano_playlist(int cambia_brano = 0)
    {
        brano_attuale += cambia_brano;

        gestore_canzoni.loop = false;

        if (brano_attuale >= nome_brano.Length)
        {
            brano_attuale = 0;
        }

        else if (brano_attuale < 0)
        {
            brano_attuale = nome_brano.Length - 1;
        }

        if (gestore_canzoni.isPlaying && cambia_brano == 0)
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        gestore_canzoni.clip = nome_brano[brano_attuale];

        txt_nome_canzone.text = gestore_canzoni.clip.name;

        txt_durata_canzone.text = gestore_canzoni.clip.length.ToString();

        txt_durata_canzone_zoom.text = gestore_canzoni.clip.length.ToString();

        metraggio_brano.maxValue = gestore_canzoni.clip.length;

        cursore_brano.maxValue = gestore_canzoni.clip.length;

        metraggio_brano.value = 0.00f;

        cursore_brano.value = 0.00f;

        gestore_canzoni.Play();
    }

    public void ferma_brano()
    {
        gestore_canzoni.Stop();

        stop = true;

        txt_nome_canzone.text = "SELECT A SONG";

        metraggio_brano.value = 0.00f;

        cursore_brano.value = 0.00f;

        txt_aggiornamento_canzone.text = "0";

        txt_durata_canzone.text = "0.00";

        txt_aggiornamento_canzone_zoom.text = "0";

        txt_durata_canzone_zoom.text = "0.00";
    }

    public void pausa_brano()
    {
        if (gestore_canzoni.isPlaying == true)
        {
            gestore_canzoni.Pause();
        }

        else
        {
            gestore_canzoni.PlayScheduled(gestore_canzoni.clip.length);

            if (stop)
            {
                gestore_canzoni.Pause();
            }
        }
    }

    public void ripeti_brano()
    {
        if (gestore_canzoni.isPlaying == true)
        {
            gestore_canzoni.loop = true;
        }
    }

    public void controlla_brano_1(float time)
    {
        metraggio_brano.value += time;

        gestore_canzoni.time = metraggio_brano.value;
    }

    public void controlla_brano_2(float time)
    {
        cursore_brano.value += time;

        gestore_canzoni.time = cursore_brano.value;
    }
}
