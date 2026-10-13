
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto tocou na Finish Line: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador chegou à meta!");

            GameTimer timer = FindObjectOfType<GameTimer>();

            if (timer != null)
            {
                timer.EndGame(true);
            }
            else
            {
                Debug.LogError("GameTimer não foi encontrado na cena!");
            }
        }
    }
}