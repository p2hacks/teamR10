using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayText : MonoBehaviour
{
    public Text dayshow;
    DayController dayController;
    

    // Start is called before the first frame update
    void Start()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpDateDay();
    }

    public void UpDateDay()
    {
        switch (dayController.GetDay())
        {
            case 15:
                dayshow.text = "12/15";
                break;

            case 16:
                dayshow.text = "12/16";
                break;

            case 17:
                dayshow.text = "12/17";
                break;

            case 18:
                dayshow.text = "12/18";
                break;

            case 19:
                dayshow.text = "12/19";
                break;

            case 20:
                dayshow.text = "12/20";
                break;

            case 21:
                dayshow.text = "12/21";
                break;

            case 22:
                dayshow.text = "12/22";
                break;

            case 23:
                dayshow.text = "12/23";
                break;

            case 24:
                dayshow.text = "12/24";
                break;

            case 25:
                dayshow.text = "12/25";
                break;

            default:
                break;

        }
    }
}
