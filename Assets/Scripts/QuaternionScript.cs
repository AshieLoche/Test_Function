using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateTowards();
        QuaternionLookExample();
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
}
