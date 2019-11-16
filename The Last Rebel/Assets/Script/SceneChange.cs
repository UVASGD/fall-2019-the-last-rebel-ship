using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GotoGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void GotoHomeScreenScene()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
