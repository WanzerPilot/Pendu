using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CurrentTimeDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text currentTime;

    void Update()
    {
        //*currentTime.text = "000:3C:" + DateTime.Now.ToString() + "</>"; //Affiche la date et l'heure
        currentTime.text = "000:3C:" + DateTime.Now.ToLongTimeString() + "</>"; //Affiche seulement l'heure
    }
}
