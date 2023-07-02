using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagNames.Player)
        {
            Freeze(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == TagNames.Player)
        {
            Freeze(true);
        }
    }

    void Freeze(bool frozen)
    {
        Rigidbody crate = transform.gameObject.GetComponent<Rigidbody>();
        if (frozen)
        {
            crate.constraints = RigidbodyConstraints.FreezeAll;
        } else
        {
            crate.constraints &= ~RigidbodyConstraints.FreezePositionX;
            crate.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
    }
}
