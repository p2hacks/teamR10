using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMAIN : MonoBehaviour
{
    private static int koukando = 0; //母親の好感度のパラメータ
    private static int studyKoukando = 0; // 主人公の勉強パラメータ
    private static int gameKoukando = 0; // 主人公のゲームパラメータ
    private static int sportKoukando = 0; // 主人公のスポーツパラメータ

    private static int day = 1; //　経過日数

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this); //シーンが変わってもこのスクリプトを消さずにアクセスできるようにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetDay() => day; // 経過日数のゲッター
    public static void SetDay(int n) => day += n; // 経過日数のセッター

    public static int GetKoukando() => koukando; //好感度のゲッター
    public static void AddKoukando(int n) => koukando += n; //好感度のセッター//引数にどれだけ上がるかを渡す

    public static int GetStudyKoukando() => studyKoukando; //勉強パラメータのゲッター
    public static void AddStudyKoukando(int n) => studyKoukando += n; //勉強パラメータのセッター//引数にどれだけ上がるかを渡す

    public static int GetGameKoukando() => gameKoukando; //　ゲームパラメータのゲッター
    public static void AddGameKoukando(int n) => gameKoukando += n; //ゲームパラメータのセッター//引数にどれだけ上がるかを渡す

    public static int GetSportKoukando() => sportKoukando; // スポーツパラメータのゲッター
    public static void AddSportKoukando(int n) => sportKoukando += n; // スポーツパラメータのセッター//引数にどれだけ上がるかを渡す


}
