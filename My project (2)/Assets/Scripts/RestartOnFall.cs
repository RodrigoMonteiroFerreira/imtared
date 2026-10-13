using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    public float limiteDeQueda = -10f;

    void Update()
    {
        if (transform.position.y < limiteDeQueda)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}