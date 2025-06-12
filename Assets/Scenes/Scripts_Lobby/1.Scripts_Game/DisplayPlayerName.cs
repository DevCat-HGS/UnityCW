using UnityEngine;
using TMPro;

public class DisplayPlayerName : MonoBehaviour
{
    public TMP_Text displayNameText;

    void Start()
    {
        if (displayNameText != null)
        {
            displayNameText.text = Name.GetPlayerName();
        }
    }
}