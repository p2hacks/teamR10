using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultSceneController : MonoBehaviour
{
    GameObject Saku;
    GameObject Switch;

    GameObject blackBackGround;

    private static int koukando = GAMEMAIN.GetKoukando(); //好感度のパラメータ
    private static int studyKoukando = GAMEMAIN.GetStudyKoukando(); // 主人公の勉強パラメータ
    private static int gameKoukando = GAMEMAIN.GetGameKoukando(); // 主人公のゲームパラメータ
    private static int sportKoukando = GAMEMAIN.GetSportKoukando(); // 主人公のスポーツパラメータ


    int BackHideDelay = 0;
    bool isBackHideDelay = true;

    // Start is called before the first frame update
    void Start()
    {

        blackBackGround = GameObject.Find("BlackBackground");

        if (koukando > 0)
        {
            Saku = GameObject.Find("Saku");
            ResultSaku();
        }
        else
        {
            Switch = GameObject.Find("Switch");
            ResultSwitch();
        }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ChooseDifficultyController.difficultyBorder);

        if (isBackHideDelay) BackHideDelay++;

        if(BackHideDelay > 30) //30フレーム（0.5秒）たったら隠す画像を非アクティブにする
        {
            blackBackGround.SetActive(false);
            Debug.Log("setactive false");
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
