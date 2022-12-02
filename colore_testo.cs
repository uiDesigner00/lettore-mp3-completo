using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class colore_testo : MonoBehaviour
{
    public TMP_Text[] testo_pulsante0;

    public Slider metraggio_brano, cursore_brano;

    AudioSource gestore_canzoni;

    int testo_attuale;

    private bool stop = false;

    public void cambia_colore_testo(int cambia_testo)
    {
        testo_attuale += cambia_testo;

        foreach (var variableName in testo_pulsante0)
        {
            testo_attuale = cambia_testo;
        }

        if (stop)
        {
            stop = false;
        }

        testo_pulsante0[testo_attuale].color = Color.black;
    }
}
