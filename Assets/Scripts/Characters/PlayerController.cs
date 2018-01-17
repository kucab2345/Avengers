using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float rotationSpeed = 5f;
    public float walkSpeed = 10f;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        RotateToMouse();
        Move();
    }
    void RotateToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    void Move()
    {
        if(Input.GetKey("w"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + walkSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("s"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + walkSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - walkSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
