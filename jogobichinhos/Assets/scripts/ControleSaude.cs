using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    [Header("Textos dos balões (TMP)")]
    public TMP_Text textoInjecao;
    public TMP_Text textoCurativo;
    public TMP_Text textoTermometro;

    // saúde interna
    private float saude = 0f;
    private const float SAUDE_MAX = 100f;

    // flags de etapas (evitam reaplicar)
    [HideInInspector] public bool injecaoDada = false;
    [HideInInspector] public bool curativoDado = false;
    [HideInInspector] public bool termometroUsado = false;

    void Start()
    {
        saude = 0f;
        if (barraSaude != null) barraSaude.value = 0f;
        if (parabensTexto != null) parabensTexto.SetActive(false);

        if (personagemImage != null) personagemImage.sprite = triste;
        if (personagemSprite != null) personagemSprite.sprite = triste;

        EsconderTodosBaloes();
        MostrarBalaoInjecao(); // começa pedindo a injeção
        Debug.Log("[ControleSaude] Start. saude=" + saude);
    }

    // --- método público chamado pelo ItemDropTarget ---
    public void AumentarSaude(float valor)
    {
        Debug.Log("[ControleSaude] AumentarSaude chamado. valor=" + valor + " antes saude=" + saude);
        saude += valor;
        if (saude > SAUDE_MAX) saude = SAUDE_MAX;
        if (barraSaude != null) barraSaude.value = saude / SAUDE_MAX;
        Debug.Log("[ControleSaude] Após aumento -> saude=" + saude + " barra=" + (barraSaude != null ? barraSaude.value.ToString() : "no slider"));
    }

    void EsconderTodosBaloes()
    {
        if (balaoInjecao != null) balaoInjecao.SetActive(false);
        if (balaoCurativo != null) balaoCurativo.SetActive(false);
        if (balaoTermometro != null) balaoTermometro.SetActive(false);
    }

    void MostrarBalaoInjecao()
    {
        EsconderTodosBaloes();
        if (balaoInjecao != null)
        {
            balaoInjecao.SetActive(true);
            if (textoInjecao != null) textoInjecao.text = "Hora da injeção! ";
        }
    }

    void MostrarBalaoCurativo()
    {
        EsconderTodosBaloes();
        if (balaoCurativo != null)
        {
            balaoCurativo.SetActive(true);
            if (textoCurativo != null) textoCurativo.text = "Agora coloque o curativo! ";
        }
    }

    void MostrarBalaoTermometro()
    {
        EsconderTodosBaloes();
        if (balaoTermometro != null)
        {
            balaoTermometro.SetActive(true);
            if (textoTermometro != null) textoTermometro.text = " Vamos lá, falta pouco para ele se curar é a vez do termomêtro!";
        }
        
    }

    // --- métodos chamados pelo ItemDropTarget (NÂO aumentam saude) ---
    public void AplicarInjecao()
    {
        if (injecaoDada) return;
        injecaoDada = true;

        Debug.Log("[ControleSaude] AplicarInjecao() - injecaoDada set true");
        // mostra próxima instrução
        MostrarBalaoCurativo();
    }

    public void AplicarCurativo()
    {
        if (!injecaoDada || curativoDado) return;
        curativoDado = true;

        Debug.Log("[ControleSaude] AplicarCurativo() - curativoDado set true");
        MostrarBalaoTermometro();
    }

    public void AplicarTermometro()
    {
        if (!curativoDado || termometroUsado) return;
        termometroUsado = true;

        Debug.Log("[ControleSaude] AplicarTermometro() - termometroUsado set true");
        EsconderTodosBaloes();

        //verifica se saúde já está completa
        if (saude >= SAUDE_MAX)
        {
            Recuperado();
        }
        else
        {
            Debug.Log("[ControleSaude] Termometro aplicado mas saude insuficiente: " + saude);
        }
    }

    void Recuperado()
    {
        Debug.Log("[ControleSaude] Recuperado() chamado. saude=" + saude);
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        if (parabensTexto != null) parabensTexto.SetActive(true);

        // volta à sala depois de 2s
        Invoke(nameof(Voltar), 2f);
    }

    void Voltar()
    {
        if (!string.IsNullOrEmpty(nomeCenaSalaEspera))
            SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}
