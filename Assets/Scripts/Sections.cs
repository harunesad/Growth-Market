using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sections : MonoBehaviour
{
    public static Sections section;
    public List<GameObject> sections = new List<GameObject>();
    private void Awake()
    {
        section = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
