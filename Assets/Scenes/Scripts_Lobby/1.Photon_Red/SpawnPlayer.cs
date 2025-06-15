using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer Instance;

    [Header("Photon")]
    public PhotonView PlayerPrefab1;
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
            // Instantiate the player prefab at the spawn point
            PhotonNetwork.Instantiate(PlayerPrefab1.name, SpawnPoint.position, SpawnPoint.rotation);
            Debug.Log("Player spawned successfully!");
        }
        else
        {
            Debug.LogError("Not connected to Photon or not in a room.");
        }
    }
}
