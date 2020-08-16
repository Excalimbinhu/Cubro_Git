using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
  class MainMenuController : MonoBehaviour
  {
    private Text _highScoreTxt;

    private void Start()
    {
      int runScore = PlayerPrefs.GetInt("runScore"),
        highScore = PlayerPrefs.GetInt("highScore");
      
      if(runScore > highScore)
      {
        PlayerPrefs.SetInt("highScore", runScore);
        highScore = runScore;
      }

      _highScoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
      _highScoreTxt.text = "Last Run Score:\n" 
        + runScore
        + "\n\n"
        + "High Score:\n"
        + highScore;
    }

    public void GoToGame()
    {
      SceneManager.LoadScene(1);
    }
  }
}
