using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManagerScene2 : MonoBehaviour
{

    public Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        finalText.text = "You Won :" + ApplicationMode.score.ToString();
    }

}
