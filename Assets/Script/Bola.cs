using UnityEngine;

public class Bola : MonoBehaviour
{
    public float forcaRebote = 5f;
    private Rigidbody2D rb;
    private AudioSource audioSource;  // Referência ao AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Obtém o componente AudioSource
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Obter a direção do rebote com base na normal de colisão
        Vector2 direcaoRebote = collision.contacts[0].normal;

        // Aplicar o impulso na direção da colisão
        rb.AddForce(direcaoRebote * forcaRebote, ForceMode2D.Impulse);

        // Zerar a velocidade nos eixos que não queremos acumular
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);  // A velocidade já aplicada não acumula

        // Tocar o som quando a bola colidir com qualquer objeto
        if (audioSource != null)
        {
            audioSource.Play();  // Toca o som
        }
    }
}
