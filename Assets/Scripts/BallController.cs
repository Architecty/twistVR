using UnityEngine;
using VRStandardAssets.Utils;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private VRInput m_VRInput;
    private Rigidbody _rigidbody;
  public float power = 5f;

  private float _angle = 0f;

  private void Awake() {
    _rigidbody = GetComponent<Rigidbody>();
  }

    //private void OnEnable()
    //{
    //    m_VRInput.OnSwipe += HandleSwipe;
    //}


    //private void OnDisable()
    //{
    //    m_VRInput.OnSwipe -= HandleSwipe;
    //}


    //Handle the swipe events by applying AddTorque to the Ridigbody
    //private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
    //{
    //    switch (swipeDirection)
    //    {
    //        case VRInput.SwipeDirection.NONE:
    //            break;
    //        case VRInput.SwipeDirection.UP:
    //            _rigidbody.AddTorque(new Vector3(0f, 0f, 1f) * power);
    //            break;
    //        case VRInput.SwipeDirection.DOWN:
    //            _rigidbody.AddTorque(new Vector3(0f, 0f, -1f) * power);
    //            break;
    //        case VRInput.SwipeDirection.LEFT:
    //            _rigidbody.AddTorque(new Vector3(-1f, 0f, 0f) * power);
    //            break;
    //        case VRInput.SwipeDirection.RIGHT:
    //            _rigidbody.AddTorque(new Vector3(1f, 0f, 0f) * power);
    //            break;
    //    }
    //}

    private void Update() {
        if (Input.GetButton("Fire1"))
        {
            Vector2 mousePosition = Input.mousePosition;
            float screenHeight = Screen.height;
            float screenWidth = Screen.width;

            float newY = (mousePosition.x - (screenWidth / 2f)) / (screenWidth / 2f);
            float newX = (mousePosition.y - (screenHeight / 2f)) / (screenHeight / 2f);

            _rigidbody.AddTorque(new Vector3(newY, 0f, -newX) * power);
        }

            //if (Input.GetButton("Forward")) {
            //  _rigidbody.AddTorque(new Vector3(1f, 0f, 0f) * power);
            //}

            //if (Input.GetButton("Backward")) {
            //  _rigidbody.AddTorque(new Vector3(-1f, 0f, 0f) * power);
            //}

            //if (Input.GetButton("Left")) {
            //  _rigidbody.AddTorque(new Vector3(0f, 0f, 1f) * power);
            //}

            //if (Input.GetButton("Right")) {
            //  _rigidbody.AddTorque(new Vector3(0f, 0f, -1f) * power);
            //}
    }
}
