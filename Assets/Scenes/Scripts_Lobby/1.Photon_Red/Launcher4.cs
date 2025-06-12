using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Launcher4 : MonoBehaviourPunCallbacks
{
    // [Header("Photon")]
    // public PhotonView playerPrefab;
    // public Transform spawnPoint;

    [Header("UI")]
    public TextMeshProUGUI statusText;

    void Start()
    {
        ConnectToPhoton();
    }

    private void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
        statusText.text = "Conectando a Photon...";
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        statusText.text = "Conectado a Photon. Buscando sala...";
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        statusText.text = "No se encontró una sala. Creando nueva sala...";
        CreateRoom();
    }

    private void CreateRoom()
    {
        string roomName = "Sala_4Players";
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        statusText.text = "Uniéndose o creando sala...";
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        statusText.text = "Unido a la sala!";
        // PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        ComponentPlayer();
    }

    public void ComponentPlayer()
    {
        if (NamePlayer.Instance != null)
        {
            Debug.Log($"[Launcher4] Jugador unido a la sala. Número de jugador: {PhotonNetwork.CurrentRoom.PlayerCount}");
            NamePlayer.Instance.AssignPlayerName();
        }
        else
        {
            Debug.LogError("[Launcher4] No se encontró la instancia de NamePlayer");
        }
    }
}
