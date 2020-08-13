using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
  public Transform _player;
  private Vector3 _offset = new Vector3(12f, 8f, -9f);

  private void LateUpdate()
  {
    transform.position = _player.position + _offset;
    transform.LookAt(_player);
  }
}
