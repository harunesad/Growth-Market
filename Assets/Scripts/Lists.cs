using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lists : MonoBehaviour
{
    public static Lists lists;
    public List<GameObject> sections = new List<GameObject>();
    public List<GameObject> shelves = new List<GameObject>();
    public List<Image> productsImage = new List<Image>();
    private void Awake()
    {
        lists = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
