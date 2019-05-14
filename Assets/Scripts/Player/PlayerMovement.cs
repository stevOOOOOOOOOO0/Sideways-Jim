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
    public float Timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dash(Movement))
            return;
        else
        {
            ForwardBackward(Movement);
            if (input.GetKeyDown("Jump"))
                Jump(Movement);
        }
    }

    public void ForwardBackward(Vector3 Movement)
    {
        Movement.x = Input.GetAxis("Horizontal") * Speed;
        Movement.y += (-9.8f * Time.deltaTime);
    }

    public void Jump(Vector3 Movement)
    {
        if (PlayerController.isGrounded)
        {
            SecondJump = false;
            Movement.y = JumpSpeed;
        }
        else if (SecondJump)
        {
            Movement.y = JumpSpeed;
            SecondJump = true;
        }
    }

    public bool Dash(Vector3 Movement)
    {
        if (Input.GetKeyDown("Dash"))
        {
            Movement = DashMovement;
            Timer = 0.0f;
            return true;
        }

        Timer += 1f * Time.deltaTime;
        if (Timer <= 0.5f)
            return true;
        return false;
    }
}
