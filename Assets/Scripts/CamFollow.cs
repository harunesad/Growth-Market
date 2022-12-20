using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject productParent;
    public Vector3 offset;
    void Start()
    {
        //gameObject.transform.DOMove(productParent.transform.position + offset, 50);
        //transform.position=new Vector3(1, transform.position.y, transform.position.z);
    }
    void LateUpdate()
    {
        if (productParent.transform.parent == null)
        {
            transform.position = Vector3.Lerp(transform.position, productParent.transform.position + offset, Time.deltaTime * 5);
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5);
        transform.position = Vector3.Lerp(transform.position, productParent.transform.position - Vector3.forward * 7 + Vector3.up, Time.deltaTime * 5);
    }
}
