using TMPro;
using UnityEngine;
using System.Linq;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Diamonds;

    int coins = 0;
    int diamonds = 0;

    private void Start()
    {
        Coins.text = "<sprite=21><sprite=0>";

        Diamonds.text = "<sprite=21><sprite=0>";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("aaaa");
            coins++;
            collision.gameObject.SetActive(false);

            Coins.text = "<sprite=21>" + "<sprite=" + coins + ">";

            Destroy(collision.transform.parent.gameObject);
        }

        if (collision.CompareTag("Diamond"))
        {
            diamonds++;

            Diamonds.text = "<sprite=21>" + "<sprite=" + diamonds + ">";

            Destroy(collision.transform.parent.gameObject);
        }
    }
}
