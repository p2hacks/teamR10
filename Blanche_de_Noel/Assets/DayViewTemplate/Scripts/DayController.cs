using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *  1日の流れを管理するスクリプト
 *  例えば、進むボタンが押されたら次のメッセージを表示するよう指示するなど
 *  このコードの下側の「1日の流れ編集エリア」を編集する
 *
 *  **　それ以外の部分は絶対に書き換えないこと！　**
 */

public class DayController : MonoBehaviour
{
    /**********今現在の1日パターンの作成された個数 * 追加され次第数を加える*************/
    int numOfDayPattern = 1;


    private int day = 23; //現在の日にち //25日に結果発表
    const int CHRISTMAS_DAY = 25; //クリスマスの日 //プレゼントが届けられる日

    int randomPattern = 0; //次の1日パターンがランダムで選択される

    private int turn = 0; //母親の発言や選択肢などをターン番号で区別する
    private int playerChoice = 0; //プレイヤーが選んだ選択肢を区別する


    float p_move = 0.0f;
    float x = 0.0f;
    
    float fadeOpacity = 0.0f;
    float snowOpacity = 0.0f;
    public AudioClip presentSet;
    

    GameObject messageText;
    Button nextButton;

    GameObject Present;
    GameObject Present_O;
    GameObject PresentContain;
    GameObject SnowEffect;
    GameObject Fader;

    GameObject buttonChoice1;
    GameObject buttonChoice2;
    GameObject buttonChoice3;
    GameObject buttonChoice4;


    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("Canvas/MessageText");
        nextButton = GameObject.Find("Canvas/NextButton").GetComponent<Button>();

        buttonChoice1 = GameObject.Find("Canvas/Button_choice1");
        buttonChoice2 = GameObject.Find("Canvas/Button_choice2");
        buttonChoice3 = GameObject.Find("Canvas/Button_choice3");
        buttonChoice4 = GameObject.Find("Canvas/Button_choice4");


        Present = GameObject.Find("PresentBox");
        Present_O = GameObject.Find("PresentBox_O");
        PresentContain = GameObject.Find("Benz");

        Fader = GameObject.Find("Fader");
        SnowEffect = GameObject.Find("Snow");
        Material fade = Fader.GetComponent<Renderer>().material;
        Material snow = SnowEffect.GetComponent<Renderer>().material;

        fade.color = new Color(0.0f, 0.0f, 0.0f, fadeOpacity);
        snow.color = new Color(0.0f, 0.0f, 0.0f, snowOpacity);

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);

        Present_O.SetActive(false);
        PresentContain.SetActive(false);

        Debug.Log("day = " + day);
    }


    // Update is called once per frame
    void Update()
    {
        if(day != CHRISTMAS_DAY) //クリスマス前
            switch (randomPattern) { //ランダムに決定された流れパターンによって切替をする

                case 0:
                    DayPattern0();
                    break;

                case 1:
                    DayPattern0();
                    break;

                default:
                    DayPatternError();
                    break;
                    
            }
        else //クリスマスの日の結果発表
        {
            ChristmasDayResult();
        }
    }


    public int GetTurn() => turn; //現在のターンを渡すゲッター

    public void NextTurn() => turn++; //進むボタンが押された時に次のターンに進む

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
    void SimpleMessage(string message) =>
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

    // 母親のメッセージと、それに対する選択肢を2つ表示する
    void MessageAndChoice2(string message, string c1, string c2)
    {
        messageText.GetComponent<MessageTextController>().DisplayMessage(message);

        buttonChoice1.SetActive(true);
        buttonChoice2.SetActive(true);

        buttonChoice1.GetComponentInChildren<Text>().text = c1;
        buttonChoice2.GetComponentInChildren<Text>().text = c2;

        DisableNextButton();
    }

    // 母親のメッセージと、それに対する選択肢を3つ表示する
    void MessageAndChoice3(string message, string c1, string c2, string c3)
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
    void MessageAndChoice3(string message, string c1, string c2, string c3, string c4)
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

    void present_move(){
        Present.gameObject.transform.Translate(0.0f, p_move, 0.0f);
        Debug.Log("Presentのxは" + Present.transform.position.y);
        if(Present.transform.position.y > 0.0f){
            x = x + 0.001f;
            p_move = p_move - x * x;
        }else if(Present.transform.position.y < 0.0f){
            p_move = 0.0f;
            EnableNextButton();
        }
    }

    void present_open(){
        if(Present.transform.position.y < 2.0f){
            Present.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
        }else if(Present.transform.position.y >= 2.0f){
            Present.SetActive(false);
            Present_O.SetActive(true);
            if(Present_O.transform.position.y >= 0.0f){
                Present_O.gameObject.transform.Translate(0.0f, -0.2f, 0.0f);
            }
            EnableNextButton();
        }
    }
    
    void ChristmasDayFadeIn(){
        messageText.SetActive(false);
        if(snowOpacity <= 1.0f){
            fadeOpacity = 1.0f;
            SnowEffect.GetComponent<Renderer>().material.color = new Color(255, 255, 255, snowOpacity);
            Fader.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeOpacity);
            snowOpacity = snowOpacity + 0.01f;
        }else if(snowOpacity >= 1.0f){
            snowOpacity = 1.0f;
            EnableNextButton();
        }
    }

    void ChristmasDayFadeOut(){
        if((snowOpacity >= 0.0f)&&(fadeOpacity >= 0.0f)){
            SnowEffect.GetComponent<Renderer>().material.color = new Color(255, 255, 255, snowOpacity);
            Fader.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeOpacity);
            snowOpacity = snowOpacity - 0.01f;
            fadeOpacity = fadeOpacity - 0.01f;
        }else if((snowOpacity <= 0.0f)&&(fadeOpacity <= 0.0f)){
            snowOpacity = 0.0f;
            fadeOpacity = 0.0f;
            EnableNextButton();
        }
    }

    void present_contain(){
        Present_O.SetActive(false);
        
    }

    void AddKoukando(int i) => GAMEMAIN.AddKoukando(i); //好感度を引数分加える

    void NextDay() //一日の流れが終わり次の日に遷移する時に呼び出す
    {
        //フェードアウト関連のコードをここにおく
        //フェードアウト演出が終わるまで進むボタンをSetActive(false)にする

        turn = 0;
        playerChoice = 0;
        day++;
        Debug.Log("day = " + day);
        randomPattern = Random.Range(0, numOfDayPattern); //次の1日の流れパターンをランダムに決定する

    }

    void DayPatternError()
    {
        SimpleMessage("【エラー】1日の流れパターンが割り当てられていません。randomPatternに異常あり");
    }

    void ChristmasDayResult()
    {
        switch(turn){
            case 0:
                DisableNextButton();
                ChristmasDayFadeIn();
                break;
            case 2:
                DisableNextButton();
                ChristmasDayFadeOut();
                break;
            case 3:
                messageText.SetActive(true);
                SimpleMessage("クリスマスプレゼントよ！");
                break;
            case 4:
                DisableNextButton();
                present_move();
                break;
            case 5:
                DisableNextButton();
                present_open();
                break;
            case 6:
                SimpleMessage("ベンツだ！！");
                break;
            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;
        }
    }

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
     */

    void DayPattern0()
    {
        switch (turn) /********* このSwitch文の中に1日の内容を書き込んでね！ **********/
        {
            case 0:
                SimpleMessage("1日目");
                break;

            case 1:
                SimpleMessage("メッセージ表示テスト");
                break;

            case 2:
                MessageAndChoice2("「今日の宿題は終わったの？」", "はい", "いいえ");
                break;

            case 3: //一つ前のターンで選択肢を表示したので必ずプレイヤーの選択別に場合わけ
                if (playerChoice == 1)
                {
                    SimpleMessage("「じゃああとでおつかいお願いね。」");
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
}
