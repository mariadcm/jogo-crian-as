using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleSaude : MonoBehaviour
{
    public Slider barraSaude;
    public Image personagem;
    public Sprite triste, feliz;
    public GameObject parabensTexto;
    public string nomeCenaSalaEspera = "SalaEspera";

    float saude = 0;

    void Start()
    {
        barraSaude.value = 0;
        personagem.sprite = triste;
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
        personagem.sprite = feliz;
        parabensTexto.SetActive(true);
        Invoke(nameof(Voltar), 2f);
    }

    void Voltar() => SceneManager.LoadScene(nomeCenaSalaEspera);
