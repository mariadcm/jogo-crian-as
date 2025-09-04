using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    public ControleSaude controle;
    public float valor = 30;
    public RectTransform alvoUI;
    public float duracao = 0.4f;
    bool usado = false;

    public void UsarItem()
    {
        if (usado) return;
        usado = true;
        StartCoroutine(MoverECurar());
    }

    IEnumerator MoverECurar()
    {
        if (alvoUI != null)
        {
            Vector2 inicio = transform.GetComponent<RectTransform>().anchoredPosition;
            Vector2 fim = alvoUI.anchoredPosition;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime / duracao;
                transform.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(inicio, fim, t);
                yield return null;
            }
        }
        controle.AumentarSaude(valor);
        gameObject.SetActive(false);
    }
}