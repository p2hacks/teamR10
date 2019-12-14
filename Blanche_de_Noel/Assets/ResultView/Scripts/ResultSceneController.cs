using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultSceneController : MonoBehaviour
{
    GameObject Saku;
    GameObject Switch;

    GameObject blackBackGround;

    int BackHideDelay = 0;
    bool isBackHideDelay = true;

    // Start is called before the first frame update
    void Start()
    {
        if (ChooseDifficultyController.difficultyBorder > 0)
        {
            Saku = GameObject.Find("Saku");
            ResultSaku();
        }
        else
        {
            Switch = GameObject.Find("Switch");
            ResultSwitch();
        }

        blackBackGround = GameObject.Find("BlackBackground");


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ChooseDifficultyController.difficultyBorder);

        if (isBackHideDelay) BackHideDelay++;

        if(BackHideDelay > 20) //20フレーム（0.33秒）たったら隠す画像を非アクティブにする
        {
            blackBackGround.SetActive(false);
            isBackHideDelay = false;
        }
    }

    public void ResultSaku()
    {
        Saku.gameObject.transform.Translate(0.0f, 0.0f, -20.0f);
    }

    public void ResultSwitch()
    {
        Switch.gameObject.transform.Translate(0.0f, 0.0f, -20.0f);
    }

    

    //void ResultPresentMove()
    //{
    //    Present.gameObject.transform.Translate(0.0f, p_move, 0.0f);
    //    Debug.Log("Presentのxは" + Present.transform.position.y);
    //    if (Present.transform.position.y > 0.0f)
    //    {
    //        x = x + 0.001f;
    //        p_move = p_move - x * x;
    //    }
    //    else if (Present.transform.position.y < 0.0f)
    //    {
    //        p_move = 0.0f;
    //        EnableNextButton();
    //    }
    //}
}
