using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class QuaternionScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed;
    Vector3 mouseLocation;
    [SerializeField] Vector3 knockbackForce = new Vector3(0, 0, 10f); // Adjust as needed
    [SerializeField] float speed = 5f; // Adjust knockback speed
    [SerializeField] bool isKnockingBack = false; // Flag to track knockback state
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Vector3 knockbackTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateTowards();
        //QuaternionLookExample();
        LookAt();
        //Knockback();
    }

    public void RotateTowards()
    {
        var step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }

    public void QuaternionLookExample()
    {
        Vector3 relativePosition = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
    }

    public void LookAt()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            mouseLocation = Input.mousePosition;
            Debug.Log(mouseLocation);
        }
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    public void Knockback()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isKnockingBack)
        {
            isKnockingBack = true;
            startingPosition = transform.position;
            knockbackTarget = startingPosition + knockbackForce;

            StartCoroutine(KnockbackCoroutine(knockbackTarget));
        }
    }

    IEnumerator KnockbackCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Knockback complete! Initial position: " + startingPosition + ", Final position: " + transform.position);
        isKnockingBack = false; // Reset flag after completion
    }
}
