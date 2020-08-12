using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController _gameCtrlScr;
    public Material _playerMat;
    private int _nextMove = 1;

    private bool _isColored =  false;
    
    private void Awake()
    {
        _playerMat = GetComponent<Renderer>().material;
    }

    void Start()
    {
        _isColored = _playerMat.ChangeColor(_isColored);
    }

    void Update()
    {
        //Program Gameplay
    }

    public void PlayerMovement()
    {
        if (_nextMove >= 9)
            _nextMove = 0;

        Vector3 nextPath = _gameCtrlScr.getNextPath(_nextMove);
        transform.position = new Vector3(nextPath.x, 1, nextPath.z);
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
        switch(coll.gameObject.tag)
        {
            case "StandardPath":
                if (_gameCtrlScr.getPathColor(_nextMove - 1) != _isColored)
                    Destroy(gameObject);
                else
                {
                    Debug.Log("VAI MININU");
                }
                break;
        }
    }
}
