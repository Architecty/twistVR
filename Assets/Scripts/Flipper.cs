using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

    public float downRotation = -30f;
    public float upRotation = 45f;

    public float spring = 10000f;
    public float damper = 50f;

    public AudioClip flipperUp;
    public AudioClip flipperDown;

    public AudioSource thisSource;

    HingeJoint thisJoint;

    JointSpring upSpring;
    JointSpring downSpring;

	// Use this for initialization
	void Start () {
        thisJoint = transform.GetComponentInChildren<HingeJoint>();

        upSpring = new JointSpring();
        upSpring.spring = spring;
        upSpring.damper = damper;
        upSpring.targetPosition = upRotation;

        downSpring = new JointSpring();
        downSpring.spring = spring;
        downSpring.damper = damper;
        downSpring.targetPosition = downRotation;


        thisJoint.spring = downSpring;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            thisJoint.spring = upSpring;
            thisSource.clip = flipperUp;
            thisSource.Play();
        }


        if (Input.GetButtonUp("Fire1"))
        {
            thisJoint.spring = downSpring;
            thisSource.clip = flipperDown;
            thisSource.Play();
        }
    }
}
