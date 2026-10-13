
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        Transform player = other.transform;

        while (player != null)
        {
            if (player.CompareTag("Player"))
            {
                if (collected)
                    return;

                collected = true;

                if (CoinManager.Instance != null)
                {
                    CoinManager.Instance.AddCoin();
                }

                // Desativa apenas este objeto
                gameObject.SetActive(false);

                return;
            }

            player = player.parent;
        }
    }
}