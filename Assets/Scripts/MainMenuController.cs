using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
  class MainMenuController : MonoBehaviour
  {
    public void GoToGame()
    {
      SceneManager.LoadScene(1);
    }
  }
}
