using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ExtraProducts", menuName = "ScriptableObject/ExtraProducts")]

public class ExtraProducts : ScriptableObject
{
    public List<ExtraProductsSlot> extraProducts = new List<ExtraProductsSlot>();
}
[System.Serializable]
public class ExtraProductsSlot
{
    public GameObject product;
    public float money;
}
