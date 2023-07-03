using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightRotationConroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRotation(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = rotation;
    }
}
