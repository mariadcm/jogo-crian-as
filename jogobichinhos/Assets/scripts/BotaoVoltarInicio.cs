using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltarInicio : MonoBehaviour
{
    public string nomeCenaInicio = "Inicio";  // coloque exatamente o nome da sua cena inicial

    public void IrParaInicio()
    {
        SceneManager.LoadScene(nomeCenaInicio);
    }
}
