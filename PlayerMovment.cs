using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;//IÖ - breyta sem skilgreinir hraðan þegar leikmaður hreyfir sig áfram eða afturábak
    public float sideways = 0.2f;//IÖ - breyta sem skilgreinir hraðan á leikmanni þegar hann hreyfir sig til hliðana
    public float jump = 0.2f;//IÖ - breyta sem skilgreinir hraða hoppa leikmannsins
    //private Rigidbody leikmadur;
    public static int count;
    //IÖ - notum count til að halda utan um fjölda stiga leikmannsins
    public TextMeshProUGUI countText;
    //IÖ - notum countText sem textan sem sýnir hve mörg stig leikmaður hefur

    void Start()
    {
        Debug.Log("byrja");//IÖ - í byrjun leiksins er brentaður út texti sem segir byrja
    }
    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed ;
            //IÖ - ef að ýtt er á upp örina keyrir leikmaður áfram á þeim hraða sem við skilgreinum í unity með public floatinu speed
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;//IÖ - leikmaður keyrist afturábak ef að
            //IÖ - ef að ýtt er á niður örina keyrir leikmaður áfram á þeim hraða sem við skilgreinum í unity með public floatinu speed
        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
            //IÖ - ef að ýtt er á hægri örina keyrir leikmaður áfram á þeim hraða sem við skilgreinum í unity með public floatinu sideways
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
            //IÖ - ef að ýtt er á vinstri örina keyrir leikmaður áfram á þeim hraða sem við skilgreinum í unity með public floatinu sideways
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position +=transform.up *jump;
            //IÖ - ef að ýtt er á bil takkan hoppar leikmaður upp um y ásin á þeim hraða sem við skilgreinum í unity með public floatinu jump
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump;
        }
        //hér rétti ég playerinn við ef hann dettur
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 2, 0));
            //IÖ - ef að ýtt er á takkan f snýr leikmaður sér til hægri um y ásin
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -2, 0));
            //IÖ - ef að ýtt er á takkan g snýr leikmaður sér til vinstri um y ásin
        }
        if (Input.GetKey("q"))// ef ýtt er á q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //IÖ - leikmaður réttir sig við ef að ýtt er á q
        }
       
        if (transform.position.y <= -1)
        {
            Endurræsa();
            //IÖ - ef að leikmaður fer út fyrir borðið á y ásnum (semsagt dettur út af borðinu) fer hann á senu 1
        }
        
    }
   
      void OnCollisionEnter(Collision collision)
     {
         // ef player keyrir á object sem heitir hlutur
         if (collision.collider.tag == "hlutur")
         {
             collision.collider.gameObject.SetActive(false);
             count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
             //IÖ - ef leikmaður klessir á hlut safnast eitt stig
         }
         if (collision.collider.tag == "peningur")
         {
             collision.collider.gameObject.SetActive(false);
             count = count + 5;
             //Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
             //IÖ - ef að leikmaður klessir á hlut merktan sem peningur safnast 5 stig
         }
         if (collision.collider.tag == "hindrun")
         {
             collision.collider.gameObject.SetActive(false);
             count = count -3;
             //Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
             //IÖ - ef að leikmaður klessir á hlut merktan sem hindrun missir hann 3 stig
         }
     }

     void SetCountText()
     {
         countText.text = "Stig: " + count.ToString();
         // birtum fjölda stiga sem texta inn á leikmyndinni

         if (count <= 0)
         {
             this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
             countText.text = "Dauður " + count.ToString()+" stigum";
             //IÖ - ef að leikmaður fær minna en 0 stig kemur upp texti sem segir að leikmaður er dauður og hve mörg stig hann er með í mínus
             //IÖ - leikmaður getur ekki hreyft sig ef að stigin eru í 0 eða lægra

             StartCoroutine(Bida());
             //IÖ - bíðum aðeins áður en að leikmaður fer yfir á byrjunarsenuna

         }

     }
     IEnumerator Bida()
     {
         yield return new WaitForSeconds(2);
         Endurræsa();
         //IÖ - leikmaður býður í tvær sekúndur áður en hann fer á byrjunarsenunna

     }

     public void Byrja()
     {
         SceneManager.LoadScene(1);
         //IÖ - leikmaður fer á senu 1 ef kallað er á fallið byrja()
     }
     public void Endurræsa()
     {
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
         SceneManager.LoadScene(0);
         //IÖ - ef að kallað er á fallið Endurræsa() fer leikmaður yfir á byrjunarsenuna
     }
    
}
