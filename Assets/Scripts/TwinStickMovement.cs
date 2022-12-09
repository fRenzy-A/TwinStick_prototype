using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TwinStickMovement : MonoBehaviour
{
    public float speed; // Speed variable
    public Rigidbody rigidBody; // Set the variable 'rb' as Rigibody
    public Vector3 movement;
    //public float dashMax;
    public Material material1;
    public Material material2;
    public GameObject Object;
    public float dash;
    public float dashCoolDown;
    public float dashCoolDownInitial;
    public float dashCount;
    public float iFrame;
    public float iFrameInitial;
    Camera m_camera;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        m_camera = Camera.main;
        
    }



    // 'Update' Method is called once per frame
    void Update()
    {
        HandleShootInput();

        var lookAtPos = Input.mousePosition;
        lookAtPos.z = m_camera.transform.position.y - transform.position.y;
        lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
        transform.forward = lookAtPos - transform.position;

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {           
            if (dashCoolDown < 0.0f)
            {
                rigidBody.AddForce(movement * dash, ForceMode.VelocityChange);
                dashCoolDown = dashCoolDownInitial;
                Object.GetComponent<MeshRenderer>().material = material1;
            }
            if (iFrame < 0.1f)
            {
                iFrame = iFrameInitial;
            }         
            if (iFrame > 0.0f)
            {
                gameObject.tag = "Invincible";
            }
        }
        if (iFrame < 0.1f)
        {
            gameObject.tag = "Player";
            Object.GetComponent<MeshRenderer>().material = material2;
        }
        if (iFrame > 0.0f)
        {
            iFrame -= Time.deltaTime;
        }
        if (dashCoolDown > 0.0f)
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

    [SerializeField] public Transform player;
    [SerializeField] public Transform respawn_point;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            player.transform.position = respawn_point.transform.position;
        }

    }
}