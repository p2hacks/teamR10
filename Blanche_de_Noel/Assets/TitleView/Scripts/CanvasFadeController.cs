using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeController : MonoBehaviour
{
    private static bool isAlreadyExist = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isAlreadyExist) {
            DontDestroyOnLoad(this);
            isAlreadyExist = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
