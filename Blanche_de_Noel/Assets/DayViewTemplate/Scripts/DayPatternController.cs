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
    public void SetIsOtukaiDone() => dayController.SetIsOtukaiDone();

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
                SimpleMessage("お母さん「おはよう！」");
                break;

            case 1:
                SimpleMessage("お母さん「もうすぐクリスマスだね。」");
                break;

            case 2:
                MessageAndChoice2("お母さん「いい子にしてないとサンタさん来ないわよ？」", "うん", "そんなの知らない");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「欲しいプレゼントがもらえるといいわね。」");
                    AddKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「もー、この子ったら。」");
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
                SimpleMessage("お母さん「いい朝だね！！」");
                break;

            case 1:
                SimpleMessage("お母さん「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("お母さん「宿題はやったの？」", "うん", "まだ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「えらいね。」");
                    AddKoukando(1);
                    AddStudyKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「早めにやっておきなさい。」");
                    AddKoukando(-1);
                    AddStudyKoukando(-1);
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
                SimpleMessage("お母さん「もうこんな時間。」");
                break;

            case 1:
                SimpleMessage("お母さん「今日お母さんは忙しいから、好きなことやってきなさい。」");
                break;

            case 2:
                MessageAndChoice3("宿題がまだ残ってる。友達がいま公園にいるかも。ラスボスを早く倒して自慢したい。", "勉強", "外でサッカー", "部屋でゲーム");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「頑張りなさい。」");
                    AddStudyKoukando(1);
                    AddKoukando(1);
                    AddSportKoukando(-1);
                    AddGameKoukando(-1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「遅くならないようにね。」");
                    AddKoukando(1);
                    AddSportKoukando(1);
                    AddStudyKoukando(-1);
                    AddGameKoukando(-1);

                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("お母さん「ほどほどにね。」");
                    AddKoukando(1);
                    AddGameKoukando(1);
                    AddStudyKoukando(-1);
                    AddSportKoukando(-1);
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

    // 4つ目の行動パターン
    public void DayPattern3()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("お母さん「お母さん今日は出かけなきゃいけないから…」");
                break;

            case 1:
                SimpleMessage("お母さん「家で宿題やっていなさいね。」");
                break;

            case 2:
                MessageAndChoice4("お母さんが出かけて行った。何をしよう？", "宿題", "ゲーム", "掃除", "運動");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("宿題をやっていよう。");
                    AddStudyKoukando(1);
                    AddSportKoukando(-1);
                    AddGameKoukando(-1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("テレビが使えるからテレビでゲームしよう！");
                    AddGameKoukando(1);
                    AddSportKoukando(-1);
                    AddStudyKoukando(-1);
                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("こっそりお手伝いだ。");
                    AddKoukando(2);
                    AddGameKoukando(-1);
                    AddSportKoukando(-1);
                    AddStudyKoukando(-1);
                }
                else if(GetPlayerChoice() == 4)
                {
                    SimpleMessage("スーパーの向かいの信号までダッシュだ！");
                    AddGameKoukando(-1);
                    AddSportKoukando(1);
                    AddStudyKoukando(-1);
                }
                else
                    SimpleMessage("errorNoMessage");

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
                SimpleMessage("お母さん「スーパーに行かなくちゃ！」");
                break;

            case 1:
                SimpleMessage("お母さん「お母さんね、お出かけしてくるけど、お留守番お願いね。」");

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
        int rain = 0;

        switch (GetTurn())
        {
            case 0:
                SimpleMessage("天気予報『今日の夕方の降水確率は40%です。』");
                break;

            case 1:
                SimpleMessage("お母さん「荷物が多くて大変だわ。急がないと。」");
                break;

            case 2:
                SimpleMessage("お母さん「これから仕事に行ってくるから、お昼適当に食べててね。」");
                break;

            case 3:
                MessageAndChoice2("お母さんは荷物で手がふさがっている。", "傘を持たせる", "バイバイ");
                break;

            case 4:
                HideMotherImage();
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「雨降るの？しょうがないなぁ、持っていくわ。」");
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「いってきます。」");
                }
                else
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                break;

            case 5:
                SimpleMessage("夕方になって…");
                break;

            case 6:
                SimpleMessage("お母さん「ただいま。」");
                rain = Random.Range(0, 100);
                break;

            case 7:
                ShowMotherImage();
                if (rain > 50) //雨が降ったら
                {
                    if (GetPlayerChoice() == 1)
                    {
                        SimpleMessage("お母さん「雨降ってきたから、傘持ってきて正解だったよ。」");
                        AddKoukando(2);
                    }
                    else
                    {
                        SimpleMessage("お母さん「帰る途中で雨降ってきちゃった…荷物濡れちゃったから拭いといて。」");
                        AddKoukando(-2);
                    }
                }
                else
                {
                    if (GetPlayerChoice() == 1)
                    {
                        SimpleMessage("お母さん「荷物が多すぎて大変だったわ。傘も使わなかったし…」");
                        AddKoukando(-2);
                    }
                    else
                    {
                        SimpleMessage("お母さん「曇ってきたから雨が心配だったけど、降らなくてよかった。」");
                        AddKoukando(2);
                    }
                }
                break;

            case 8:
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
                SimpleMessage("お母さん「今日は天気悪いわね。」");
                break;

            case 1:
                SimpleMessage("お母さん「おはよう。」");
                break;

            case 2:
                MessageAndChoice3("お母さん「今日は天気が悪いみたいだから勉強でもしておきなさい」", "勉強する", "あえて外で遊ぶ", "ゲームする");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「うん！　その方がいいわよ。」");
                    AddKoukando(2);
                    AddStudyKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「馬鹿なの？」");
                    AddKoukando(-1);
                    AddSportKoukando(1);
                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("お母さん「宿題どうなっても、お母さん知らないわよ？」");
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
                SimpleMessage("お母さん「久しぶりに晴れたわね。」");
                break;

            case 1:
                SimpleMessage("お母さん「おはよう。」");
                break;

            case 2:
                MessageAndChoice3("お母さん「今日は天気がいいみたいだから外で遊んできなさい。」", "勉強する", "外で遊ぶ", "ゲームする");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「外で体動かしたらいいのに。」");
                    AddKoukando(-1);
                    AddStudyKoukando(1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「うん！　その方がいいわよ。」");
                    AddKoukando(2);
                    AddSportKoukando(2);
                }
                else if (GetPlayerChoice() == 3)
                {
                    SimpleMessage("お母さん「外で体動かしたらいいのに。」");
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
                SimpleMessage("お母さん「今日は洗濯日和！」");
                break;

            case 1:
                SimpleMessage("お母さん「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("お母さん「洗濯物干しておいてくれない?」", "うん", "やだ");
                break;

            case 3:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「ありがとう。」");
                    AddKoukando(1);

                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「そのくらいやってくれてもいいでしょ！。」");
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
                HideMotherImage();
                SimpleMessage("「ひますぎてヤバイ。」");
                break;

            case 1:
                SimpleMessage("「勉強めんどくさいし、ゲーム進めよう！」");
                break;

            case 2:
                SimpleMessage("…………");
                break;

            case 3:
                SimpleMessage("「よし、これでアイツに勝てるぞ！」");
                AddGameKoukando(1);
                AddStudyKoukando(-1);
                AddSportKoukando(-1);
                break;

            case 4:
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
                HideMotherImage();
                SimpleMessage("「お母さんいないし、やることないなー。」");
                break;

            case 1:
                SimpleMessage("「宿題やっちゃうか！」");
                break;

            case 2:
                SimpleMessage("…………");
                break;

            case 3:
                SimpleMessage("「これでテスト100点取れるぞ！！。」");
                AddGameKoukando(-1);
                AddStudyKoukando(1);
                AddSportKoukando(-1);
                break;

            case 4:
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
                SimpleMessage("お母さん「ええと、カレーに必要な材料は…」");
                break;

            case 1:
                SimpleMessage("お母さん「玉ねぎに、人参に、ジャガイモに、豚肉に、サラダ油ね。」");
                break;

            case 2:
                SimpleMessage("お母さん「シチューだったら、牛乳、小麦粉、ジャガイモ、人参、玉ねぎを使うわね。」");
                break;

            case 3:
                SimpleMessage("お母さん「オムライスなら、材料は卵と、牛乳と、鶏肉と、玉ねぎと、ケチャップと、サラダ油かな。」");
                break;

            case 4:
                SimpleMessage("お母さん「…あ、いけない。もう出ないと。」");
                break;

            case 5:
                SimpleMessage("お母さん「明日おつかいにいってちょうだい。覚えておいてね。」");
                break;

            case 6:
                MessageAndChoice2("おつかいはつまんないけど…", "うん", "やだ");

                break;

            case 7:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("お母さん「ありがとう。明日お願いね。」");
                    SetOtukaiFlag(true); // フラグを回収
                    Debug.Log("GetOtukaiFlag()" + GetOtukaiFlag());
                    SetOtukaiDidFlag(0); // おつかいはまだしてない
                    AddKoukando(1);

                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("お母さん「だめ。ちゃんと行ってきて。」");
                    SetOtukaiFlag(true);
                    //SetOtukaiDidFlag(0);
                    AddKoukando(-1);

                }
                else
                {
                    SimpleMessage("【エラー】playerChoiceに異常あり");
                }
                break;

            case 8:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません(パターン12)");
                break;
        }
    }

    // おつかいイベント
    // お店の画像に差し替えて欲しい
    public void DayPattern12() // 母はこのパートには、登場しない
    {
        //otukaiDidFlag 0:買い物をいていない、1:間違ったものを買った、　2:正しいものを買った
        if ((GetOtukaiFlag() == true) && (GetOtukaiDidFlag() == 0))
        {
            switch (GetTurn())
            {
                case 0: // 自宅で登場は主人公だけ
                    HideMotherImage();
                    SimpleMessage("今日は頼まれていたおつかいに行こうか。");
                    break;

                case 1:
                    SimpleMessage("キッチンには、サラダ油、ジャガイモ、人参、玉ねぎが置いてある…");
                    break;

                // ここで場面は、お店に変わる。
                case 2:
                    ShowBackImage(3);
                    SimpleMessage("いつものスーパーに来た。"); // 商店街の店主
                    break;

                case 3:
                    // 店主
                    MessageAndChoice4("何を買おうかな？", "牛乳", "豚肉", "鶏肉", "玉ねぎ");

                    break;

                case 4: // otukaiDidFlag 1:間違ったものを買った 2:正しいものを買った
                    //SimpleMessage("表示テスト");
                    if (GetPlayerChoice() == 1)
                    {
                        SimpleMessage("「牛乳を買った。これでいいんだよね。」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }

                    else if (GetPlayerChoice() == 2)
                    {
                        SimpleMessage("「豚肉を買った。これでいいんだよね。」");
                        SetOtukaiDidFlag(2);
                        Debug.Log("OtukaiDidFlag=" + GetOtukaiDidFlag());
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else if (GetPlayerChoice() == 3)
                    {
                        SimpleMessage("「鶏肉を買った。これでいいんだよね。」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else if (GetPlayerChoice() == 4)
                    {
                        SimpleMessage("「玉ねぎを買った。これでいいんだよね。」");
                        SetOtukaiDidFlag(1);
                        SetOtukaiFlag(true);
                        Debug.Log("turn=" + GetTurn());

                    }
                    else
                    {
                        SimpleMessage("【エラー】playerChoiceに異常あり");
                    }

                    break;

                case 5:
                    NextDay();// 到達できない //到達できた
                    break;

                default: //if文あると、なぜかここに引っかかる！！！！！ なんで！？ //引っ掛からなくなった
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
                    SimpleMessage("お母さん「クリスマスプレゼントはどんなものが欲しいの？」");
                    break;
                case 1:
                    MessageAndChoice4("何が欲しいかな？","ゲーム機","問題集","新しいボール","なんでもいい");
                    break;

                case 2:
                    SimpleMessage("お母さん「ふーんそうなんだ。」");

                    if (GetPlayerChoice() == 1)
                    {
                        AddGameKoukando(1);
                        AddStudyKoukando(-1);
                        AddSportKoukando(-1);
                    }
                    else if (GetPlayerChoice() == 2)
                    {
                        AddGameKoukando(-1);
                        AddStudyKoukando(1);
                        AddSportKoukando(-1);
                    }
                    else if (GetPlayerChoice() == 3)
                    {
                        AddGameKoukando(-1);
                        AddStudyKoukando(-1);
                        AddSportKoukando(1);
                    }
                    else if (GetPlayerChoice() == 4)
                    {
                        AddGameKoukando(-2);
                        AddStudyKoukando(-2);
                        AddSportKoukando(-2);
                    }
                    break;

                case 3:
                    SimpleMessage("お母さん「別にお母さんはサンタさんじゃないんだけどね。」");
                    break;

                case 4:
                    NextDay();
                    break;
                default:
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");
                    break;
            }
        }

        // 緊急脱出
        if (GetTurn() >= 5)
            NextDay();

    }

    // おつかいで正しいものを買ったか判定する
    public void DayPattern13()
    {
        if ((GetOtukaiFlag() == true) && ((GetOtukaiDidFlag() >= 1)))
        {
            switch (GetTurn())
            {
                case 0:
                    SimpleMessage("お母さん「ただいま。おつかい行ってくれた？」");
                    break;

                case 1:
                    SimpleMessage("お母さん「何買うか言うの忘れてたけど、ちゃんと行ってきたのね。えらい。」");
                    break;

                case 2:
                    SimpleMessage("お母さん「これは…」");
                    break;

                case 3:
                    if (GetOtukaiDidFlag() == 2)
                    {
                        SimpleMessage("お母さん「そう！豚肉が欲しかったの！よくわかったわね！」");
                        AddKoukando(3);
                    }
                    else if (GetOtukaiDidFlag() == 1)
                    {
                        SimpleMessage("お母さん「あら、本当は豚肉が欲しかったんだけどね。まあ、しょうがないわね。」");
                        AddKoukando(1);
                    }

                    break;

                case 4:
                    SimpleMessage("お母さん「おつかい行ってきてくれたから、今日はカレーにするね。」");
                    break;

                case 5:
                    NextDay();
                    SetIsOtukaiDone();
                    break;

                default:
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");
                    break;
            }
        }
        else
        {
            switch (GetTurn())
            {                                                                                                                                                                              
                case 0:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                    SimpleMessage("お母さん「洗濯物片付けなきゃ。」");
                    break;
                case 1:
                    SimpleMessage("お母さん「ちょっと、掃除手伝ってくれない？」");
                    break;
                case 2:
                    MessageAndChoice2("いま宿題やってる最中だけど…", "うん", "やだ");
                    break;
                case 3:
                    if(GetPlayerChoice() == 1)
                    {
                        SimpleMessage("お母さん「ついでに自分の部屋も片付けてきたら？」");
                        AddKoukando(1);
                        AddStudyKoukando(-1);
                    }
                    else
                    {
                        SimpleMessage("お母さん「しょうがないわね。いつか手伝ってよ。」");
                        AddKoukando(-1);
                        AddStudyKoukando(1);
                    }
                    break;
                case 4:
                    NextDay();
                    break;
                default:
                    SimpleMessage("");
                    break;
            }
        }

    }

    public void DayPattern14()
    {
        switch (GetTurn())
        {
            case 0:
                SimpleMessage("お母さん「お友達が遊びにきてるよ。」");
                break;

            case 1:
                SimpleMessage("友達「よお。一緒に遊ぼうぜ。」");
                break;

            case 2:
                MessageAndChoice3("どうする？", "一緒に宿題", "公園に行く", "ゲームする");
                break;

            case 3:
                if(GetPlayerChoice() == 1)
                {
                    SimpleMessage("友達「エー。まだ終わってないのかよ。」");
                    AddStudyKoukando(2);
                    AddSportKoukando(-2);
                    AddGameKoukando(-2);
                }
                else if(GetPlayerChoice() == 2)
                {
                    SimpleMessage("友達「サッカーボール持ってこいよ！」");
                    AddSportKoukando(2);
                    AddStudyKoukando(-2);
                    AddGameKoukando(-2);
                }
                else if(GetPlayerChoice() == 3)
                {
                    SimpleMessage("友達「よし、俺と対戦だ！」");
                    AddGameKoukando(2);
                    AddStudyKoukando(-2);
                    AddSportKoukando(-2);
                }
                break;

            case 4:
                NextDay();
                break;
        }
    }

    public void DayPattern15()
    {
        switch (GetTurn())
        {
            case 0:
                HideMotherImage();
                SimpleMessage("「すごく天気いいな。」");
                break;

            case 1:
                SimpleMessage("「あったかそうだし、あっちの大きい公園に行ってみよう。」");
                break;

            case 2:
                ShowBackImage(2);
                SimpleMessage("…………");
                break;

            case 3:
                SimpleMessage("「学校の友達が集まってた！みんなで公園の周りで競争した。」");
                AddGameKoukando(-1);
                AddStudyKoukando(-1);
                AddSportKoukando(2);
                break;

            case 4:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

    public void DayPattern16()
    {
        switch (GetTurn())
        {
            case 0:
                HideMotherImage();
                ShowBackImage(2);
                SimpleMessage("公園にきた。");
                break;

            case 1:
                SimpleMessage("友達「あっちょっと今日の宿題教えてよ。」");
                break;

            case 2:
                MessageAndChoice2("うーんどうしよう？", "いいよ", "やだ");
                break;

            case 3:
                if(GetPlayerChoice() == 1)
                {
                    SimpleMessage("友達「じゃあ俺んち行こう。」");
                    AddStudyKoukando(1);
                    AddSportKoukando(-1);
                }
                else if (GetPlayerChoice() == 2)
                {
                    SimpleMessage("友達「じゃあサッカー特訓だな。」");
                    AddStudyKoukando(-1);
                    AddSportKoukando(2);
                }
                break;

            case 4:
                if (GetPlayerChoice() == 1)
                {
                    SimpleMessage("宿題が終わったらずっとゲームをしていた。");
                    AddGameKoukando(1);
                }
                else
                {
                    SimpleMessage("今日はいい練習ができた。");
                }
                break;

            case 5:
                NextDay();
                break;

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }
}

