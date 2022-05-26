using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {
            
        }
        if (verticalMove <= -.5f)
        {

        }
    }
}
