using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public GameObject[] _planePrefab = new GameObject[5];
  public PathList[] _pathList = new PathList[9];
  public int _score = -1;

  private Text _scoreTxt;
  private bool _right = true;
  private int _pathCtrl = 0;
  private int _lastPath = 0;

  private void Awake()
  {
    _scoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
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

  public bool GetPathColor(int listID)
  {
    return _pathList[listID]._colored;
  }

  public Vector3 GetNextPath(int listID)
  {
    return _pathList[listID]._path.transform.position;
  }

  public void AddScore()
  {
    _score++;
    _scoreTxt.text = _score.ToString();
  }
}