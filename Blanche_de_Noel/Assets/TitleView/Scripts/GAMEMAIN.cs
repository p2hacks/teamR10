using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMAIN : MonoBehaviour
{
    private static int koukando = 1; //好感度のパラメータ
    private static int studyKoukando = 1; // 主人公の勉強パラメータ
    private static int gameKoukando = 1; // 主人公のゲームパラメータ
    private static int sportKoukando = 1; // 主人公のスポーツパラメータ
    private static int day = 1; //　経過日数
    private static bool koukandoTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private static void Update()
    {
        
    }
    public static int GetDay() => day; // 経過日数のゲッター
    public static void SetDay(int n) => day += n; // 経過日数のセッター

    public static int GetKoukando() => koukando; //好感度のゲッター
    public static void AddKoukando(int n)
    {
        if (koukandoTrigger)
        {
            koukando += n; //好感度のセッター//引数にどれだけ上がるかを渡す
            koukandoTrigger = false;
        }
    }

    public static int GetStudyKoukando() => studyKoukando; //勉強パラメータのゲッター
    public static void AddStudyKoukando(int n) //勉強パラメータのセッター//引数にどれだけ上がるかを渡す
    {
        if (koukandoTrigger)
        {
            studyKoukando += n;
            koukandoTrigger = false;
        }
    }

    public static int GetGameKoukando() => gameKoukando; //　ゲームパラメータのゲッター
    public static void AddGameKoukando(int n) //ゲームパラメータのセッター//引数にどれだけ上がるかを渡す
    {
        if (koukandoTrigger)
        {
            gameKoukando += n;
            koukandoTrigger = false;
        }
    }

    public static int GetSportKoukando() => sportKoukando; // スポーツパラメータのゲッター
    public static void AddSportKoukando(int n) //スポーツパラメータのセッター//引数にどれだけ上がるかを渡す
    {
        if (koukandoTrigger)
        {
            sportKoukando += n;
            koukandoTrigger = false;
        }
    }

    public static void ResetKoukandoTrigger() => koukandoTrigger = true;
}
