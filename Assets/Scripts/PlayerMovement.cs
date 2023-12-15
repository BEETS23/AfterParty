using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    Vector2 lastMousePos;
    bool isMoving = false;
    

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if( isMoving && (Vector2)transform.position != lastMousePos )
        {
            Vector3 newPos = transform.position;
            newPos.x = Mathf.MoveTowards(transform.position.x, lastMousePos.x, speed * Time.deltaTime);
            transform.position = newPos;
        }

    }
}
