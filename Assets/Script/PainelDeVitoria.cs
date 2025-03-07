using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PainelDeVitoria : MonoBehaviour
{
    public GameObject painel;  // O painel de vitória (com botões e texto)
    public TextMeshProUGUI textoPontuacao;  // Referência ao TextMeshPro para exibir a pontuação
    private static int pontuacao = 0;
    private static int quadradosRestantes;
    private static int quadradosDestruídos;

    void Start()
    {
        // Inicialize o painel como desativado
        painel.SetActive(false);

        // Contar o número de quadrados restantes na cena
        quadradosRestantes = GameObject.FindGameObjectsWithTag("Quadrado").Length;
        quadradosDestruídos = 0;  // Inicializa a quantidade de quadrados destruídos
    }

    // Método que é chamado quando todos os quadrados foram destruídos
    public void ExibirPainelVitoria()
    {
        // Ativar o painel de vitória
        painel.SetActive(true);

        // Atualizar o texto do painel com a pontuação final
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontuação Final: " + pontuacao;
        }

        // Pausar o jogo (timeScale = 0 pausa o jogo, mas UI ainda funciona)
        Time.timeScale = 0;
    }

    // Método chamado para verificar se todos os quadrados foram destruídos
    public void VerificarFimJogo()
    {
        // Incrementa o número de quadrados destruídos
        quadradosDestruídos++;

        // Verifica se o número de quadrados destruídos é igual ao número total de quadrados
        if (quadradosDestruídos >= quadradosRestantes)
        {
            ExibirPainelVitoria();  // Exibe o painel de vitória
        }
    }

    // Método para atualizar a pontuação (caso você precise passar a pontuação de outro script)
    public void AtualizarPontuacao(int novaPontuacao)
    {
        pontuacao = novaPontuacao;
    }

    // Método para reiniciar o jogo (exemplo de ação de botão)
    public void ReiniciarJogo()
    {
        Time.timeScale = 1;  // Retorna o tempo ao normal
        // Lógica de reiniciar a cena ou o jogo aqui, exemplo:
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Método para sair do jogo (exemplo de ação de botão)
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
