using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PainelDeVitoria : MonoBehaviour
{
    public GameObject painel;  // O painel de vit�ria (com bot�es e texto)
    public TextMeshProUGUI textoPontuacao;  // Refer�ncia ao TextMeshPro para exibir a pontua��o
    private static int pontuacao = 0;
    private static int quadradosRestantes;
    private static int quadradosDestru�dos;

    void Start()
    {
        // Inicialize o painel como desativado
        painel.SetActive(false);

        // Contar o n�mero de quadrados restantes na cena
        quadradosRestantes = GameObject.FindGameObjectsWithTag("Quadrado").Length;
        quadradosDestru�dos = 0;  // Inicializa a quantidade de quadrados destru�dos
    }

    // M�todo que � chamado quando todos os quadrados foram destru�dos
    public void ExibirPainelVitoria()
    {
        // Ativar o painel de vit�ria
        painel.SetActive(true);

        // Atualizar o texto do painel com a pontua��o final
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontua��o Final: " + pontuacao;
        }

        // Pausar o jogo (timeScale = 0 pausa o jogo, mas UI ainda funciona)
        Time.timeScale = 0;
    }

    // M�todo chamado para verificar se todos os quadrados foram destru�dos
    public void VerificarFimJogo()
    {
        // Incrementa o n�mero de quadrados destru�dos
        quadradosDestru�dos++;

        // Verifica se o n�mero de quadrados destru�dos � igual ao n�mero total de quadrados
        if (quadradosDestru�dos >= quadradosRestantes)
        {
            ExibirPainelVitoria();  // Exibe o painel de vit�ria
        }
    }

    // M�todo para atualizar a pontua��o (caso voc� precise passar a pontua��o de outro script)
    public void AtualizarPontuacao(int novaPontuacao)
    {
        pontuacao = novaPontuacao;
    }

    // M�todo para reiniciar o jogo (exemplo de a��o de bot�o)
    public void ReiniciarJogo()
    {
        Time.timeScale = 1;  // Retorna o tempo ao normal
        // L�gica de reiniciar a cena ou o jogo aqui, exemplo:
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // M�todo para sair do jogo (exemplo de a��o de bot�o)
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
