using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnTable : MonoBehaviour
{
    public static SpawnTable Instance;

    [Header("Photon")]
    public PhotonView TablePrefab;
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
            // Instanciar el prefab de la mesa
            PhotonNetwork.Instantiate(TablePrefab.name, SpawnPoint.position, SpawnPoint.rotation);
            Debug.Log("Table spawned successfully!");
        }
        else
        {
            Debug.LogError("Not connected to Photon or not in a room.");
        }
    }
}
