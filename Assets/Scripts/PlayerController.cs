using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public GameController _gameCtrlScr;
  public Material _playerMat;
  
  private int _nextMove = 1;
  private bool _isColored = false;

  void Start()
  {
    _isColored = _gameCtrlScr._pathList[0]._colored;
    _playerMat = GetComponent<Renderer>().material;
    _playerMat.SetColor(_isColored);
  }

  void Update()
  {
    //Program Gameplay
  }

  public void PlayerMovement()
  {
    if (_nextMove >= 9)
      _nextMove = 0;

    Vector3 nextPath = _gameCtrlScr.GetNextPath(_nextMove);
    transform.position = new Vector3(nextPath.x, 0.8f, nextPath.z);
    _nextMove++;
  }

  public void WalkChangeBtn()
  {
    PlayerMovement();
    _isColored = _playerMat.ChangeColor(_isColored);
    _gameCtrlScr.BuildPath();
  }

  public void WalkBtn()
  {
    PlayerMovement();
    _gameCtrlScr.BuildPath();
  }

  private void OnCollisionEnter(Collision coll)
  {
    switch (coll.gameObject.tag)
    {
      case "StandardPath":
        if (_gameCtrlScr.GetPathColor(_nextMove - 1) != _isColored)
        {
          PlayerPrefs.SetInt("runScore", _gameCtrlScr._score);
          SceneManager.LoadScene(0);
        }
        else
          _gameCtrlScr.AddScore();
        break;
    }
  }
}
