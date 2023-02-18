using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class CamSwerve : MonoBehaviour
{
    public GameObject shelves;
    float lastFrameFingerPositionX;
    public float moveFactorX;
    int shelvesIndex;
    NavMeshAgent navMesh;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        //System();
        //Move();
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
    public void CamMoveUp()
    {

    }
    public void CamMoveDown()
    {
        if (Sections.section.shelves[0].transform.position.z - 10 != -10)
        {
            Vector3 targetPos=new Vector3(transform.position.x, transform.position.y, transform.position.z - 11);
            navMesh.destination = targetPos;
        }
    }
    public void CamMoveLeft()
    {

    }
    public void CamMoveRight()
    {

    }
    public void ShelvesOpen()
    {
        bool shelvesState = shelves.activeSelf;
        shelves.SetActive(!shelvesState);
    }
}
