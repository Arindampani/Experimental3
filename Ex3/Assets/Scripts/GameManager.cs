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

    private float xValue;
    private float yValue;
    private GameObject[] fireObjects;
    bool movementDone = true;
    // Start is called before the first frame update
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        if (movementDone)
        {
            fireObjects = GameObject.FindGameObjectsWithTag("Fire");
            diceValue = Random.Range(1, 6);
            Debug.Log(diceValue);
            dieValueText.text = diceValue.ToString();
            movementDone = false;
        }
        xValue = playerTransform.position.x;
        yValue = playerTransform.position.y;
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

        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && !movementDone)
            {

                for (int i = 0; i < diceValue; i++)
                {
                    //Debug.Log(movementDone);
                    Debug.Log(diceValue);
                //Debug.Log(i);
                //Debug.Log(Input.GetAxisRaw("Vertical"));
                Debug.Log(new Vector3Int(Mathf.FloorToInt(playerTransform.position.x + 1 * Input.GetAxisRaw("Horizontal") * 0.8f), Mathf.FloorToInt(playerTransform.position.y + 1 * Input.GetAxisRaw("Vertical") * 0.8f), 0));
                    tilemap.SetTile(
                        new Vector3Int(Mathf.FloorToInt(playerTransform.position.x +1* Input.GetAxisRaw("Horizontal") * 0.8f ),Mathf.FloorToInt(playerTransform.position.y + 1*Input.GetAxisRaw("Vertical") * 0.8f),0),
                    null);

                playerTransform.position = new Vector3(playerTransform.position.x + 1 * Input.GetAxisRaw("Horizontal"), playerTransform.position.y + 1 * Input.GetAxisRaw("Vertical"), 0);
                
                //foreach(GameObject g in fireObjects)
                //{
                //    Physics2D.OverlapArea()
                //    if (g.transform.position.x )
                //}
                }
            
            //playerTransform.position = new Vector3(playerTransform.position.x + diceValue*Input.GetAxisRaw("Horizontal") * Time.deltaTime, playerTransform.position.y + diceValue*Input.GetAxisRaw("Vertical") * Time.deltaTime, 0);
            movementDone = true;
           // resetDice();
        }
    }

    void resetDice()
    {
        if (movementDone)
        {
            diceValue = Random.Range(1, 6);
            dieValueText.text = diceValue.ToString();
            movementDone = false;
        }
    }
}
