using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TitleViewController : MonoBehaviour
{

    Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
    }

    private float x = 0.0f;
    private float y = 0.0f;

    public bool isMovementOn = true;

    // Update is called once per frame
    void Update()
    {
        if (isMovementOn) x += 0.1f;
        else x -= 0.1f;
        if (isMovementOn) y -= 0.1f;
        else y += 0.1f;

        if(x < -8.9f){
            x += 0.1f;
        }
        if (x > 8.9f)
        {
            x -= 0.1f;
        }
        if(y < -5.0f){
            y += 0.1f;
        }
            if (x > 5.0f)
            {
                y -= 0.1f;
            }
        this.transform.position = new Vector3(x, y, 0);
    }

    public void turnMovementButton()
    {
        if (isMovementOn)
        {
            isMovementOn = false;
        }

        else
        {
            isMovementOn = true;
        }

    }
}
