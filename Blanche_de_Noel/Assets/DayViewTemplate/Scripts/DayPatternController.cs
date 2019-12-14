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

    public int GetPlayerChoice() => dayController.GetPlayerChoice();

    public bool GetOtukaiFlag() => dayController.GetOtukaiFlag();
    public void SetOtukaiFlag(bool flag) => dayController.SetOtukaiFlag(flag);

    public int GetOtukaiDidFlag() => dayController.GetOtukaiDidFlag();
    public void SetOtukaiDidFlag(int n) => dayController.SetOtukaiDidFlag(n);

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

    // １つめの行動パターン
    // 初日固定のイベント
    public void DayPattern0()
    {

        switch (GetTurn()) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {
            case 0:
                SimpleMessage("「おはよう！」");
                break;

            case 1:
                SimpleMessage("「もうすぐクリスマスだね。」");
                break;

            case 2:
                MessageAndChoice2("「いい子にしてないとサンタさん来ないわよ？」", "うん", "そんなの知らない");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「欲しいものがもらえるといいわね。」");
                    AddKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「もー、この子ったら。」");
                    AddKoukando(-1);
                }
                else
                    SimpleMessage("【エラー】GetPlayerChoice()に異常あり");
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;

        }

    }

    // ２つめの行動パターン
    public void DayPattern1()
    {
        switch (GetTurn()) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {
            case 0:
                SimpleMessage("パターン２");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「宿題はやったの？」", "うん", "まだ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「えらいね！！」");
                    AddKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「早めにやっておきなさい。」");
                    AddKoukando(-1);
                    AddStudyKoukando(1);
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;

        }
    }

    // ３つめの行動パターン
    public void DayPattern2()
    {

        switch (GetTurn()) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {

            case 0:
                SimpleMessage("パターン３");
                break;
            case 1:
                MessageAndChoice3("「とりあえず、好きなことやってきなさい。」", "勉強", "外でサッカー", "部屋でゲーム");
                break;

            case 2: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「頑張りなさい。」");
                    AddStudyKoukando(1);
                    AddKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「遅くならないようにね。」");
                    AddKoukando(1);
                    AddSportKoukando(1);

                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("「ほどほどにね。」");
                    AddKoukando(1);
                    AddGameKoukando(1);
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                break;

            case 3:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;

        }
    }

    // 4つ目の行動パターン
    public void DayPattern3()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン４");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「お隣さんに回覧板持って行ってくれない？」", "いいよ", "やだ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「えー。」");
                    AddKoukando(-1);
                }
                else
                    SimpleMessage("【エラー】GetPlayerChoice()に異常あり");
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 5つめの行動パターン
    public void DayPattern4()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン5");
                break;

            case 1:
                SimpleMessage("「お母さんね、お出かけしてくるけど、お留守番お願いね。」");

                break;
            case 2:
                MessageAndChoice2("「いい子にして待っているのよ？」", "うん", "やだ");
                break;

            case 3:
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「帰りにお菓子買ってくるわね。」");
                    AddKoukando(2);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「晩ご飯抜き。」");
                    AddKoukando(-2);
                }
                else
                    SimpleMessage("【エラー】GetPlayerChoice()に異常あり");
                break;

            case 4:
                NextDay();
                break;


            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 6つめの行動パターン
    public void DayPattern5()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン6");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「玄関の掃除してくれない？」", "いいよ", "やだ");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(2);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「もー。」");
                    AddKoukando(-1);
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 7つめの行動パターン
    public void DayPattern6()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン7");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice3("「今日は天気が悪いみたいだから勉強でもしておきなさい」", "勉強する", "あえて外で遊ぶ", "ゲームする");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「うん！　その方がいいわよ。」");
                    AddKoukando(3);
                    AddStudyKoukando(3);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「馬鹿なの？」");
                    AddKoukando(-1);
                    AddSportKoukando(1);
                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("「テストどうなっても、お母さん知らないわよ？」");
                    AddKoukando(-1);
                    AddGameKoukando(1);
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 8つめの行動パターン
    public void DayPattern7()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン8");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice3("「今日は天気がいいみたいだから外で遊んできなさい。」", "勉強する", "外で遊ぶ", "ゲームする");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「外で体動かしたらいいのに。」");
                    AddKoukando(-1);
                    AddStudyKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「うん！　その方がいいわよ。」");
                    AddKoukando(3);
                    AddSportKoukando(3);
                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("「外で体動かしたらいいのに。」");
                    AddKoukando(-1);
                    AddGameKoukando(1);
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 9つめの行動パターン
    public void DayPattern8()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン9");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「洗濯物干しておいてくれない?」", "うん", "やだ");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(1);

                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「そのくらいやってくれてもいいでしょ！。」");
                    AddKoukando(-1);

                }

                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // １０個目の行動パターン（この行動は母の登場はなし）
    public void DayPattern9()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン10");
                break;

            case 1:
                SimpleMessage("「やることないし、とりあえずゲームしよう！！。」");
                break;

            case 2:
                SimpleMessage("「１日中ゲームして楽しかったー！。」");
                AddGameKoukando(3);
                AddStudyKoukando(-1);
                AddSportKoukando(-1);
                break;

            case 3:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 11個目の行動パターン（この行動は母の登場はなし）
    public void DayPattern10()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン11");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                SimpleMessage("「１日中勉強して、これでテスト100点取れるぞ！！。」");
                AddGameKoukando(-1);
                AddStudyKoukando(3);
                AddSportKoukando(-1);
                break;

            case 3:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    // 12個目の行動パターン
    public void DayPattern11()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("パターン12");

                break;

            case 1:
                SimpleMessage("「おはよう。」");

                break;

            case 2:
                MessageAndChoice2("「あとで、おつかいでじゃがいも買ってきてくれない?」", "うん", "やだ");

                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    SetOtukaiFlag(true); // フラグを回収
                    Debug.Log("GetOtukaiFlag()" + GetOtukaiFlag());
                    SetOtukaiDidFlag(0); // おつかいはまだしてない
                    AddKoukando(1);

                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("「そのくらいやってくれてもいいでしょ！。」");
                    SetOtukaiFlag(false);
                    //SetOtukaiDidFlag(0);
                    AddKoukando(-1);

                }
                else
                {
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                }
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません(パターン12)");
                break;
        }
    }

    // おつかいイベント
    public void DayPattern12() // 母はこのパートには、登場しない
    {
        //otukaiDidFlag 0:買い物をいていない、1:間違ったものを買った、　2:正しいものを買った
        if ((GetOtukaiFlag() == true) && (GetOtukaiDidFlag() == 0))
        {
            switch (GetTurn())
            {
                case 0:
                    SimpleMessage("「今日は頼まれていたおつかいに行こうか。」");
                    break;

                // ここで場面は、商店街に変わる。
                case 1:
                    SimpleMessage("「いらっしゃい！！！」"); // 商店街の店主

                    break;

                case 2:
                    // 商店街の店主
                    MessageAndChoice4("「何を買っていくんだい？」", "だいこん", "じゃがいも", "さかな", "サツマイモ");

                    break;

                case 3: // otukaiDidFlag 1:間違ったものを買った 2:正しいものを買った
                    //SimpleMessage("表示テスト");
                    if (GetPlayerChoice() == 1)
                    {
                        SimpleMessage("「まいど！！」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }

                    else if (GetPlayerChoice() == 2)
                    {
                        SimpleMessage("「まいど！！」");
                        SetOtukaiDidFlag(2);
                        Debug.Log("OtukaiDidFlag=" + GetOtukaiDidFlag());
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else if (GetPlayerChoice() == 3)
                    {
                        SimpleMessage("「まいど！！」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else if (GetPlayerChoice() == 4)
                    {
                        SimpleMessage("「まいど！！」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else
                    {
                        SimpleMessage("【エラー】playerChoiceに異常あり");
                    }

                    break;

                case 4:
                    NextDay();// 到達できない
                    break;

                default: //if文あると、なぜかここに引っかかる！！！！！ なんで！？
                    Debug.Log("GetTurn()=" + GetTurn());
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");
                    NextDay();


                    break;
            }
            Debug.Log("おつかいパートotukaiDidFlag"+GetOtukaiDidFlag());
            Debug.Log("おつかいパートotukaiFlag" + GetOtukaiFlag());

        }
        else if ((GetOtukaiFlag() == false))
        {
            Debug.Log("おつかいパートotukaiFlag" + GetOtukaiFlag());
            Debug.Log("おつかいパートotukaiDidFlag" + GetOtukaiDidFlag());
            switch (GetTurn())
            {
                case 0:
                    SimpleMessage("おつかいイベントのフラグを回収できませんでした。");
                    break;
                case 1:
                    SimpleMessage("「もー。なんでおつかい行ってくれない」");
                    break;
                case 2:
                    NextDay();
                    break;
                default:
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");
                    break;
            }
        }

        // 緊急脱出
        if(GetTurn() == 4)
        {
            NextDay();
        }

    }

    // おつかいで正しいものを買ったか判定する
    public void DayPattern13()
    {
        if ((GetOtukaiFlag() == true) && ((GetOtukaiDidFlag() >= 1)))
        {
            switch (GetTurn())
            {
                case 0:
                    SimpleMessage("パターン13");
                    break;

                case 1:
                    SimpleMessage("「この前、頼んだおつかい行ってくれたのね!!!。」");

                    break;

                case 2:
                    if (GetOtukaiDidFlag() == 2)
                    {
                        SimpleMessage("「ちゃんとジャガイモ買ってきてくれたのね!!」");
                        AddKoukando(5);
                    }
                    else if (GetOtukaiDidFlag() == 1)
                    {
                        SimpleMessage("「頼んでいたものと違うじゃない!!」");
                        AddKoukando(-5);
                    }

                    break;

                case 3:
                    NextDay();
                    break;

                default:
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");
                    break;
            }
        }
        else
        {
            Debug.Log("おつかい判定パートotukaiFlag" + GetOtukaiFlag());
            Debug.Log("おつかい判定パートotukaiDidFlag" + GetOtukaiDidFlag());
            switch (GetTurn())
            {
                case 0:
                    SimpleMessage("おつかい判定パートでエラー。");
                    break;
                case 1:
                    SimpleMessage("「今度、おつかい行っておいで。」");
                    AddKoukando(-1);
                    break;
                case 2:
                    NextDay();
                    break;
                default:
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかい判定パート)");
                    break;
            }
        }

    }
}

