using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Tilemap tilemapPlatforms;
    public Tilemap tilemap;
    
    public Text dieValueText;

    public PlayerMovement playerMovement;
    public Transform playerTransform;

    private int diceValue;
    bool movementDone = true;
    // Start is called before the first frame update
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementDone)
        {
            diceValue = Random.Range(1, 6);

            dieValueText.text = diceValue.ToString();
            movementDone = false;
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
            {
               
                for (int i = 0; i < diceValue; i++)
                {
                    Debug.Log(movementDone);
                    Debug.Log(diceValue);
                    Debug.Log(i);
                    Debug.Log(Input.GetAxisRaw("Vertical"));
                    tilemap.SetTile(
                        new Vector3Int(Mathf.FloorToInt(playerTransform.position.x +i* Input.GetAxisRaw("Horizontal")),Mathf.FloorToInt(playerTransform.position.y + i*Input.GetAxisRaw("Vertical")),0),
                    null);
                    playerTransform.position = new Vector3(playerTransform.position.x + 1 * Input.GetAxisRaw("Horizontal") , playerTransform.position.y + 1 * Input.GetAxisRaw("Vertical"), 0);
                }
                //playerTransform.position = new Vector3(playerTransform.position.x + diceValue*Input.GetAxisRaw("Horizontal") * Time.deltaTime, playerTransform.position.y + diceValue*Input.GetAxisRaw("Vertical") * Time.deltaTime, 0);
                movementDone = true;
            }

        }
        
    }
}
