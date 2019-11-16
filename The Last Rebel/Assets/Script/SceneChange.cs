using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void GotoHomeScreenScene()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
