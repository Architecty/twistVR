using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

    public float popForce = 500000f;

    public bool allowPop = false;
    GameObject whichTrigger; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (allowPop == true)
            {
                transform.GetComponent<Rigidbody>().AddExplosionForce(popForce, whichTrigger.transform.position, 15f);
                Debug.Log("Should Add Pop");
            }
        }
    }

    void OnTriggerEnter(Collider whichCollider)
    {
        if(whichCollider.tag == "PopBox")
        {
            allowPop = true;
            whichTrigger = whichCollider.gameObject;
        }
    }

    void OnTriggerExit(Collider whichCollider)
    {
        if (whichCollider.tag == "PopBox")
        {
            allowPop = false;
        }
    }
}
