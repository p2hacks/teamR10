using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *  1日の流れを管理するスクリプト
 *  例えば、進むボタンが押されたら次のメッセージを表示するよう指示するなど
 *  このコードの下側の「1日の流れ編集エリア」を編集する
 *
 *  **　指定された部分以外は絶対に書き換えないこと！　**
 *
 *　クリスマスの日の結果発表のコードは、DayController内が長すぎになるためChristmasResultControllerに置き換えました
 *  
 */

public class DayController : MonoBehaviour
{
    /**********今現在の1日パターンの作成された個数 * 追加され次第数を加える*************/
    int numOfDayPattern = 3;

    //DayPatternController dayPatternController; //DayControllerが不安定な時の避難用

    private int day = 23; //現在の日にち //25日に結果発表
    const int CHRISTMAS_DAY = 25; //クリスマスの日 //プレゼントが届けられる日

    int randomPattern = 0; //次の1日パターンがランダムで選択される

    private int turn = 0; //母親の発言や選択肢などをターン番号で区別する
    private int playerChoice = 0; //プレイヤーが選んだ選択肢を区別する

    private int nextButtonEnableDelay = 0; //フェード演出後は進むボタンを一定時間押せなくする
    private bool nextButtonEnableDelayTrigger = false;

    private bool otukaiFlag; // おつかいイベントを発生させるか判定(フラグを回収したかどうか)
    private bool otukaiDidFlag; // 正しくおつかいをしているか判定 false:買い物をいていないまたは、間違ったものを買った　true:正しいものを買った

    GameObject messageText;
    Button nextButton;

    GameObject buttonChoice1;
    GameObject buttonChoice2;
    GameObject buttonChoice3;
    GameObject buttonChoice4;

    GameObject backController; //背景画像を入れ替えるスクリプト
    GameObject motherImage;

    ChristmasResultController christmasDayResult;
    /**************** クリスマスの結果発表用変数 ******************クリスマスの日の結果発表のコードは、DayController内が長すぎになるためChristmasResultControllerに置き換えました
    float p_move = 0.0f;
    float x = 0.0f;

    float fadeOpacity = 0.0f;
    float snowOpacity = 0.0f;
    public AudioClip presentSet;

    GameObject Present;
    GameObject Present_O;
    GameObject PresentContain;
    GameObject SnowEffect;
    GameObject Fader;
    *********************************************************/


    // Start is called before the first frame update
    void Start()
    {
        //dayPatternController = GameObject.Find("DayPatternController").GetComponent<DayPatternController>(); //DayControllerが不安定な時の避難用

        messageText = GameObject.Find("Canvas/MessageText");
        nextButton = GameObject.Find("Canvas/NextButton").GetComponent<Button>();

        buttonChoice1 = GameObject.Find("Canvas/Button_choice1");
        buttonChoice2 = GameObject.Find("Canvas/Button_choice2");
        buttonChoice3 = GameObject.Find("Canvas/Button_choice3");
        buttonChoice4 = GameObject.Find("Canvas/Button_choice4");

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        backController = GameObject.Find("Back_Controller");
        motherImage = GameObject.Find("MotherImage");

        christmasDayResult = GameObject.Find("ChristmasResultController").GetComponent<ChristmasResultController>();
        /**************** クリスマスの結果発表用 ******************クリスマスの日の結果発表のコードは、DayController内が長すぎになるためChristmasResultControllerに置き換えました
        Present = GameObject.Find("PresentBox");
        Present_O = GameObject.Find("PresentBox_O");
        PresentContain = GameObject.Find("Benz");

        Fader = GameObject.Find("Fader");
        SnowEffect = GameObject.Find("Snow");
        Material fade = Fader.GetComponent<Renderer>().material;
        Material snow = SnowEffect.GetComponent<Renderer>().material;

        fade.color = new Color(0.0f, 0.0f, 0.0f, fadeOpacity);
        snow.color = new Color(0.0f, 0.0f, 0.0f, snowOpacity);

        Present_O.SetActive(false);
        PresentContain.SetActive(false);
        ******************************************************/

        GAMEMAIN.ResetKoukandoTrigger();

        Debug.Log("day = " + day);
    }


    // Update is called once per frame
    void Update()
    {
        if(day != CHRISTMAS_DAY) //クリスマス前 ******************** 編集して良いエリア　ここから　↓
            //ランダムに決定された流れパターンによって切替をする
            switch (randomPattern) {

                case 0:
                    DayPattern0();
                    break;

                case 1:
                    DayPattern1();
                    break;

                case 2:
                    DayPattern2();
                    break;

                default:
                    DayPatternError();
                    break;
                    
            }
        else //クリスマスの日の結果発表
        {
            ChristmasDayResult();
            Debug.Log("koukando = " + GAMEMAIN.GetKoukando());
        } //****************************************************** 編集して良いエリア　ここまで　↑

        NextButtonEnableDelay(); //フェード演出用
    }


    public int GetTurn() => turn; //現在のターンを渡すゲッター

    public void NextTurn()
    {
        turn++; //進むボタンが押された時に次のターンに進む
        GAMEMAIN.ResetKoukandoTrigger();
    }

    public void DisableNextButton() => nextButton.interactable = false; //進むボタンを無効化する（選択肢の表示中など）

    public void EnableNextButton() => nextButton.interactable = true; //進むボタンを有効化する

    public void ChoiceButton_PlayerChose1() //プレイヤーが選択肢1番目を選んだ
    {
        playerChoice = 1;
        EnableNextButton();

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        NextTurn();
    }

    public void ChoiceButton_PlayerChose2() //プレイヤーが選択肢2番目を選んだ
    {
        playerChoice = 2;
        EnableNextButton();

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        NextTurn();
    }

    public void ChoiceButton_PlayerChose3() //プレイヤーが選択肢3番目を選んだ
    {
        playerChoice = 3;
        EnableNextButton();

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        NextTurn();
    }

    public void ChoiceButton_PlayerChose4() //プレイヤーが選択肢4番目を選んだ
    {
        playerChoice = 4;
        EnableNextButton();

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        NextTurn();
    }

    // 単純に母親のメッセージを表示する
    public void SimpleMessage(string message) =>
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

    // 母親のメッセージと、それに対する選択肢を2つ表示する
    public void MessageAndChoice2(string message, string c1, string c2)
    {
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

        buttonChoice1.SetActive(true);
        buttonChoice2.SetActive(true);

        buttonChoice1.GetComponentInChildren<Text>().text = c1;
        buttonChoice2.GetComponentInChildren<Text>().text = c2;

        DisableNextButton();
    }

    // 母親のメッセージと、それに対する選択肢を3つ表示する
    public void MessageAndChoice3(string message, string c1, string c2, string c3)
    {
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

        buttonChoice1.SetActive(true);
        buttonChoice2.SetActive(true);
        buttonChoice3.SetActive(true);

        buttonChoice1.GetComponentInChildren<Text>().text = c1;
        buttonChoice2.GetComponentInChildren<Text>().text = c2;
        buttonChoice3.GetComponentInChildren<Text>().text = c3;

        DisableNextButton();
    }

    // 母親のメッセージと、それに対する選択肢を4つ表示する
    public void MessageAndChoice4(string message, string c1, string c2, string c3, string c4)
    {
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

        buttonChoice1.SetActive(true);
        buttonChoice2.SetActive(true);
        buttonChoice3.SetActive(true);
        buttonChoice4.SetActive(true);

        buttonChoice1.GetComponentInChildren<Text>().text = c1;
        buttonChoice2.GetComponentInChildren<Text>().text = c2;
        buttonChoice3.GetComponentInChildren<Text>().text = c3;
        buttonChoice4.GetComponentInChildren<Text>().text = c4;

        DisableNextButton();
    }

    public void AddKoukando(int n) => GAMEMAIN.AddKoukando(n); //好感度を引数分加える
    public void AddStudyKoukando(int n) => GAMEMAIN.AddStudyKoukando(n); //勉強パラメータを引数分加える
    public void AddGameKoukando(int n) => GAMEMAIN.AddGameKoukando(n); //ゲームパラメータを引数分加える
    public void AddSportKoukando(int n) => GAMEMAIN.AddSportKoukando(n); //勉強パラメータを引数分加える


    public void NextDay() //一日の流れが終わり次の日に遷移する時に呼び出す
    {
        //フェードアウト
        GameObject.Find("Gradation").GetComponent<GradationFadeController>().FadeScreenTo(0);

        //フェードアウト演出が終わるまで進むボタンをintaractableをfalseにする
        NextButtonEnableDelayTrigger();

        if (GradationFadeController.GetFadeX() <= 0 && GradationFadeController.GetFadeX() >= -2.0)
        {
            playerChoice = 0;
            randomPattern = Random.Range(0, numOfDayPattern); //次の1日の流れパターンをランダムに決定する
            turn = 0;
            day++;
            ShowBackImage(1); //シーンの最初には必ず自宅の背景が選ばれるようにする。別の場所で1日を始める場合は最初のターンでその背景をこの関数で呼び出す
            ShowMotherImage(); //シーンの最初には必ず母親の画像を表示する。不要なときは最初のターンでHideMotherImage()を呼び出す
            Debug.Log("day = " + day);
        }
    }

    public void NextButtonEnableDelayTrigger()
    {
        nextButtonEnableDelayTrigger = true;
        DisableNextButton();
    }

    public void NextButtonEnableDelay()
    {
        if (nextButtonEnableDelayTrigger)
            nextButtonEnableDelay++;

        if (nextButtonEnableDelay >= 90)
        {
            EnableNextButton();
            nextButtonEnableDelay = 0;
            nextButtonEnableDelayTrigger = false;
        }
    }

    public void ShowBackImage(int n) //番号で割り当てられた背景画像を表示する
    {
        Debug.Log("BackImage = " + n);

        switch (n)
        {
            case 1:
                backController.GetComponent<BackImageController>().ShowHouseImage();
                break;

            case 2:
                backController.GetComponent<BackImageController>().ShowDaytimeParkImage();
                break;

            case 3:
                backController.GetComponent<BackImageController>().ShowSupermarketImage();
                break;
        }
    }

    void HideMotherImage() => motherImage.SetActive(false); //母親の画像が不要なときは非表示にする
    void ShowMotherImage() => motherImage.SetActive(true); //非表示中の時に母親の画像を出現させたいときに呼び出す

    public void DayPatternError()
    {
        SimpleMessage("【エラー】1日の流れパターンが割り当てられていません。randomPatternに異常あり");
    }

    public void ChristmasDayResult()
    {
        christmasDayResult.ChristmasDayResult();

        //switch (turn)
        //{
        //    case 0:
        //        DisableNextButton();
        //        ChristmasDayFadeIn();
        //        break;
        //    case 1:
        //        DisableNextButton();
        //        ChristmasDayFadeOut();
        //        break;
        //    case 2:
        //        messageText.SetActive(true);
        //        SimpleMessage("クリスマスプレゼントよ！");
        //        break;
        //    case 3:
        //        DisableNextButton();
        //        present_move();
        //        break;
        //    case 4:
        //        DisableNextButton();
        //        present_open();
        //        break;
        //    case 5:
        //        SimpleMessage("ベンツだ！！");
        //        break;
        //    default:
        //        SimpleMessage("【エラー】このターンに何も割り当てられていません");
        //        break;
        //}
    }

    /************************* クリスマスの結果発表用 ここから **************************クリスマスの日の結果発表のコードは、DayController内が長すぎになるためChristmasResultControllerに置き換えました
    void present_move()
    {
        Present.gameObject.transform.Translate(0.0f, p_move, 0.0f);
        Debug.Log("Presentのxは" + Present.transform.position.y);
        if (Present.transform.position.y > 0.0f)
        {
            x = x + 0.001f;
            p_move = p_move - x * x;
        }
        else if (Present.transform.position.y < 0.0f)
        {
            p_move = 0.0f;
            EnableNextButton();
        }
    }

    void present_open()
    {
        if (Present.transform.position.y < 2.0f)
        {
            Present.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
        }
        else if (Present.transform.position.y >= 2.0f)
        {
            Present.SetActive(false);
            Present_O.SetActive(true);
            if (Present_O.transform.position.y >= 0.0f)
            {
                Present_O.gameObject.transform.Translate(0.0f, -0.2f, 0.0f);
            }
            EnableNextButton();
        }
    }

    void ChristmasDayFadeIn()
    {
        messageText.SetActive(false);
        if (snowOpacity <= 1.0f)
        {
            fadeOpacity = 1.0f;
            SnowEffect.GetComponent<Renderer>().material.color = new Color(255, 255, 255, snowOpacity);
            Fader.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeOpacity);
            snowOpacity = snowOpacity + 0.01f;
        }
        else if (snowOpacity >= 1.0f)
        {
            snowOpacity = 1.0f;
            EnableNextButton();
        }
    }

    void ChristmasDayFadeOut()
    {
        if ((snowOpacity >= 0.0f) && (fadeOpacity >= 0.0f))
        {
            SnowEffect.GetComponent<Renderer>().material.color = new Color(255, 255, 255, snowOpacity);
            Fader.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeOpacity);
            snowOpacity = snowOpacity - 0.01f;
            fadeOpacity = fadeOpacity - 0.01f;
        }
        else if ((snowOpacity <= 0.0f) && (fadeOpacity <= 0.0f))
        {
            snowOpacity = 0.0f;
            fadeOpacity = 0.0f;
            EnableNextButton();
        }
    }

    /********************************** クリスマスの結果発表用 ここまで *************************************/


    /**************************************************
     *　　　　　　　　　　1日の流れ編集エリア　　　　　　　　　*
     **************************************************
     * 
     * アクションの生成テンプレート↓↓↓
     * これらの関数呼び出しの組み合わせで1日の流れを生成する
     *
     *　SimpleMessage(string message);
     *　　単純に母親のメッセージを表示する
     *　　引数:message = メッセージの内容
     *
     * 
     *　以下、選択肢を表示する機能では、
     *　『選択肢を置いたターンの次のターンでは、必ずプレイヤーの選択ごとにif文で場合わけすること！！』
     *
     * 
     *　MessageAndChoice2(string message, string c1, string c2);
     *　　母親のメッセージと、それに対する選択肢を2つ表示する
     *　　引数:message = メッセージの内容, c1 = 1つ目の選択肢の文字列, c2 = 2つ目の選択肢の文字列
     *　　
     *　MessageAndChoice3(string message, string c1, string c2, string c3);
     *　　母親のメッセージと、それに対する選択肢を3つ表示する
     *　　引数:message = メッセージの内容, c1 = 1つ目の選択肢の文字列, c2 = 2つ目の選択肢の文字列, c3 = 3つ目の選択肢の文字列
     *
     *　MessageAndChoice4(string message, string c1, string c2, string c3, string c4);
     *　　母親のメッセージと、それに対する選択肢を4つ表示する
     *　　引数:message = メッセージの内容, c1 = 1つ目の選択肢の文字列, c2 = 2つ目の選択肢の文字列, c3 = 3つ目の選択肢の文字列, c4 = 4つ目の選択肢の文字列
     *
     *　AddKoukando(int i)
     *　　母親の好感度を加える/減らす
     *　　引数:i = 加える数(マイナスで減らせる)
     *
     *
     *　【背景画像】
     *　ShowBackImage(int n);
     *　　特定の背景画像を表示する
     *　　引数:n = 背景画像に割り当てられた番号　1:自宅　2:公園　3:スーパー
     *　　** ! ** 画像を追加した場合は必ずこの関数内で番号を割り当てること！
     *
     *　【母親画像】
     *　void HideMotherImage();
     *　　母親の画像が不要なときは非表示にする
     *　
     *　void ShowMotherImage();
     *　　非表示中の時に母親の画像を出現させたいときに呼び出す
     * 
     */

    // １つめの行動パターン
    void DayPattern0()
    {

        switch (turn) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {
            case 0:
                SimpleMessage("パターン１");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「今日の宿題は終わったの？」", "はい", "いいえ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (playerChoice == 1)
                {
                    SimpleMessage("「じゃあ、おつかいお願いね。」");
                    AddKoukando(1);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「早くやっておいで。」");
                    AddKoukando(-1);
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

    // ２つめの行動パターン
    void DayPattern1()
    {
        switch (turn) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {
            case 0:
                SimpleMessage("パターン２");
                break;

            case 1:
                SimpleMessage("「おはよう。」");
                break;

            case 2:
                MessageAndChoice2("「今日は、おつかいでじゃがいもを買ってきてくれる？」", "いいよ", "やだ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (playerChoice == 1)
                {
                    SimpleMessage("「じゃあ、お願いね。」");
                    AddKoukando(1);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「そのくらいやってくれてもいいじゃない。」");
                    AddKoukando(-1);
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
    void DayPattern2()
    {

        switch (turn) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {

            case 0:
                SimpleMessage("パターン３");
                break;
            case 1:
                MessageAndChoice3("「とりあえず、好きなことやってきなさい。」", "勉強", "外でサッカー", "部屋でゲーム");
                break;

            case 2: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (playerChoice == 1)
                {
                    SimpleMessage("「頑張りなさい。」");
                    AddStudyKoukando(1);
                    AddKoukando(1);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「遅くならないようにね。」");
                    AddKoukando(1);
                    AddSportKoukando(1);

                }
                else if (playerChoice == 3)
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
    void DayPattern3()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(1);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「えー。」");
                    AddKoukando(-1);
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

    // 5つめの行動パターン
    void DayPattern4()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「帰りにお菓子買ってくるわね。」");
                    AddKoukando(2);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「晩ご飯抜き。」");
                    AddKoukando(-2);
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

    // 6つめの行動パターン
    void DayPattern5()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(2);
                }
                else if (playerChoice == 2)
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
    void DayPattern6()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「うん！　その方がいいわよ。」");
                    AddKoukando(3);
                    AddStudyKoukando(3);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「馬鹿なの？」");
                    AddKoukando(-1);
                    AddSportKoukando(1);
                }
                else if (playerChoice == 3)
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
    void DayPattern7()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「外で体動かしたらいいのに。」");
                    AddKoukando(-1);
                    AddStudyKoukando(1);
                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「うん！　その方がいいわよ。」");
                    AddKoukando(3);
                    AddSportKoukando(3);
                }
                else if (playerChoice == 3)
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
    void DayPattern8()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    AddKoukando(1);

                }
                else if (playerChoice == 2)
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
    void DayPattern9()
    {
        switch (turn)
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
    void DayPattern10()
    {
        switch (turn)
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
    void DayPattern11()
    {
        switch (turn)
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
                if (playerChoice == 1)
                {
                    SimpleMessage("「ありがとう。」");
                    otukaiFlag = true; // フラグを回収
                    otukaiDidFlag = false; // おつかいはまだしてない
                    AddKoukando(1);

                }
                else if (playerChoice == 2)
                {
                    SimpleMessage("「そのくらいやってくれてもいいでしょ！。」");
                    otukaiFlag = false;
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
    void DayPattern12() // 母はこのパートには、登場しない
    {
        if ((otukaiFlag == true) && (otukaiDidFlag == false))
        {
            switch (turn)
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
                    if (playerChoice == 1)
                    {
                        SimpleMessage("「まいど！！。」");
                        otukaiDidFlag = false;
                        Debug.Log("turn=" + turn);
                    }
                    else if (playerChoice == 2)
                    {
                        SimpleMessage("「まいど！！。」");
                        otukaiDidFlag = true;
                        Debug.Log("turn=" + turn);
                    }
                    else if (playerChoice == 3)
                    {
                        SimpleMessage("「まいど！！。」");
                        otukaiDidFlag = false;
                        Debug.Log("turn=" + turn);
                    }
                    else if (playerChoice == 4)
                    {
                        SimpleMessage("「まいど！！。」");
                        otukaiDidFlag = false;
                        Debug.Log("turn=" + turn);
                    }
                    else
                    {
                        SimpleMessage("【エラー】playerChoiceに異常あり");
                    }

                    break;

                case 4:
                    NextDay();
                    break;

                default: //if文あると、なぜかここに引っかかる！！！！！ なんで！？
                    Debug.Log("turn=" + turn);
                    SimpleMessage("【エラー】このターンに何も割り当てられていません(おつかいパート)");


                    break;
            }

        }
        else
        {
            switch (turn)
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

    }

    // おつかいで正しいものを買ったか判定する
    void DayPattern13()
    {
        if ((otukaiFlag == true) && (otukaiDidFlag == true))
        {
            switch (turn)
            {
                case 0:
                    SimpleMessage("パターン13");
                    break;

                case 1:
                    SimpleMessage("「この前、頼んだおつかい行ってくれたのね!!!。」");

                    break;

                case 2:
                    SimpleMessage("「ちゃんとジャガイモ買ってきてくれたのね!!」");
                    AddKoukando(5);
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
            switch (turn)
            {
                case 0:
                    SimpleMessage("おつかいイベントのフラグを回収できませんでした。");
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
