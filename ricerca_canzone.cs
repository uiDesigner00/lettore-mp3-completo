using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ricerca_canzone : MonoBehaviour
{
    public GameObject content_holder, search_bar;

    public GameObject[] element;

    public int total_elements;

    void Start()
    {
        total_elements = content_holder.transform.childCount;

        element = new GameObject[total_elements];

        for(int i = 0; i < total_elements; i++)
        {
            element[i] = content_holder.transform.GetChild(i).gameObject;
        }
    }

    public void cerca_canzone()
    {
        string search_text = search_bar.GetComponent<TMP_InputField>().text;

        int search_txt_length = search_text.Length;

        int searched_elements = 0;

        foreach(GameObject ele in element)
        {
            searched_elements += 1;

            if(ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length>=search_txt_length)
            {
                if(search_text==ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0, search_txt_length))
                {
                    ele.SetActive(true);
                }

                else
                {
                    ele.SetActive(false);
                }
            }
        }
    }
}
