using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoViewController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToTitle()
    {
        GameObject.Find("Gradation").GetComponent<GradationFadeController>().FadeScreenTo(3);
    }
}
