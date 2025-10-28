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

    float saude = 0f;
    [HideInInspector] public bool injecaoDada = false;

    void Start()
    {
        saude = 0;
        barraSaude.value = 0;
        if (personagemImage != null) personagemImage.sprite = triste;
        if (personagemSprite != null) personagemSprite.sprite = triste;
        parabensTexto.SetActive(false);
    }

    public void AumentarSaude(float valor)
    {
        saude += valor;
        if (saude > 100) saude = 100;
        barraSaude.value = saude / 100f;

        if (saude >= 100)
            Recuperado();
    }

    void Recuperado()
    {
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        parabensTexto.SetActive(true);
        Invoke(nameof(Voltar), 2f);
    }

    void Voltar()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}



    



