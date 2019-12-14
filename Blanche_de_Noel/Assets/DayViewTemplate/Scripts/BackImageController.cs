using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImageController : MonoBehaviour
{
    GameObject houseImage;
    GameObject daytimeParkImage;
    GameObject supermarketImage;

    // Start is called before the first frame update
    void Start()
    {
        houseImage = GameObject.Find("Back_HouseImage");
        daytimeParkImage = GameObject.Find("Back_DaytimeParkImage");
        supermarketImage = GameObject.Find("Back_SupermarketImage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 表示したい背景画像のz軸ポジションを0にして、その他のz軸ポジションを100にする

    public void ShowHouseImage()
    {
        houseImage.transform.position = new Vector3(0, 0, 0);

        daytimeParkImage.transform.position = new Vector3(0, 0, 100);
        supermarketImage.transform.position = new Vector3(0, 0, 100);
    }

    public void ShowDaytimeParkImage()
    {
        daytimeParkImage.transform.position = new Vector3(0, 0, 0);

        houseImage.transform.position = new Vector3(0, 0, 100);
        supermarketImage.transform.position = new Vector3(0, 0, 100);
    }

    public void ShowSupermarketImage()
    {
        supermarketImage.transform.position = new Vector3(0, 0, 0);

        houseImage.transform.position = new Vector3(0, 0, 100);
        daytimeParkImage.transform.position = new Vector3(0, 0, 100);
    }
}
