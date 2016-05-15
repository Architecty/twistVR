using UnityEngine;
using System.Collections;

public class PinballMachine : MonoBehaviour {

    float pullBall = 0f;
    public float pullTime = 3f;
    public float pullFactor = 100f;
    public GameObject slammer;
    public GameObject ball;
    HingeJoint[] flippers = new HingeJoint[0];

    

    bool isStart = true;

    Vector3 slammerStart;
    Vector3 ballStart;

	// Use this for initialization
	void Start () {
        //GameObject[] allFlippers = GameObject.FindGameObjectsWithTag("Flippers");
        //flippers = new HingeJoint[allFlippers.Length];
        //for(int i = 0; i < allFlippers.Length; i++)
        //{
        //    flippers[i] = allFlippers[i].GetComponent<HingeJoint>();
        //}
        slammerStart = slammer.transform.position;
        ballStart = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            resetPinball();
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
            flipPaddles(45f);
        }


        if (Input.GetButtonUp("Fire1"))
        {
            if(isStart == true)
            {
                StartCoroutine(releaseLauncher());
            } else
            {
                flipPaddles(-30f);
            }
        }

    }

    void flipPaddles(float flipperRotation)
    {
        //for(int i = 0; i < flippers.Length; i++)
        //{
        //    flippers[i].spring.targetPosition = flipperRotation;
        //}
    }

    void resetPinball()
    {
        ball.transform.position = ballStart;
        isStart = true;
    }

    IEnumerator releaseLauncher()
    {
        isStart = true;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        slammer.GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log(pullBall);
        slammer.GetComponent<Transform>().GetComponent<Rigidbody>().AddExplosionForce(pullFactor * pullBall, slammer.GetComponent<Transform>().position + Vector3.back, 3f, 0f);
        pullBall = 0f;

        yield return new WaitForSeconds(1f);

        slammer.GetComponent<Rigidbody>().isKinematic = true;
        //slammer.transform.position = slammerStart;
        
    }
}
