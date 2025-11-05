using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleSaude : MonoBehaviour
{
    [Header("UI")]
    public Slider barraSaude;
    public GameObject parabensTexto;
    public string nomeCenaSalaEspera = "SalaEspera";

    [Header("Personagem (um dos dois)")]
    public Image personagemImage;           // para UI
    public SpriteRenderer personagemSprite; // para objeto 2D
    public Sprite triste;
    public Sprite feliz;

    [Header("Balões de fala")]
    public GameObject balaoInjecao;
    public GameObject balaoCurativo;
    public GameObject balaoTermometro;

    float saude = 0f;
    bool injecaoDada = false;
    bool curativoDado = false;
    bool termometroUsado = false;

    void Start()
    {
        saude = 0;
        if (barraSaude != null) barraSaude.value = 0;
        if (personagemImage != null) personagemImage.sprite = triste;
        if (personagemSprite != null) personagemSprite.sprite = triste;
        if (parabensTexto != null) parabensTexto.SetActive(false);

        // mostra o primeiro balão (injecao) no início
        MostrarBalaoInjecao();
        Debug.Log("Start: mostra balao injecao");
    }

    void EsconderTodosBaloes()
    {
        if (balaoInjecao != null) balaoInjecao.SetActive(false);
        if (balaoCurativo != null) balaoCurativo.SetActive(false);
        if (balaoTermometro != null) balaoTermometro.SetActive(false);
    }

    public void MostrarBalaoInjecao()
    {
        EsconderTodosBaloes();
        if (balaoInjecao != null) balaoInjecao.SetActive(true);
        Debug.Log("MostrarBalaoInjecao()");
    }

    public void MostrarBalaoCurativo()
    {
        EsconderTodosBaloes();
        if (balaoCurativo != null) balaoCurativo.SetActive(true);
        Debug.Log("MostrarBalaoCurativo()");
    }

    public void MostrarBalaoTermometro()
    {
        EsconderTodosBaloes();
        if (balaoTermometro != null) balaoTermometro.SetActive(true);
        Debug.Log("MostrarBalaoTermometro()");
    }

    // --- chamadas pelo ItemDropTarget ---
    public void AplicarInjecao()
    {
        Debug.Log("AplicarInjecao() called. injecaoDada=" + injecaoDada);
        if (injecaoDada) return; // só pode uma vez

        injecaoDada = true;
        // quando aplicar, escondemos o balão de instrução da injeção imediatamente
        if (balaoInjecao != null) balaoInjecao.SetActive(false);

        AumentarSaude(30);
        // após aplicar, mostrar instrução do curativo
        MostrarBalaoCurativo();
        Debug.Log("Injeção aplicada → mostra balão curativo");
    }

    public void AplicarCurativo()
    {
        Debug.Log("AplicarCurativo() called. curativoDado=" + curativoDado + " injecaoDada=" + injecaoDada);
        if (!injecaoDada || curativoDado) return;

        curativoDado = true;
        if (balaoCurativo != null) balaoCurativo.SetActive(false);

        AumentarSaude(30);
        // mostra instrução do termômetro
        MostrarBalaoTermometro();
        Debug.Log("Curativo aplicado → mostra balão termômetro");
    }

    public void UsarTermometro()
    {
        Debug.Log("UsarTermometro() called. termometroUsado=" + termometroUsado + " curativoDado=" + curativoDado);
        if (!curativoDado || termometroUsado) return;

        termometroUsado = true;
        if (balaoTermometro != null) balaoTermometro.SetActive(false);

        AumentarSaude(40); // completa a saúde
        Debug.Log("Termometro usado → saúde atual = " + saude);
    }

    public void AumentarSaude(float valor)
    {
        Debug.Log("AumentarSaude called. valor=" + valor + " antes saude=" + saude);
        saude += valor;
        if (saude > 100) saude = 100;

        if (barraSaude != null) barraSaude.value = saude / 100f;
        Debug.Log("Depois: saude=" + saude + " barra=" + (barraSaude != null ? barraSaude.value.ToString() : "no slider"));

        if (saude >= 100)
            Recuperado();
    }

    void Recuperado()
    {
        Debug.Log("Recuperado() chamado");
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        if (parabensTexto != null) parabensTexto.SetActive(true);
        EsconderTodosBaloes();

        Invoke(nameof(Voltar), 2f);
    }

    void Voltar()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}

