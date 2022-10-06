using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwinStickMovement : MonoBehaviour
{
    public float speed = 10.0f; // Speed variable
    public Rigidbody rigidBody; // Set the variable 'rb' as Rigibody
    public Vector3 movement;
    public TextMeshProUGUI Anchor;


    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }



    // 'Update' Method is called once per frame
    void Update()
    {
        

        transform.LookAt(new Vector3((Anchor.transform.position.x - Input.mousePosition.x),1.16066f, (Anchor.transform.position.y - Input.mousePosition.y)));
       

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));    
    }

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rigidBody.AddForce(direction * speed);
    }

}