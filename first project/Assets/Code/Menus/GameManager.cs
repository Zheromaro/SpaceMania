using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public GameObject completLevelUI;

    bool gameHasEnded = false;

    public void ComleteLevel()
    {
        completLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("GameOverMenuActive", 1f);
        }
    }

    void GameOverMenuActive()
    {
        gameOverMenu.SetActive(true);
    }

}
