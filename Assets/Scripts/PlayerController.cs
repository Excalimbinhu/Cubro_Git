using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public GameController _gameCtrlScr;
  public TimeBarController _timeBarScr;

  private Material _playerMat;
  private AudioSource _jumpSound;
  private int _nextMove = 1;
  private bool _isColored = false;

  void Start()
  {
    _playerMat = GetComponent<Renderer>().material;
    _jumpSound = GetComponent<AudioSource>();
    _isColored = _gameCtrlScr._pathList[0]._colored;
    _playerMat.SetColor(_isColored);
  }

  void Update()
  {
    //Program Gameplay
  }

  public void PlayerMovement()
  {
    _jumpSound.Play();
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
    if(coll.gameObject.tag.Contains("Path"))
    {
      _timeBarScr.AddTime();
      switch (coll.gameObject.tag)
      {
        case "StandardPath":
          if (_gameCtrlScr.GetPathColor(_nextMove - 1) != _isColored)
            _gameCtrlScr.OnDeath();
          else
            _gameCtrlScr.AddScore();
          break;
      }
    }
  }
}
