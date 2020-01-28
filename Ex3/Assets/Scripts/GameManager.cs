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

    //public float mapX = 100.0f;
    //public float mapY = 100.0f;

    //private float minX;
    //private float maxX;
    //private float minY;
    //private float maxY;
    //private TileBase[] tiles;
    private int diceValue;
    bool movementDone = true;
    // Start is called before the first frame update
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
       // movementDone = true;
        // Calculations assume map is position at the origin
        //minX = horzExtent - mapX / 2.0f;
        //maxX = mapX / 2.0f - horzExtent;
        //minY = vertExtent - mapY / 2.0f;
        //maxY = mapY / 2.0f - vertExtent;
        ////Debug.Log("min X: " + minX);
        ////Debug.Log("max X: " + maxX);
        ////Debug.Log("min Y: " + minY);
        ////Debug.Log("max Y: " + maxY);

        //area.x = -30;//Mathf.FloorToInt(minX);
        //area.y = 30;// Mathf.FloorToInt(minY);
        //area.size = new Vector3Int(60, 60, 0);//new Vector3Int(Mathf.FloorToInt(maxX), Mathf.FloorToInt(maxY),0);
        //tiles = tilemap.GetTilesBlock(tilemap.cellBounds);

        //Debug.Log(tiles.Length);
        //Debug.Log(tilemap.cellBounds);

        //tiles[40].hideFlags = HideFlags.HideInHierarchy;

       // tilemap.SetTile(new Vector3Int(0, 0, 0), null);
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
                    Debug.Log(new Vector3Int(Mathf.FloorToInt(playerTransform.position.x + i * Input.GetAxisRaw("Horizontal")), Mathf.FloorToInt(playerTransform.position.y + i * Input.GetAxisRaw("Vertical")), 0));
                    //Debug.Log(Input.GetAxisRaw("Vertical"));
                    tilemap.SetTile(
                        new Vector3Int(Mathf.FloorToInt(playerTransform.position.x +i* Input.GetAxisRaw("Horizontal")),Mathf.FloorToInt(playerTransform.position.y + i*Input.GetAxisRaw("Vertical")),0),
                    null);
                    
                }
                playerTransform.position = new Vector3(playerTransform.position.x + diceValue*Input.GetAxisRaw("Horizontal") * Time.deltaTime, playerTransform.position.y + diceValue*Input.GetAxisRaw("Vertical") * Time.deltaTime, 0);
                movementDone = true;
            }

        }
        
    }
}
