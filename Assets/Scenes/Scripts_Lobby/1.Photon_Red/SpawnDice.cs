using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class SpawnDice : MonoBehaviour
{
    public static SpawnDice Instance;
    public GameObject DicePrefab;
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
            PhotonNetwork.Instantiate(DicePrefab.name, SpawnPoint.position, SpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("[SpawnDice] No se ha conectado a Photon o no está en una sala.");
        }
    }
}
