using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleViewController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

private float x = 0.0f;
public bool isMovementOn = true;

    // Update is called once per frame
    void Update()
    {
        if(isMovementOn) x += 0.02f;
        this.transform.position = new Vector3(x,0,0);
    }
}
