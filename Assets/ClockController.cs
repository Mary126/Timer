using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public GameObject clock;
    public GameObject minuteArrowBody;
    public GameObject hourArrowBody;
    public GameObject secondsArrowBody;

    public GameObject minuteArrow;
    public GameObject hourArrow;
    public GameObject secondsArrow;

    public void SetTime(int seconds, int minutes, int hours)
    {
        float rotAngleMin = (minutes * 60 + seconds) / 10.0f;
        minuteArrowBody.transform.Rotate(0.0f, 0.0f, -rotAngleMin);
        minuteArrow.GetComponent<ArrowController>().angle = -rotAngleMin;

        float rotAngleHour = ((hours % 12) * 60 + minutes) / 2.0f;
        hourArrowBody.transform.Rotate(0.0f, 0.0f, -rotAngleHour);
        hourArrow.GetComponent<ArrowController>().angle = -rotAngleHour;

        float rotAngleSec = seconds * 6.0f;
        secondsArrowBody.transform.Rotate(0.0f, 0.0f, -rotAngleSec);
        secondsArrow.GetComponent<ArrowController>().angle = -rotAngleSec;
    }
}
