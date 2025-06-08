using UnityEngine;
using TMPro;

public class DisplayPlayerMoney : MonoBehaviour
{
    public TMP_Text moneyText;

    void Start()
    {
        if (moneyText != null)
        {
            int playerMoney = PlayerPrefs.GetInt("DineroJugador", 0);
            moneyText.text = playerMoney.ToString();
        }
        else
        {
            Debug.LogError("No se ha asignado el componente TMP_Text para mostrar el dinero.");
        }
    }
}