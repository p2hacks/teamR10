using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImageTempController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float x = 0.0f;
    private bool isMovementOn = true;

    // Update is called once per frame
    void Update()
    {
        if (isMovementOn) x += 0.02f;
        else x -= 0.02f;

        this.transform.position = new Vector3(x, 0, 0);
    }

    //ボタンが押された時に呼び出す関数を作るが、この関数はタイトルイメージに対して指示するものなので、その指示の内容をTitleImageTempControllerに書き込む

        //ボタンが押されたら、この関数を呼び出す　＝＞　ボタンのOnClick()にこれを追加する

        //publicにしないと読み込めない

    public void TurnMovement() //関数の名前の最初の文字は大文字
    {
        if (isMovementOn) isMovementOn = false;
        else isMovementOn = true;
    }
}
