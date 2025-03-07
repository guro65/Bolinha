using UnityEngine;
using TMPro;

public class Diretor : MonoBehaviour
{
    private string[] tags = { "Azul", "Vermelho", "Amarelo", "Verde", "Roxo" };
    private SpriteRenderer spriteRenderer;
    private static int pontuacao = 0;

    public PainelDeVitoria painelDeVitoria;  // Referência ao script de painel de vitória
    public TextMeshProUGUI textoPontuacao;  // Referência ao TextMeshPro para exibir a pontuação

    public AudioSource audioSource;  // Referência ao componente AudioSource

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();  // Obtém o componente AudioSource do quadrado

        // Definir a tag e a cor do objeto
        string tagAleatoria = tags[Random.Range(0, tags.Length)];
        gameObject.tag = tagAleatoria;
        MudarCor(tagAleatoria);
    }

    void MudarCor(string tag)
    {
        // Muda a cor do quadrado com base na tag
        switch (tag)
        {
            case "Azul":
                spriteRenderer.color = Color.blue;
                break;
            case "Vermelho":
                spriteRenderer.color = Color.red;
                break;
            case "Amarelo":
                spriteRenderer.color = Color.yellow;
                break;
            case "Verde":
                spriteRenderer.color = Color.green;
                break;
            case "Roxo":
                spriteRenderer.color = new Color(0.5f, 0, 0.5f); // Roxo
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            AdicionarPontuacao(gameObject.tag);

            // Verifica se o AudioSource está atribuído e toca o som
            if (audioSource != null)
            {
                audioSource.Play();  // Toca o som definido no AudioSource
            }

            Destroy(gameObject);  // Destruir o quadrado
            painelDeVitoria.VerificarFimJogo();  // Verificar se todos os quadrados foram destruídos
        }
    }

    void AdicionarPontuacao(string tag)
    {
        // Adiciona pontos com base na tag do quadrado
        switch (tag)
        {
            case "Azul":
                pontuacao += 5;
                break;
            case "Vermelho":
                pontuacao += 40;
                break;
            case "Amarelo":
                pontuacao += 10;
                break;
            case "Verde":
                pontuacao += 25;
                break;
            case "Roxo":
                pontuacao += 50;
                break;
        }

        // Atualizar a pontuação no painel de vitória
        if (painelDeVitoria != null)
        {
            painelDeVitoria.AtualizarPontuacao(pontuacao);
        }

        // Atualizar a pontuação no TextMeshPro
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontuação: " + pontuacao;
        }
    }
}
