using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public GameObject[] _planePrefab = new GameObject[5];
  public PathList[] _pathList = new PathList[9];

  private bool _right = true;
  private int _pathCtrl = 0;
  private int _lastPath = 0;

  private void Awake()
  {
    _pathList[_pathCtrl] = new PathList(GameObject.Find("Plane"));
    StartPath();
  }

  
  public void StartPath()
  {
    int changeSide;

    for (int ctrl = 0; ctrl <= 7; ctrl++)
    {
      changeSide = Random.Range(0, 2);
      if (changeSide == 1)
        _right = !_right;

      SaveAndBuildPath(_pathList[_pathCtrl].SetDirection(_right));
    }
  }

  public void SaveAndBuildPath(Vector3 pathPos)
  {
    int colored = Random.Range(0, 2);

    _pathCtrl++;
    if (_pathCtrl >= 9)
      _pathCtrl = 0;

    if (colored == 1)
      _pathList[_pathCtrl] = new PathList(Instantiate(_planePrefab[0], pathPos, Quaternion.Euler(0, 0, 0)));
    else
      _pathList[_pathCtrl] = new PathList(Instantiate(_planePrefab[0], pathPos, Quaternion.Euler(0, 0, 0)));
  }

  public void BuildPath()
  {
    int changeSide = Random.Range(0, 2);

    if (changeSide == 1)
      _right = !_right;

    DeletePath();
    SaveAndBuildPath(_pathList[_pathCtrl].SetDirection(_right));

  }

  public void DeletePath()
  {
    if (_lastPath >= 9)
      _lastPath = 0;

    Destroy(_pathList[_lastPath]._path);
    _pathList[_lastPath] = null;
    _lastPath++;
  }

  public bool getPathColor(int listID)
  {
    return _pathList[listID]._colored;
  }

  public Vector3 getNextPath(int listID)
  {
    return _pathList[listID]._path.transform.position;
  }
}