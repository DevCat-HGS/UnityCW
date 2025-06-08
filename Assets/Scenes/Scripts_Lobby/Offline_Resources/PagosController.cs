using UnityEngine;
using TMPro;

public class PagosController : MonoBehaviour
{
    public TextMeshProUGUI pagosText;
    private int valorActual = 0; 

    void Start()
    {
        // Cargar el valor guardado de PlayerPrefs
        valorActual = PlayerPrefs.GetInt("DineroJugador", 0);
        if (pagosText != null)
        {
            pagosText.text = valorActual.ToString();
        }
        else
        {
            Debug.LogError("No se ha asignado el componente TextMeshProUGUI.");
        }
    }

    public void Pago1()
    {
        ActualizarValor(1000);
    }

    public void Pago2()
    {
        ActualizarValor(5000);
    }

    public void Pago3()
    {
        ActualizarValor(10000);
    }

    public void Pago4()
    {
        ActualizarValor(20000);
    }

    public void Pago5()
    {
        ActualizarValor(50000);
    }

    public void Pago6()
    {
        ActualizarValor(100000);
    }

    private void ActualizarValor(int cantidad)
    {
        valorActual += cantidad;
        if (pagosText != null)
        {
            pagosText.text = valorActual.ToString();
            // Guardar el valor actualizado en PlayerPrefs
            PlayerPrefs.SetInt("DineroJugador", valorActual);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("No se ha asignado el componente TextMeshProUGUI.");
        }
    }
}
