using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float PlayerSpeed = 7f;
    public Rigidbody rb;
    public bool IsGrounded = true;
    private float velocity = 0;
    private float gravity = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal") * PlayerSpeed;

        float movey = Input.GetAxis("Vertical") * PlayerSpeed;

        characterController.Move((Vector3.right * movex + Vector3.forward * movey) * Time.deltaTime);

        if(characterController.isGrounded)
        {
            velocity = 0;
        }    
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
