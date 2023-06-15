using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEditor.Rendering;

public class SliceComponent : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Material crossSectionMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Slice(target);
    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        Slice(target);
    }

    public void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(this.transform.position, this.transform.up);

        if (hull == null) return;
        
        GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
        GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
        
        Destroy(target);
    }
}
