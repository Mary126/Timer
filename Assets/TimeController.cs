using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class TimeController : MonoBehaviour
{
    private const string URL = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";
    public int minute;
    public int hour;
    public int seconds;
    public ClockController clock;
    public void GetTime()
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
                Destroy(clock.minuteArrow);
                Destroy(clock.hourArrow);
                Destroy(clock.secArrow);
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);
                minute = (int)itemsData["minute"];
                hour = (int)itemsData["hour"];
                seconds = (int)itemsData["seconds"];
                clock.GenerateArrows(seconds, minute, hour);
            }
        }
    }
    private void ChangeTime()
    {
        GetTime();
    }
    private void Start()
    {
        clock = GetComponent<ClockController>();
        GetTime();
        InvokeRepeating("ChangeTime", 0.0f, 1.0f);
    }
}
