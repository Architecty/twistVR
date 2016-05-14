using UnityEngine;

public class BallController : MonoBehaviour {
  private Rigidbody _rigidbody;
  public float power = 5f;

  private float _angle = 0f;

  private void Awake() {
    _rigidbody = GetComponent<Rigidbody>();
  }

  private void Update() {
    if (Input.GetKey(KeyCode.UpArrow)) {
      _rigidbody.AddTorque(new Vector3(1f, 0f, 0f) * power);
    }

    if (Input.GetKey(KeyCode.DownArrow)) {
      _rigidbody.AddTorque(new Vector3(-1f, 0f, 0f) * power);
    }

    if (Input.GetKey(KeyCode.LeftArrow)) {
      _rigidbody.AddTorque(new Vector3(0f, 0f, 1f) * power);
    }

    if (Input.GetKey(KeyCode.RightArrow)) {
      _rigidbody.AddTorque(new Vector3(0f, 0f, -1f) * power);
    }
  }
}
