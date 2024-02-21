using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacleLR;
    public float leftPos, rightPos, duration, yAxis, rotDuration;

    // Start is called before the first frame update
    void Start()
    {
        MoveRight();
        RotateSpike();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {
        obstacleLR.transform.DOLocalMoveX(rightPos, duration).SetEase(Ease.Linear).OnComplete(MoveLeft);
    }

    public void MoveLeft()
    {
        obstacleLR.transform.DOLocalMoveX(leftPos, duration).SetEase(Ease.Linear).OnComplete(MoveRight);
    }

    public void RotateSpike()
    {
        obstacleLR.transform.DOLocalRotate(new Vector3(0, yAxis, 0), rotDuration).SetLoops(-1, LoopType.Incremental);
    }

}
