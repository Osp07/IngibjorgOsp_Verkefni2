using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti;
   
    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString();
            //IÖ - þegar leikmaður er komin á senu númer þrjú kemur upp texti sem birtir lokastig
        }
        
    }
    public void Byrja()
    {
        SceneManager.LoadScene(1);
        //IÖ - ef að leikmaður ýtir á hnapp til að byrja fer hann á senu 1
    }
    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
        //IÖ - ef að leikmaður ýtir á hnapp til að enda leiksins núllstillast öll stig og leikmaður hoppar inn á byrjunarsenuna
    }
    
}
