using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    public string nomeCenaSalaEspera = "SalaEspera";

    public void VoltarParaSala()
    {
        SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}
