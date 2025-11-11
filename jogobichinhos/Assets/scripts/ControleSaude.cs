using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // ✅ Importa o TextMeshPro

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

    float saude = 0f;
    [HideInInspector] public bool injecaoDada = false;
    [HideInInspector] public bool curativoDado = false;
    [HideInInspector] public bool termometroUsado = false;

    void Start()
    {
        saude = 0;
        barraSaude.value = 0;

        if (personagemImage != null) personagemImage.sprite = triste;
        if (personagemSprite != null) personagemSprite.sprite = triste;
        parabensTexto.SetActive(false);

        EsconderTodosBaloes();
        MostrarBalaoInjecao(); // começa com o primeiro balão
    }

    void EsconderTodosBaloes()
    {
        if (balaoInjecao != null) balaoInjecao.SetActive(false);
        if (balaoCurativo != null) balaoCurativo.SetActive(false);
        if (balaoTermometro != null) balaoTermometro.SetActive(false);
    }

    public void AplicarInjecao()
    {
        if (injecaoDada) return;
        injecaoDada = true;
        AumentarSaude(40);
        EsconderTodosBaloes();
        MostrarBalaoCurativo();
    }

    public void AplicarCurativo()
    {
        if (!injecaoDada || curativoDado) return;
        curativoDado = true;
        AumentarSaude(30);
        EsconderTodosBaloes();
        MostrarBalaoTermometro();
    }

    public void UsarTermometro()
    {
        if (!curativoDado || termometroUsado) return;
        termometroUsado = true;
        AumentarSaude(30);
        EsconderTodosBaloes();
    }

    public void AumentarSaude(float valor)
    {
        saude += valor;
        if (saude > 100) saude = 100;
        barraSaude.value = saude / 100f;

        if (saude >= 100)
            Recuperado();
    }

    void MostrarBalaoInjecao()
    {
        if (balaoInjecao != null)
        {
            balaoInjecao.SetActive(true);
            if (textoInjecao != null)
                textoInjecao.text = "Seu amiguinho precisa de uma injeção!";
        }
    }

    void MostrarBalaoCurativo()
    {
        if (balaoCurativo != null)
        {
            balaoCurativo.SetActive(true);
            if (textoCurativo != null)
                textoCurativo.text = "Agora coloque o curativo!";
        }
    }

    void MostrarBalaoTermometro()
    {
        if (balaoTermometro != null)
        {
            balaoTermometro.SetActive(true);
            if (textoTermometro != null)
                textoTermometro.text = "Vamos medir a temperatura!";
        }
    }

    void Recuperado()
    {
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        parabensTexto.SetActive(true);
        EsconderTodosBaloes();

        Invoke(nameof(Voltar), 2f);
    }

    void Voltar()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}

      