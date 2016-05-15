using UnityEngine;
using System.Collections;

public class paddlePop : MonoBehaviour {
    
    public float popForce = 500000f;

    void OnCollisionEnter(Collision whichCollision)
    {
        Debug.Log(whichCollision.collider.tag);
        if (whichCollision.collider.tag == "Ball")
        {
            Debug.Log("Should Pop");
            whichCollision.collider.GetComponent<Rigidbody>().AddExplosionForce(popForce * whichCollision.relativeVelocity.magnitude, whichCollision.contacts[0].point, 2f);
        }
    }
}
