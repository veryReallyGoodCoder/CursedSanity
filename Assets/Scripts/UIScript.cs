using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    
    public void OnStart()
    {
        SceneManager.LoadScene("OutdoorsScene");
        Debug.Log("start");
    }

    public void OnExit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

}
