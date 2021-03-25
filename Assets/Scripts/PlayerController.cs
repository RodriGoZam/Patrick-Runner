using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    private Vector3 movementDirection = Vector3.zero;

    public float MoveSpeed = 8f;
    public float SideSpeed = 10f;
    public float JumpSpeed = 8f;
    public float Gravity = 20f;

    bool isAlive = true;

    public Transform groundCheck;
    public float groundDistance = 0.05f;
    public LayerMask groundMask;

    bool isGrounded;

    float horizontalInput;
    // Update is called once per frame

    private void FixedUpdate() {
        if (isAlive)
        {
            Vector3 forwardMove = transform.forward * MoveSpeed * Time.deltaTime;
            if (MoveSpeed > 16f)
            {
                animator.SetBool("isRunningFaster", true);
                animator.SetBool("isRunning", false);

            }
            else
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isRunningFaster", false);
            }
            controller.Move(forwardMove);
        } 
    }
    void Update()
    {
        if (!isAlive) return;

        //Check if Sphere is colliding with ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 sideMove = transform.right * SideSpeed * horizontalInput;
        controller.Move(sideMove*Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded) {
            movementDirection.y = JumpSpeed;
        }
        movementDirection.y -= Gravity * Time.deltaTime;
        controller.Move(movementDirection * Time.deltaTime);
        animator.SetBool("isJumping",!isGrounded);
        
        
    }

    public void Die()
    {
        isAlive = false;
    }

    public void increaseSpeed()
    {
        float newMoveSpeed = (float)MoveSpeed * 0.25f;
        MoveSpeed = MoveSpeed + newMoveSpeed;
    }
}
