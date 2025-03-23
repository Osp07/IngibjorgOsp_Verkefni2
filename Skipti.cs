using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja");
        //IÖ - þegar leikmaður hefur leik kemur upp textinn byrja
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());
        //IÖ - ef að leikmaður kemur við trigger fer hann yfir í næstu senu
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurræsa();
        //IÖ - leikmaður býður í þrjár sekúndur áður en hann hoppar yrfir í næstu senu
    }
    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//næsta sena
        //IÖ - ef kallað er á fallið Endurræsa() fer leikmaður á næstu senu
    }

}
