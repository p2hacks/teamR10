using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDifficultyController : MonoBehaviour
{
    static public string difficulty = "Normal";
    static public int difficultyBorder = 0;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(difficulty);
        Debug.Log(difficultyBorder);
    }

    public void SetEasyMode()
    {
        difficulty = "Easy";
        difficultyBorder = -5;
    }

    public void SetNormalMode()
    {
        difficulty = "Normal";
        difficultyBorder = 0;
    }

    public void SetHardMode()
    {
        difficulty = "Hard";
        difficultyBorder = 5;
    }

}