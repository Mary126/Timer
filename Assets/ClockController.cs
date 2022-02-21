using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public GameObject bigArrow;
    public GameObject smallArrow;
    public GameObject secondsArrow;
    public GameObject clock;

    public GameObject minuteArrow;
    public GameObject hourArrow;
    public GameObject secArrow;

    public void GenerateArrows(int seconds, int minutes, int hours)
    {
        minuteArrow = Instantiate(bigArrow);
        minuteArrow.transform.SetParent(clock.transform);
        float rotAngleMin = minutes * 6.0f;
        minuteArrow.transform.Rotate(0.0f, 0.0f, -rotAngleMin);

        hourArrow = Instantiate(smallArrow);
        hourArrow.transform.SetParent(clock.transform);
        float rotAngleHour = (hours % 12) * 30.0f;
        hourArrow.transform.Rotate(0.0f, 0.0f, -rotAngleHour);

        secArrow = Instantiate(secondsArrow);
        secArrow.transform.SetParent(clock.transform);
        float rotAngleSec = seconds * 6.0f;
        secArrow.transform.Rotate(0.0f, 0.0f, -rotAngleSec);

    }
}
