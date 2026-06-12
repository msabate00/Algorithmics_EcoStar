using System.Text;
using TMPro;
using UnityEngine;

public class Lifebar : MonoBehaviour
{
    [Header("Referencias")]
    private TMP_Text heartsText;

    public PlayerMovement playerMovement;

    //Configuración de Sprites
    private const int INDEX_LLENO = 0;
    private const int INDEX_MEDIO = 1;
    private const int INDEX_VACIO = 2;

    private const int TOTAL_CORAZONES = 10;


    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        ActualizarCorazones(playerMovement.healt);
    }

    public void ActualizarCorazones(int vidaActual)
    {
        // 1. Validamos que la vida no se pase de 0 ni de 100
        vidaActual = Mathf.Clamp(vidaActual, 0, 100);

        // 2. Calculamos cuántos "medios corazones" representan esa vida (cada uno vale 5 pts)
        // Usamos RoundToInt por si la vida baja en números impares
        int fragmentosRestantes = Mathf.RoundToInt(vidaActual / 5f);

        // Usamos StringBuilder que es más eficiente para armar textos dentro de bucles
        StringBuilder stringBuilder = new StringBuilder();

        // 3. Iteramos exactamente 10 veces (una por cada corazón que debemos dibujar)
        for (int i = 0; i < TOTAL_CORAZONES; i++)
        {
            if (fragmentosRestantes >= 2)
            {
                // Tiene suficiente vida para un corazón lleno
                stringBuilder.Append($"<sprite={INDEX_LLENO}>");
                fragmentosRestantes -= 2;
            }
            else if (fragmentosRestantes == 1)
            {
                // Solo le queda medio corazón de vida
                stringBuilder.Append($"<sprite={INDEX_MEDIO}>");
                fragmentosRestantes -= 1;
            }
            else
            {
                // No queda vida para este corazón, va vacío
                stringBuilder.Append($"<sprite={INDEX_VACIO}>");
            }
        }

        // 4. Asignamos el texto final al componente de TextMeshPro
        heartsText.text = stringBuilder.ToString();
    }
}
