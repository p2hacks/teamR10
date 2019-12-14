using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultStar6Controller : MonoBehaviour
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

    public float alpha = 0.0f;

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


        SuperCar = GameObject.FindWithTag("SuperCar").GetComponent<SpriteRenderer>();

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

            ResultSuperCar();
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
