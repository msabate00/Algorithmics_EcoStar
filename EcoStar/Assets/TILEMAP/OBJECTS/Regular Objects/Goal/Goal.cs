using UnityEngine;

public class Goal : MonoBehaviour
{
    public LobbyManager lobbyManager;

    public string levelToCharge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lobbyManager.ChargeLevel(levelToCharge);
        }
    }
}
