// Copyright 2016 Evertoon.
//
//

using UnityEngine;

public class FollowCam : MonoBehaviour {
  public Transform target;
  private Vector3 _offset;

  public void Start() {
    _offset = transform.position - target.position;
  }

  public void Update() {
    transform.position = target.position + _offset;
  }
}
