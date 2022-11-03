using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwinStickMovement : MonoBehaviour
{
    public float speed; // Speed variable
    public Rigidbody rigidBody; // Set the variable 'rb' as Rigibody
    public Vector3 movement;
    //public float dashMax;
    public TextMeshProUGUI Anchor;

    public float dash;
    public float dashCoolDown;
    public float dashCount;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();

        
    }



    // 'Update' Method is called once per frame
    void Update()
    {
        HandleShootInput();

        transform.LookAt(new Vector3((Anchor.transform.position.x - Input.mousePosition.x),0.0f, (Anchor.transform.position.y - Input.mousePosition.y)));
       

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolDown <= 0.0f)
            {
                rigidBody.AddForce(movement * dash, ForceMode.Impulse);
                dashCoolDown = dashCount;
            }
            
        }
        if (dashCoolDown >= 0.0f)
        {
            dashCoolDown -= Time.deltaTime;
        }
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

    void HandleShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerShoot.Instance.Shoot();
        }

    }
}