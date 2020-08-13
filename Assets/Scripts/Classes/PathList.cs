using System.Collections;
using UnityEngine;
using System.Collections.Generic;

/*
 * Lembrete IMPORTANTE
 * 
 * Reestruturar GameController de acordo com o PathList
 * 
 * Try to let every variable as "private" and use them as props with get and set.
 * Use the method "PathList" as the constructor for a new object.
 */

public class PathList
{
  public GameObject _path;
  public bool _colored;

  private Material _pathMat;

  public PathList(GameObject newPlane)
  {
    _path = newPlane;
    SetColor();
  }

  private void SetColor()
  {
    _pathMat = _path.GetComponent<Renderer>().material;

    if (Random.Range(0, 2) == 1)
    {
      _colored = true;
      _pathMat.SetColor(_colored);
    }
    else
    {
      _colored = false;
      _pathMat.SetColor(_colored);
    }
  }

  private void SetDirection()
  {

  }
}
