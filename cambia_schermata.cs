using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambia_schermata : MonoBehaviour
{
    public void cambia_scena(int indice_schermata)
    {
        SceneManager.LoadScene(indice_schermata);
    }
}
