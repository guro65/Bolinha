using UnityEngine;

public class DestruirBola : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Bola"
        if (collision.gameObject.CompareTag("Bola"))
        {
            Destroy(collision.gameObject);  // Destrói o GameObject com a tag "Bola"
        }
    }
}
