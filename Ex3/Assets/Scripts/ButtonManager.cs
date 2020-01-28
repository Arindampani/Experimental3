using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int score;
    public void closedialogue()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Finish");
        gameObject.SetActive(false);
    }

    public void loadFinalScene()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        score = Mathf.FloorToInt( (float)(playerTransform.position.y + 6.5) * 100); 
        SceneManager.LoadScene(1);
    }
}
