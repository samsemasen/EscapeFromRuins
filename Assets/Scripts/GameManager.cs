
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        Invoke("LvlComplete", restartDelay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void EndGame()
    {
        if(gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            // restart the game
            Invoke("Restart", restartDelay);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LvlComplete()
    {
        completeLevelUI.SetActive(true);
    }
}
