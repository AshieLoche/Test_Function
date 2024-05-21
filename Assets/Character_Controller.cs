using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    CharacterController controller;
    public float moveSpeed, rotSpeed;
    public float gravityForce;
    public float rotSmoothTime;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    public void PlayerControls()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        
        if (!controller.isGrounded)
        {
            movement.y -= gravityForce * Time.deltaTime;
        }
        else
        {
            movement.y = 0;
        }

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            targetAngle = Mathf.Clamp(targetAngle, -180, 180);
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotSpeed, rotSmoothTime);

            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            
        }

        controller.Move(moveSpeed * Time.deltaTime * movement);

        float moveMagnitude = movement.magnitude;
        animator.SetFloat("Speed", moveMagnitude);

    }
}
