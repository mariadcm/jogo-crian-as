using UnityEngine;
using System.Collections;

public class ItemUsavel : MonoBehaviour
{
    public ControleSaude controle;  // arraste o GameController
    public float valor = 30f;       // quanto aumenta
    public bool ehInjecao = false;  // marque true para a seringa
    public bool precisaInjecao = false; // true para band-aid

    bool usado = false;

    public void Usar()
    {
        if (usado) return;
        if (precisaInjecao && (controle == null || controle.injecaoDada == false))
        {
            Debug.Log("Use a injeção primeiro.");
            return;
        }
        StartCoroutine(DoUso());
    }

    IEnumerator DoUso()
    {
        usado = true;
        // pequeno efeito visual (pulsar)
        Vector3 orig = transform.localScale;
        float t=0f, d=0.3f;
        while (t < d)
        {
            t += Time.deltaTime;
            transform.localScale = orig * (1f + 0.12f * Mathf.Sin((t/d)*Mathf.PI));
            yield return null;
        }
        transform.localScale = orig;

        if (ehInjecao && controle != null) controle.injecaoDada = true;
        if (controle != null) controle.Aumentar(valor);

        gameObject.SetActive(false);
    }
}



