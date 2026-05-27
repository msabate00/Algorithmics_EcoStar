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
            coins++;


            Coins.text = "<sprite=21>" + NumberToText(coins);

            Destroy(collision.transform.parent.gameObject);
        }

        if (collision.CompareTag("Diamond"))
        {
            diamonds++;

            Diamonds.text = "<sprite=21>" + NumberToText(diamonds);

            Destroy(collision.transform.parent.gameObject);
        }
    }

    public string NumberToText(int number)
    {
        string numberAsText = number.ToString();


        char[] digits = numberAsText.ToCharArray();


        string finalText = "<sprite=" + string.Join("><sprite=", digits) + ">";

        return finalText;
    }
}
