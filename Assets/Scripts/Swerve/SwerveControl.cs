using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwerveControl : MonoBehaviour
{
    public static SwerveControl swerve;
    float lastFrameFingerPositionX;
    public float moveFactorX;
    //public float MoveFactorX => moveFactorX;
    private void Awake()
    {
        swerve = this;
    }
    private void Update()
    {
        System();
    }
    public void System()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
    public void Move(Transform productParent)
    {
        if (moveFactorX < -5 && productParent.position.x == 1)
        {
            productParent.DOMoveX(-1, 0.4f);
        }
        else if (moveFactorX > 5 && productParent.transform.position.x == -1)
        {
            productParent.DOMoveX(1, 0.4f);
        }
    }
}
