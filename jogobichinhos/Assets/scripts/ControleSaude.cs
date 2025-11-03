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

    [Header("Efeito de Confete 🎉")]
    public GameObject confettiPrefab; // arraste o prefab Confetti aqui no Inspector

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
        // Muda o sprite para o bichinho feliz
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        // Mostra o texto "Parabéns!"
        parabensTexto.SetActive(true);

        // Cria partículas de confete acima do bichinho 🎉
        if (confettiPrefab != null)
            Instantiate(confettiPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);

        // Volta para a sala de espera depois de 2 segundos
        Invoke(nameof(Voltar), 2f);
    }

    void Voltar()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}
