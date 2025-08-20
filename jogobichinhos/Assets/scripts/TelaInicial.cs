using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("SalaEspera");
    }
}
