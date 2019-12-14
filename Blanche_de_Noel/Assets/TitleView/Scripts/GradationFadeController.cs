using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GradationFadeController : MonoBehaviour
{
    private static float x = 50.0f; //フェード終わりは-1700
    private static bool isFadeCalled = false;
    private static bool isAlreadyExist = false;

    private static int isToScene = 0; // 0:ゲーム中の日変わり演出　1:遊び方画面　2:ゲームスタート　3:タイトル画面

    // Start is called before the first frame update
    void Start()
    {

        if (!isAlreadyExist)
        {
            DontDestroyOnLoad(this);
            isAlreadyExist = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        if (isFadeCalled)
        {
            x -= 1.5f;

            //タイトルからの遷移のとき、フェード演出画像が真ん中にきたらシーンを切り替え
            if (x <= 0.0f && x >= -2.0f && isToScene == 10)
            {
                SceneManager.LoadScene("TitleScene");
                isToScene = 0;
            }
            else if (x <= 0.0f && x >= -2.0f && isToScene == 20)
            {
                SceneManager.LoadScene("InfoScene"); 
                 isToScene = 0;
            }
            else if (x <= 0.0f && x >= -2.0f && isToScene == 30)
            {
                SceneManager.LoadScene("DifficultyLevelView");
                isToScene = 0;
            }
            else if (x <= 0.0f && x >= -2.0f && isToScene == 40)
            {
                SceneManager.LoadScene("DayViewTemplate");
                isToScene = 0;
            }


            if (x <= -50.0f)
            {
                x = 50.0f;
                isFadeCalled = false;
            }
        }

        transform.position = new Vector3(x,0,-9);
    }

    public void FadeScreenTo(int n)
    {
        isToScene = n;
        isFadeCalled = true;
    }

    public static float GetFadeX() => x;


}