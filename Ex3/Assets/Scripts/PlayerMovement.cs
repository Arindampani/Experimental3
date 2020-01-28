using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5.0f;

    public Rigidbody2D rigidBody;

    private Vector2 _movement;
    // Update is called once per frame
    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //rigidBody.MovePosition(rigidBody.position + _movement * movementSpeed * Time.fixedDeltaTime);
    }

    public void Move()
    {

    }
}
