using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTextController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 引数で与えられたメッセージを表示する
    public void DisplayMessage(string message) =>
        GetComponent<Text>().text = message;
}
