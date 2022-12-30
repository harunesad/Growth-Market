using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamSwerve : MonoBehaviour
{
    float lastFrameFingerPositionX;
    public float moveFactorX;
    int shelvesIndex;
    void Start()
    {
        
    }
    void Update()
    {
        System();
        Move();
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
    public void Move()
    {
        float shelvePosX = Sections.section.shelves[shelvesIndex].transform.position.x;
        if (moveFactorX < -5 && transform.position.x == shelvePosX && shelvesIndex < Sections.section.shelves.Count - 1)
        {
            shelvesIndex++;
            transform.DOMoveX(Sections.section.shelves[shelvesIndex].transform.position.x, 0.4f);
        }
        else if (moveFactorX > 5 && transform.position.x == shelvePosX && shelvesIndex > 0)
        {
            shelvesIndex--;
            transform.DOMoveX(Sections.section.shelves[shelvesIndex].transform.position.x, 0.4f);
        }
    }
}
