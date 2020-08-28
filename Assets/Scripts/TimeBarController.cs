using UnityEngine;

public class TimeBarController : MonoBehaviour
{
  public GameController _gameCtrlScr;

  private RectTransform _timeBarTransform;
  private float _timeLeft = 5.0f;

  void Awake()
  {
    _timeBarTransform = GetComponent<RectTransform>();
  }

  void Update()
  {
    _timeBarTransform.localScale = new Vector3(_timeBarTransform.localScale.x, _timeLeft, _timeBarTransform.localScale.z);

    if (_timeLeft > 0)
      _timeLeft -= Time.deltaTime;
    else
      _gameCtrlScr.OnDeath();
  }

  public void AddTime()
  {
    float _elapsedTime = 5f - _timeLeft;
    
    if (_elapsedTime > 0.25f)
      _timeLeft += 0.25f;
    else
      _timeLeft += _elapsedTime;
  }
}
