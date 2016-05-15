using UnityEngine;
using System.Collections;

public class PinballMachine : MonoBehaviour {

    float pullBall = 0f;
    public float pullTime = 3f;
    public float pullFactor = 100f;
    public GameObject slammer;
    public GameObject ball;

    Vector3 slammerStart;
    Vector3 ballStart;

	// Use this for initialization
	void Start () {
        slammerStart = slammer.transform.position;
        ballStart = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            ball.transform.position = ballStart;
            slammer.transform.position = slammerStart;
        }

        if (Input.GetButton("Fire1"))
        {
            if(pullBall < 1f)
            {
                pullBall += Time.deltaTime / pullTime;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            flipPaddles();
        }


        if (Input.GetButtonUp("Fire1"))
        {
            releaseLauncher();
        }

    }

    void flipPaddles()
    {

    }

    void releaseLauncher()
    {
        Debug.Log(pullBall);
        slammer.GetComponent<Transform>().GetComponent<Rigidbody>().AddExplosionForce(pullFactor * pullBall, slammer.GetComponent<Transform>().position + Vector3.back, 3f, 0f);
        pullBall = 0f;
    }
}
