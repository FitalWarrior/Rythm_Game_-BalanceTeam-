using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("Level1");
    }
}
