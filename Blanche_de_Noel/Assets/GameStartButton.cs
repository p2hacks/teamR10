using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    GameObject titleImage;

    // Start is called before the first frame update
    void Start()
    {
        titleImage = GameObject.Find("TitleImage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnMovementButton()
    {

        titleImage.GetComponent<TitleViewController>().turnMovementButton();
    }
}
