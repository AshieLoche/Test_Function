using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] Transform enemy;
    [SerializeField] float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyChecker();
    }

    //Draws Acquisition Range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void EnemyChecker()
    {
        float distance = Vector3.Distance(transform.position, enemy.position);
        if (distance <= radius)
        {
            Quaternion targetRotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
