using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultSceneController : MonoBehaviour
{
    GameObject Saku;
    GameObject Switch;

    // Start is called before the first frame update
    void Start() {
        if (ChooseDifficultyController.difficultyBorder > 0)
        {
            Saku = GameObject.Find("Saku");
            Switch = GameObject.Find("Switch");
            ResultSaku();
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ChooseDifficultyController.difficultyBorder);
    }

    public void ResultSaku()
    {
        Saku.gameObject.transform.Translate(0.0f, 0.0f, -20.0f);
        Switch.gameObject.transform.Translate(0.0f, 0.0f, 20.0f);
    }

    //void ResultPresentMove()
    //{
    //    Present.gameObject.transform.Translate(0.0f, p_move, 0.0f);
    //    Debug.Log("Presentのxは" + Present.transform.position.y);
    //    if (Present.transform.position.y > 0.0f)
    //    {
    //        x = x + 0.001f;
    //        p_move = p_move - x * x;
    //    }
    //    else if (Present.transform.position.y < 0.0f)
    //    {
    //        p_move = 0.0f;
    //        EnableNextButton();
    //    }
    //}
}
