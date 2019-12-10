using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *  1日の流れを管理するスクリプト
 *
 *  例えば、進むボタンが押されたら次のメッセージを表示するよう指示するなど
 */

public class DayController : MonoBehaviour
{
    private int turn = 0; //母親の発言や選択肢などをターン番号で区別する

    private int playerChoice = 0; //プレイヤーが選んだ選択肢を区別する

    private int numberOfChoice = 0; //表示された選択肢の数

    GameObject messageText;
    Button nextButton;

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

        buttonChoice1.SetActive(false);
        buttonChoice2.SetActive(false);
        buttonChoice3.SetActive(false);
        buttonChoice4.SetActive(false);
    }


    // Update is called once per frame
    /******************** void Update() 以外のコードは絶対に変更しないように！ ********************/
    void Update()
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

            default:
                SimpleMessage("【エラー】このターンに何も割り当てられていません");
                break;

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

    /*
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

        numberOfChoice = 2;
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

        numberOfChoice = 3;
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

        numberOfChoice = 4;
        DisableNextButton();
    }

    void AddKoukando(int i) => GAMEMAIN.AddKoukando(i);

}
