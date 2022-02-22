using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class TimeController : MonoBehaviour
{
    private const string URL = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";
    public int minute;
    public int hour;
    public int seconds;

    public InputField minuteText;
    public InputField hourText;
    public InputField secondsText;
    public ClockController clock;
    public void SetTime()
    {
        StartCoroutine(ProcessRequest(URL));
    }

    private IEnumerator ProcessRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);
                minute = (int)itemsData["minute"];
                hour = (int)itemsData["hour"];
                seconds = (int)itemsData["seconds"];
                clock.SetTime(seconds, minute, hour);
            }
        }
    }
    public void DisplayTime()
    {
        minuteText.text = minute.ToString();
        hourText.text = hour.ToString();
        secondsText.text = seconds.ToString();
    }
    private void Start()
    {
        clock = GetComponent<ClockController>();
        SetTime();
    }
    private void Update()
    {
    }
}
