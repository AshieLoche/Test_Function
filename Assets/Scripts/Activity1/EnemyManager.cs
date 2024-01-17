using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed = 50f;
    Quaternion targetRotation;
    bool isTouchingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerChecker();
        MoveTowards();
    }

    private void PlayerChecker()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void MoveTowards()
    {
        if (transform.rotation == targetRotation && !isTouchingPlayer)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                movementSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
