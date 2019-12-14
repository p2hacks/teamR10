using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayPatternController : MonoBehaviour
{
    /*
    万が一，DayControllerが大きすぎて動作が不安定になった（記述してあるはずのコードが動かないなど）場合
    全てのDayPattern関数をこちらに避難させる
    */

    DayController dayController;

    // Start is called before the first frame update
    void Start()
    {
        dayController = GameObject.Find("DayController").GetComponent<DayController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // メッセージ表示
    public void SimpleMessage(string message) => dayController.SimpleMessage(message);
    public void MessageAndChoice2(string message, string c1, string c2) => dayController.MessageAndChoice2(message, c1, c2);
    public void MessageAndChoice3(string message, string c1, string c2, string c3) => dayController.MessageAndChoice3(message, c1, c2, c3);
    public void MessageAndChoice4(string message, string c1, string c2, string c3, string c4) => dayController.MessageAndChoice4(message, c1, c2, c3, c4);

    public int GetTurn() => dayController.GetTurn(); //現在のターンを渡すゲッター

    public void NextTurn() => dayController.NextTurn(); // turnをプラス

    public void DisableNextButton() => dayController.DisableNextButton();

    public void EnableNextButton() => dayController.EnableNextButton();

    // 選択肢
    public void ChoiceButton_PlayerChose1() => dayController.ChoiceButton_PlayerChose1();
    public void ChoiceButton_PlayerChose2() => dayController.ChoiceButton_PlayerChose2();
    public void ChoiceButton_PlayerChose3() => dayController.ChoiceButton_PlayerChose3();
    public void ChoiceButton_PlayerChose4() => dayController.ChoiceButton_PlayerChose4();

    // パラメータ
    public void AddKoukando(int n) => dayController.AddKoukando(n); //好感度を引数分加える
    public void AddStudyKoukando(int n) => dayController.AddStudyKoukando(n); //勉強パラメータを引数分加える
    public void AddGameKoukando(int n) => dayController.AddGameKoukando(n); //ゲームパラメータを引数分加える
    public void AddSportKoukando(int n) => dayController.AddSportKoukando(n); //スポーツパラメータを引数分加える

    // 次の日に進む
    public void NextDay() => dayController.NextDay();

    public void NextButtonEnableDelayTrigger() => dayController.NextButtonEnableDelayTrigger();
    public void NextButtonEnableDelay() => dayController.NextButtonEnableDelay();

    public void ShowBackImage(int n) => dayController.ShowBackImage(n); //背景画像を表示する

    public void HideMotherImage() => dayController.HideMotherImage();
    public void ShowMotherImage() => dayController.ShowMotherImage();

    public void DayPatternError() => dayController.DayPatternError();

    public void ChristmasDayResult() => dayController.ChristmasDayResult();

    public void DayPattarn6() => dayController.DayPattern6();


}
