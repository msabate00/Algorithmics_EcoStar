using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject[] gameObjects;

    public enum Modes
    {
        DestroyBox,
        SpawnCoins
    }

    public Modes mode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (mode)
        {
            case Modes.DestroyBox:
                break;
            
            case Modes.SpawnCoins:
                break;
        }
    }
}
