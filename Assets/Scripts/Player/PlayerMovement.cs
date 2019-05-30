using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Movement = Vector3.zero;
    private float speed = .25f;
    public CharacterController PlayerController;
    private float jumpSpeed = .4f;
    public bool SecondJump;
    public Vector3 DashMovement;
    private float timer = 1.0f;
    private float Gravity = -2f;
    public bool DashAble;

    // Update is called once per frame
    private void Update()
    {
        if (Dash())
        {
            PlayerController.Move(Movement);
        }
        else
        {
            ForwardBackward();
            if (Input.GetKeyDown("space"))
            {
                Jump();
                Gravity = Gravity / 2;
            }

            if (Input.GetKeyUp("space"))
            {
                Gravity = Gravity * 2;
            }
        }
        PlayerController.Move(Movement);
    }

    private void ForwardBackward()
    {
        Movement.x = Input.GetAxis("Horizontal") * speed;
        Movement.y += (Gravity * Time.deltaTime);
        if (PlayerController.isGrounded)
            DashAble = true;
    }

    private void Jump()
    {
        if (PlayerController.isGrounded)
        {
            SecondJump = false;
            DashAble = true;
            Movement.y = jumpSpeed;
            Gravity = -2f;
        }
        else if (!SecondJump)
        {
            DashAble = true;
            Movement.y = jumpSpeed;
            SecondJump = true;
        }
    }

    private bool Dash()
    {
        if (Input.GetKeyDown("left alt") && DashAble)
        {
            Movement = DashMovement;
            timer = 0.0f;
            DashAble = false;
            return true;
        }

        timer += 1f * Time.deltaTime;
        if (timer <= 0.25f)
            return true;
        return false;
    }
}
