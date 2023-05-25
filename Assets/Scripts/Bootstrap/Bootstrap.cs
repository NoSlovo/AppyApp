using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
  private void Start()
  {
    LoadGame();
  }

  private void LoadGame()
  {
    var loaderScene =  SceneManager.LoadSceneAsync(1);
  }
  
}
