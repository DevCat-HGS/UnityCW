using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LoadingSlider : MonoBehaviour
{
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;
    public GameObject canvasCarga;
    public GameObject panelJugador;
    public float loadingTime = 1f;

    void Start()
    {
        StartCoroutine(LoadingProgress());
    }

    IEnumerator LoadingProgress()
    {
        float elapsedTime = 0f;
        float currentValue = 0f;
        loadingSlider.value = 0f;

        while (elapsedTime < loadingTime)
        {
            elapsedTime += Time.deltaTime;
            float targetValue = (elapsedTime / loadingTime) * 100f;
            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * 1f);
            loadingSlider.value = currentValue;
            loadingText.text = $"Cargando... {(int)currentValue}%";
            yield return null;
        }

        // Asegurar que llegue al 100%
        loadingSlider.value = 100f;
        loadingText.text = "¡Carga completada!";

        // Cambiar los canvas
        canvasCarga.SetActive(false);
        panelJugador.SetActive(true);
    }
}