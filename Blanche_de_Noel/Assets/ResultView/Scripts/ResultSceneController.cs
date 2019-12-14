using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultSceneController : MonoBehaviour
{
    SpriteRenderer Saku;
    SpriteRenderer Switch;
    SpriteRenderer SuperCar;

    GameObject blackBackGround;

    private float alpha = 0.0f;

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


        if (koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            SuperCar = GameObject.Find("SuperCar").GetComponent<SpriteRenderer>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ChooseDifficultyController.difficultyBorder);

        if (isBackHideDelay) BackHideDelay++;

        if (BackHideDelay > 30) //30フレーム（0.5秒）たったら隠す画像を非アクティブにする
        {
            blackBackGround.SetActive(false);
            Debug.Log("setactive false");
            isBackHideDelay = false;

            if (koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultSuperCar();
            }
        }

    }

    public void ResultSuperCar()
    {
        alpha += 0.02f;
        SuperCar.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultSaku()
    {
        alpha += 0.02f;
        Saku.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultSwitch()
    {
        Switch.color = new Color(1.0f, 1.0f, 1.0f, alpha);
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
