using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public static string playerName;
    public TMP_InputField nameInput;
    public Button saveButton;
    private string[] randomNames = { "Alex", "Juan", "Gamer", "Winner", "Champion", "Star", "Lucky", "Master", "Pro", "Legend", "Hero" };

    void Start()
    {
        if (string.IsNullOrEmpty(playerName))
        {
            GenerateRandomName();
        }

        if (nameInput != null)
        {
            nameInput.text = playerName;
        }

        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SavePlayerName);
        }
    }

    void GenerateRandomName()
    {
        int randomIndex = Random.Range(0, randomNames.Length);
        playerName = randomNames[randomIndex];
    }

    public void SavePlayerName()
    {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            playerName = nameInput.text;
        }
    }

    public static string GetPlayerName()
    {
        return playerName;
    }
}
