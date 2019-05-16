using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Movement = Vector3.zero;
    public float Speed;
    public CharacterController PlayerController;
    public float JumpSpeed;
    public bool SecondJump;
    public Vector3 DashMovement;
    public float Timer = 1.0f;
    public float Gravity;
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
                Jump();
        }
        PlayerController.Move(Movement);
    }

    private void ForwardBackward()
    {
        Movement.x = Input.GetAxis("Horizontal") * Speed;
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
            Movement.y = JumpSpeed;
        }
        else if (!SecondJump)
        {
            DashAble = true;
            Movement.y = JumpSpeed;
            SecondJump = true;
        }
    }

    private bool Dash()
    {
        if (Input.GetKeyDown("left alt") && DashAble)
        {
            Movement = DashMovement;
            Timer = 0.0f;
            DashAble = false;
            return true;
        }

        Timer += 1f * Time.deltaTime;
        if (Timer <= 0.25f)
            return true;
        return false;
    }
}
