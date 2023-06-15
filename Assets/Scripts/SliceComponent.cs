using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEditor.Rendering;

public class SliceComponent : MonoBehaviour
{
    [SerializeField] GameObject target;
    //[SerializeField] Material crossSectionMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Slice(target, target.GetComponent<Material>());
    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        Slice(collision.gameObject, collision.gameObject.GetComponent<MeshRenderer>().material);
    }

    public void Slice(GameObject target, Material crossMaterial)
    {
        SlicedHull hull = target.Slice(this.transform.position, this.transform.up);

        if (hull == null) return;
        
        GameObject upperHull = hull.CreateUpperHull(target, crossMaterial);
        GameObject lowerHull = hull.CreateLowerHull(target, crossMaterial);
        
        Destroy(target);
    }
}
