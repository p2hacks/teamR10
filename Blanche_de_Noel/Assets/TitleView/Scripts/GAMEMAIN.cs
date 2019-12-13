using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMAIN : MonoBehaviour
{
    private static int koukando = 0; //好感度のパラメータ

    private static bool koukandoTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private static void Update()
    {
        
    }

    public static int GetKoukando() => koukando; //好感度のゲッター
    public static void AddKoukando(int n)
    {
        if (koukandoTrigger)
        {
            koukando += n; //好感度のセッター//引数にどれだけ上がるかを渡す
            koukandoTrigger = false;
        }
    }

    public static void ResetKoukandoTrigger() => koukandoTrigger = true;
}
