﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayText : MonoBehaviour
{
    public Text dayshow;
    //DayController dayController = new DayController();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpDateDay();
    }

    public void UpDateDay()
    {
        switch (GAMEMAIN.GetDay())
        {
            case 1:
                dayshow.text = "1日目";
                break;

            case 2:
                dayshow.text = "2日目";
                break;

            case 3:
                dayshow.text = "3日目";
                break;

            /*case 4:
                dayshow.text = "4日目";
                break;

            case 5:
                dayshow.text = "5日目";
                break;

            case 6:
                dayshow.text = "6日目";
                break;

            case 7:
                dayshow.text = "7日目";
                break;*/
            default:
                break;

        }
    }
}
