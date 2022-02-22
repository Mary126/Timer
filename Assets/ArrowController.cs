using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public string type;
    public TimeController timeController;
    public float angle;
    public GameObject arrowBody;
    public float rotationSpeed;

    private void OnMouseDrag()
    {
        float ZaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        arrowBody.transform.Rotate(0, 0, ZaxisRotation);
        if (arrowBody.transform.eulerAngles.z <= 180f)
        {
            angle = arrowBody.transform.eulerAngles.z;
        }
        else
        {
            angle = arrowBody.transform.eulerAngles.z - 360f;
        }
        if (type == "seconds")
        {
            int seconds = (int)(angle / 6.0f);
            if (seconds > 0) seconds = 60 - seconds;
            else seconds = Mathf.Abs(seconds);
            timeController.seconds = seconds;
        }
        else if (type == "minutes")
        {
            int minutes = (int)((angle * 10 - timeController.seconds) / 60);
            if (minutes > 0) minutes = 60 - minutes;    
            else minutes = Mathf.Abs(minutes);
            timeController.minute = minutes;
        }
        else if (type == "hours")
        {
            int hours = (int)((angle * 2 - timeController.minute) / 60);
            if (hours > 0) hours = 12 - hours;
            else hours = Mathf.Abs(hours);
            if (timeController.hour > 12) hours = 12 + hours;
            timeController.hour = hours;
        }
        timeController.DisplayTime();
    }
}
