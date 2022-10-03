using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickMovement : MonoBehaviour
{
    public float speed = 10.0f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement;



    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }



    // 'Update' Method is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;

        transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
    }

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
     void moveCharacter(Vector3 direction)
    {
        rb.AddForce(direction * speed);
    }

}