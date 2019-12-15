using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultStar3Controller : MonoBehaviour
{

    SpriteRenderer SuperCar;
    SpriteRenderer PassNotice;
    SpriteRenderer Bill;
    SpriteRenderer Akahon;
    SpriteRenderer VR;
    SpriteRenderer GamingPC;
    SpriteRenderer Uniform;
    SpriteRenderer iPhone;
    SpriteRenderer PS4;
    SpriteRenderer Switch;
    SpriteRenderer Gun;
    SpriteRenderer Rasyomon;
    SpriteRenderer FamilyComputer;
    SpriteRenderer Saku;
    SpriteRenderer SoccerBall;
    SpriteRenderer Doll;


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
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            PassNotice = GameObject.Find("PassNotice").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            Bill = GameObject.Find("Bill").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            Akahon = GameObject.Find("Akahon").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            VR = GameObject.Find("VR").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            GamingPC = GameObject.Find("GamingPC").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            Uniform = GameObject.Find("Uniform").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            iPhone = GameObject.Find("iPhone").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            PS4 = GameObject.Find("PS4").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            Switch = GameObject.Find("Switch").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            Gun = GameObject.Find("Gun").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            Rasyomon = GameObject.Find("Rasyomon").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            FamilyComputer = GameObject.Find("FamilyComputer").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            Saku = GameObject.Find("Saku").GetComponent<SpriteRenderer>();
        }
        else if (
            koukando <= ChooseDifficultyController.difficultyBorder &&
            studyKoukando <= ChooseDifficultyController.difficultyBorder &&
            gameKoukando <= ChooseDifficultyController.difficultyBorder &&
            sportKoukando > ChooseDifficultyController.difficultyBorder)
        {
            SoccerBall = GameObject.Find("SoccerBall").GetComponent<SpriteRenderer>();
        }
        else if (
           koukando <= ChooseDifficultyController.difficultyBorder &&
           studyKoukando <= ChooseDifficultyController.difficultyBorder &&
           gameKoukando <= ChooseDifficultyController.difficultyBorder &&
           sportKoukando <= ChooseDifficultyController.difficultyBorder)
        {
            Doll = GameObject.Find("Doll").GetComponent<SpriteRenderer>();
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
            else if (
            koukando > ChooseDifficultyController.difficultyBorder &&
            studyKoukando > ChooseDifficultyController.difficultyBorder &&
            gameKoukando > ChooseDifficultyController.difficultyBorder &&
            sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultPassNotice();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultBill();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultAkahon();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultVR();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultGamingPC();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultUniform();
            }
            else if (
                koukando > ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultiPhone();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultPS4();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultSwitch();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultGun();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando > ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultRasyomon();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultFamilyComputer();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando > ChooseDifficultyController.difficultyBorder &&
                sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultSaku();
            }
            else if (
                koukando <= ChooseDifficultyController.difficultyBorder &&
                studyKoukando <= ChooseDifficultyController.difficultyBorder &&
                gameKoukando <= ChooseDifficultyController.difficultyBorder &&
                sportKoukando > ChooseDifficultyController.difficultyBorder)
            {
                ResultSoccerBall();
            }
            else if (
               koukando <= ChooseDifficultyController.difficultyBorder &&
               studyKoukando <= ChooseDifficultyController.difficultyBorder &&
               gameKoukando <= ChooseDifficultyController.difficultyBorder &&
               sportKoukando <= ChooseDifficultyController.difficultyBorder)
            {
                ResultDoll();
            }
        }

    }

    public void ResultSuperCar()
    {
        alpha += 0.02f;
        SuperCar.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultPassNotice()
    {
        alpha += 0.02f;
        PassNotice.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultBill()
    {
        alpha += 0.02f;
        Bill.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultAkahon()
    {
        alpha += 0.02f;
        Akahon.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultVR()
    {
        alpha += 0.02f;
        VR.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultGamingPC()
    {
        alpha += 0.02f;
        GamingPC.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultUniform()
    {
        alpha += 0.02f;
        Uniform.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultiPhone()
    {
        alpha += 0.02f;
        iPhone.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultPS4()
    {
        alpha += 0.02f;
        PS4.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultSwitch()
    {
        alpha += 0.02f;
        Switch.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultGun()
    {
        alpha += 0.02f;
        Gun.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultRasyomon()
    {
        alpha += 0.02f;
        Rasyomon.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultFamilyComputer()
    {
        alpha += 0.02f;
        FamilyComputer.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultSaku()
    {
        alpha += 0.02f;
        Saku.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultSoccerBall()
    {
        alpha += 0.02f;
        SoccerBall.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

    public void ResultDoll()
    {
        alpha += 0.02f;
        Doll.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }

}
