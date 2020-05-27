using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timecountdown : MonoBehaviour
{
    public GameObject textDisplay1;
    public GameObject textDisplay2;
    public GameObject textDisplay3;
    public GameObject textDisplay4;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public int secondsLeft1 = 60;
    public int secondsLeft2 = 60;
    public int secondsLeft3 = 60;
    public int secondsLeft4 = 60;
    public bool takingAway1 = false;
    public bool takingAway2 = false;
    public bool takingAway3 = false;
    public bool takingAway4 = false;
    public static bool FailBoss1 = false;
    public static bool FailBoss2 = false;
    public static bool FailBoss3 = false;
    public static bool FailBoss4 = false;

    private AudioSource audioSource;
    public AudioClip audioClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (NPC.Court5 == true && NPC.Court5Passed == false)
        {
            image1.SetActive(true);
            textDisplay1.GetComponent<Text>().text = "00:" + secondsLeft1;
        }
        if (NPC.Court10 == true && NPC.Court10Passed == false)
        {
            image2.SetActive(true);
            textDisplay2.GetComponent<Text>().text = "00:" + secondsLeft2;
        }
        if (NPC.Court15 == true  && NPC.Court15Passed == false)
        {
            image3.SetActive(true);
            textDisplay3.GetComponent<Text>().text = "00:" + secondsLeft3;
        }
        if (NPC.Court20 == true && NPC.Court20Passed == false)
        {
            image4.SetActive(true);
            textDisplay4.GetComponent<Text>().text = "00:" + secondsLeft4;
        }

    }
    private void Update()
    {
        if (takingAway1 == false && secondsLeft1 > 0 && NPC.Court5 == true && NPC.Court5Passed == false)
        {
            StartCoroutine(Timetaker1());
        }
        if (takingAway2 == false && secondsLeft2 > 0 && NPC.Court10 == true && NPC.Court10Passed == false)
        {
            StartCoroutine(Timetaker2());
        }
        if (takingAway3 == false && secondsLeft3 > 0 && NPC.Court15 == true && NPC.Court15Passed == false)
        {
            StartCoroutine(Timetaker3());
        }
        if (takingAway4 == false && secondsLeft4 > 0 && NPC.Court20 == true && NPC.Court20Passed == false)
        {
            StartCoroutine(Timetaker4());
        }
        if (secondsLeft1 == 0 || NPC.Court5Passed == true)
        {
            if (secondsLeft1 == 0)
            {
                FailBoss1 = true;
                secondsLeft1 = 60;
            }
           
            textDisplay1.GetComponent<Text>().text = "";
            image1.SetActive(false);
        }
        if (secondsLeft2 == 0 || NPC.Court10Passed == true)
        {
            if (secondsLeft2 == 0)
            {
                FailBoss2 = true;
                secondsLeft2 = 60;
            }
           
            textDisplay2.GetComponent<Text>().text = "";
            image2.SetActive(false);
        }
        if (secondsLeft3 == 0 || NPC.Court15Passed == true)
        {
            if (secondsLeft3 == 0)
            {
                FailBoss3 = true;
                secondsLeft3 = 60;
            }
            
            textDisplay3.GetComponent<Text>().text = "";
            image3.SetActive(false);
        }
        if (secondsLeft4 == 0 || NPC.Court20Passed == true)
        {
            if (secondsLeft4 == 0)
            {
                FailBoss4 = true;
                secondsLeft4 = 60;
            }
            
            textDisplay4.GetComponent<Text>().text = "";
            image4.SetActive(false);
        }
        if(NPC.Court5 == true && NPC.Court5Passed==false && DyingMessage.stopEnemy == true)
        {
            secondsLeft1 = 60;
            
        }
        if (NPC.Court10 == true && NPC.Court10Passed == false && DyingMessage.stopEnemy == true)
        {
            secondsLeft2 = 60;
            
        }
        if (NPC.Court15 == true && NPC.Court15Passed == false && DyingMessage.stopEnemy == true)
        {
            secondsLeft3 = 60;
           
        }
        if (NPC.Court20 == true && NPC.Court20Passed == false && DyingMessage.stopEnemy == true)
        {
            secondsLeft4 = 60;
            
        }
        


    }
    IEnumerator Timetaker1()
    {
        takingAway1 = true;
        yield return new WaitForSeconds(1);
        secondsLeft1 -= 1;
        audioSource.PlayOneShot(audioClip);
        image1.SetActive(true);
        if (secondsLeft1 < 10)
        {
            textDisplay1.GetComponent<Text>().text = "00:0" + secondsLeft1;
        }
        else
        {
            textDisplay1.GetComponent<Text>().text = "00:" + secondsLeft1;
        }

        takingAway1 = false;
    }
    IEnumerator Timetaker2()
    {
        takingAway2 = true;
        yield return new WaitForSeconds(1);
        secondsLeft2 -= 1;
        audioSource.PlayOneShot(audioClip);
        image2.SetActive(true);
        if (secondsLeft2 < 10)
        {
            textDisplay2.GetComponent<Text>().text = "00:0" + secondsLeft2;
        }
        else
        {
            textDisplay2.GetComponent<Text>().text = "00:" + secondsLeft2;
        }

        takingAway2 = false;
    }
    IEnumerator Timetaker3()
    {
        takingAway3 = true;
        yield return new WaitForSeconds(1);
        secondsLeft3 -= 1;
        audioSource.PlayOneShot(audioClip);
        image3.SetActive(true);
        if (secondsLeft3 < 10)
        {
            textDisplay3.GetComponent<Text>().text = "00:0" + secondsLeft3;
        }
        else
        {
            textDisplay3.GetComponent<Text>().text = "00:" + secondsLeft3;
        }

        takingAway3 = false;
    }
    IEnumerator Timetaker4()
    {
        takingAway4 = true;
        yield return new WaitForSeconds(1);
        secondsLeft4 -= 1;
        audioSource.PlayOneShot(audioClip);
        image4.SetActive(true);
        if (secondsLeft4 < 10)
        {
            textDisplay4.GetComponent<Text>().text = "00:0" + secondsLeft4;
        }
        else
        {
            textDisplay4.GetComponent<Text>().text = "00:" + secondsLeft4;
        }

        takingAway4 = false;
    }
}
