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
    int numOfDayPattern = 9;

    //DayPatternController dayPatternController; //DayControllerが不安定な時の避難用

    private int day = 15; //現在の日にち //25日に結果発表
    const int CHRISTMAS_DAY = 25; //クリスマスの日 //プレゼントが届けられる日

    int randomPattern = 0; //次の1日パターンがランダムで選択される

    private int turn = 0; //母親の発言や選択肢などをターン番号で区別する
    private int playerChoice = 0; //プレイヤーが選んだ選択肢を区別する

    private int nextButtonEnableDelay = 0; //フェード演出後は進むボタンを一定時間押せなくする
    private bool nextButtonEnableDelayTrigger = false;

    private bool otukaiFlag; // おつかいイベントを発生させるか判定(フラグを回収したかどうか)
    private int otukaiDidFlag; // 正しくおつかいをしているか判定 0:買い物をいていない、1:間違ったものを買った、　2:正しいものを買った

    public AudioClip SE;
    AudioSource audioSource;
    private bool SE_judge = true;

    GameObject messageText;
    Button nextButton;

    GameObject buttonChoice1;
    GameObject buttonChoice2;
    GameObject buttonChoice3;
    GameObject buttonChoice4;

    GameObject backController; //背景画像を入れ替えるスクリプト
    GameObject motherImage;


    ChristmasResultController christmasDayResult;
    DayPatternController dayPatternController;

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

        dayPatternController = GameObject.Find("DayPatternController").GetComponent<DayPatternController>();

        audioSource = GetComponent<AudioSource>();

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
        if (day != CHRISTMAS_DAY) //クリスマス前 ******************** 編集して良いエリア　ここから　↓
                                  //ランダムに決定された流れパターンによって切替をする
        {
            if (GAMEMAIN.GetDay() == 1)
            {
                dayPatternController.DayPattern0();
            }
            else if(GAMEMAIN.GetDay() == 3)
            {
                dayPatternController.DayPattern11();
            }
            else if (GAMEMAIN.GetDay() == 4)
            {
                dayPatternController.DayPattern12();
            }
            else if (GAMEMAIN.GetDay() == 5)
            {
                dayPatternController.DayPattern13();
            }
            else
            {
                Debug.Log("randomPattern"+randomPattern);
                switch (randomPattern)
                {

                    case 0:
                        dayPatternController.DayPattern1();
                        break;

                    case 1:
                        dayPatternController.DayPattern2();
                        break;

                    case 2:
                        dayPatternController.DayPattern6();
                        break;

                    case 3:
                        dayPatternController.DayPattern7();
                        break;

                    case 4:
                        dayPatternController.DayPattern9();
                        break;

                    case 5:
                        dayPatternController.DayPattern4();
                        break;

                    case 6:
                        dayPatternController.DayPattern3();
                        break;

                    case 7:
                        dayPatternController.DayPattern5();
                        break;

                    case 8:
                        dayPatternController.DayPattern8();
                        break;

                    case 9:
                        dayPatternController.DayPattern10();
                        break;

                    default:
                        DayPatternError();
                        break;

                }
            }
        }
        else //クリスマスの日の結果発表
        {
            ChristmasDayResult();
            Debug.Log("koukando = " + GAMEMAIN.GetKoukando());
        } //****************************************************** 編集して良いエリア　ここまで　↑

        NextButtonEnableDelay(); //フェード演出用
    }

    public int GetDay() => day; //現在の日にちを渡すゲッター

    public int GetTurn() => turn; //現在のターンを渡すゲッター

    public int GetPlayerChoice() => playerChoice;

    public bool GetOtukaiFlag() => this.otukaiFlag;
    public void SetOtukaiFlag(bool flag) => this.otukaiFlag = flag;

    public int GetOtukaiDidFlag() => this.otukaiDidFlag;
    public void SetOtukaiDidFlag(int n) => this.otukaiDidFlag = n;

    public void NextTurn()
    {
        turn++; //進むボタンが押された時に次のターンに進む
        GAMEMAIN.ResetKoukandoTrigger();
        Debug.Log("NextTurn" + turn);
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

        if(SE_judge)
        {
            audioSource.PlayOneShot(SE);
            SE_judge = false;
        }

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
            GAMEMAIN.SetDay(1);
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

    public void HideMotherImage() => motherImage.SetActive(false); //母親の画像が不要なときは非表示にする
    public void ShowMotherImage() => motherImage.SetActive(true); //非表示中の時に母親の画像を出現させたいときに呼び出す

    public void DayPatternError()
    {
        SimpleMessage("【エラー】1日の流れパターンが割り当てられていません。randomPatternに異常あり");
    }

    public void Change_SE_judge()
    {
        SE_judge = true;
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

    
