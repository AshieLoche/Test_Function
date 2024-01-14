using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsScript : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform startWayPoint, endWayPoint;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0,0,-1);
        //transform.position = Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        //DistanceChecker();
        //MoveTowardsVector();
        //VectorLerping();
    }

    public void DistanceChecker()
    {
        float distance = Vector3.Distance(transform.position, enemy.position);
        Debug.Log($"Distance: {distance}");
    }

    public void MoveTowardsVector()
    {
        float speed = 1.0f;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, enemy.position, step);
    }

    public void VectorLerping()
    {
        transform.position = Vector3.Lerp(startWayPoint.position, endWayPoint.position, Time.time * speed);
    }
}
