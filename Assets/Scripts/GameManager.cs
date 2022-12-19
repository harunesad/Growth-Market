using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject productsParent;
    void Start()
    {
        productsParent.transform.DOMoveZ(65, 50).SetEase(Ease.Linear).SetEase(Ease.Linear);
    }
    void Update()
    {
        SwerveControl.swerve.Move(productsParent.transform);
    }
}
