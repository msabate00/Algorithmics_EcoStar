using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public Canvas lobby;
    public Canvas configuration;


    public void ChargeLevel(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }


    public void OpenConfiguration()
    {
        lobby.enabled = false;

        configuration.enabled = true;
    }

    public void ExitConfiguration()
    {
        lobby.enabled = true;

        configuration.enabled = false;
    }
}
