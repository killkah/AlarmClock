using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject SelectMenu;
    [SerializeField] private GameObject OutMenu;

    [SerializeField] private int hours;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    [SerializeField] private Text hoursText;
    [SerializeField] private Text minutesText;
    [SerializeField] private Text secondsText;

    [SerializeField] private Text hoursTextOut;
    [SerializeField] private Text minutesTextOut;
    [SerializeField] private Text secondsTextOut;

    [SerializeField] private AudioSource ringtone;

    void Update()
    {
        if(hours != 0 || minutes != 0)
        {
            if(seconds == 0)
            {
                minutes -= 1;
                seconds = 59;
            }
            else if(minutes == 0)
            {
                hours -= 1;
                minutes = 59;
                seconds = 59;
            }

            
        }

        else if (hours == 0 && minutes == 0 && seconds == 0)
        {
            if (SelectMenu.activeInHierarchy == false)
            {
                ringtone.Play();
                StopCoroutine("Timer"); 
            }
        }

        hoursTextOut.text = hours.ToString();
        minutesTextOut.text = minutes.ToString();
        secondsTextOut.text = seconds.ToString();
    }

    public void StartTimer()
    {
        StartCoroutine("Timer");
        hours = Convert.ToInt32(hoursText.text);
        minutes = Convert.ToInt32(minutesText.text);
        seconds = Convert.ToInt32(secondsText.text);
        SelectMenu.SetActive(false);
        OutMenu.SetActive(true);
        Application.runInBackground = true;
    }
    public void StopTimer()
    {
        StopCoroutine("Timer");
        seconds = 59;
        ringtone.Stop();
        OutMenu.SetActive(false);
        SelectMenu.SetActive(true);
        Application.runInBackground = false;
    }

    IEnumerator Timer()
    {
        while(true)
        {
            seconds -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
