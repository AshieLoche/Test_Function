using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManagerLesson.Instance.inputManager.verticalInput;
        moveDirection += cameraObject.right * PlayerManagerLesson.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerManagerLesson.Instance.inputManager.moveAmount <= 0.5)
        {
            moveDirection *= PlayerManagerLesson.Instance.moveSpeed;
        }
        else
        {
            moveDirection *= PlayerManagerLesson.Instance.runSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        PlayerManagerLesson.Instance.rigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = cameraObject.forward * PlayerManagerLesson.Instance.inputManager.verticalInput;
        targetDirection += cameraObject.right * PlayerManagerLesson.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManagerLesson.Instance.rotSpeed);
        transform.rotation = playerRotation;
    }
}
