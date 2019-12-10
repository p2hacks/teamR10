using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMAIN : MonoBehaviour
{
    private static int koukando = 0; //好感度のパラメータ

    private static int day = 1; //

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this); //シーンが変わってもこのスクリプトを消さずにアクセスできるようにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetKoukando() => koukando; //好感度のゲッター
    public static void UpKoukando(int n) => koukando += n; //好感度のセッター//引数にどれだけ上がるかを渡す
}
