using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController CC;

    public float Speed;

    public bool CanMove;

    public Animator ani;

    //attack
    public Collider SwordCollider;
    private bool IsSwinging;
    private float AttackDuration = 0.3f;
    private float TimetoEnd;

    //jump
    public float VerticalSpeed;
    public float JumpSpeed;
    public float Gravity;

    //turning
    public float Sensitivity;
    public Transform CamTransform;
    private float camRotation = 0f;

    void Start()
    {
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;

        //start movement
        CanMove = true;
    }

    void Update()
    {
        if (CanMove == true)
        {
            Vector3 movement = Vector3.zero;

            // X/Z movement
            float forwardMovement = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
            float sideMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

            movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

            //Jump and Ground check
            if (CC.isGrounded)
            {
                VerticalSpeed = 0f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    VerticalSpeed = JumpSpeed;
                }
            }

            VerticalSpeed += Gravity * Time.deltaTime;
            movement += transform.up * VerticalSpeed * Time.deltaTime;

            CC.Move(movement);

            //Camera Rotation/sensitivity
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;
            camRotation -= mouseY;
            camRotation = Mathf.Clamp(camRotation, 0f, 20f);
            CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

            float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
            transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseX, 0f));
        }

        //animation
        if (Input.GetMouseButtonDown(0) && IsSwinging == false)
        {
            ani.SetBool("Swinging", true);

            //begin counting
            TimetoEnd = Time.time + AttackDuration;

            IsSwinging = true;
          
        }

        if (IsSwinging == true)
        {
            if(Time.time > TimetoEnd)
            {
                ani.SetBool("Swinging", false);
                SwordCollider.enabled = false;

                IsSwinging = false;
            }

            else
            {
                SwordCollider.enabled = true;
            }
        }


    }
}
