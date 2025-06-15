using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnDice : MonoBehaviour
{
    public static SpawnDice Instance;

    [Header("Photon")]
    public PhotonView DicePrefab;
    public Transform SpawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Spawnear()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            // Instantiate the dice prefab at the spawn point
            PhotonNetwork.Instantiate(DicePrefab.name, SpawnPoint.position, SpawnPoint.rotation);
            Debug.Log("Dice spawned successfully!");
        }
        else
        {
            Debug.LogError("Not connected to Photon or not in a room.");
        }
    }
}
