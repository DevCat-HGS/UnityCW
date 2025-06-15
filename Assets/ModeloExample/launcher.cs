using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Header("Photon")]
    public PhotonView playerPrefab;
    public Transform spawnPoint;

    [Header("UI")]
    public TextMeshProUGUI statusText;

    void Start()
    {
        ConnectToPhoton();
    }

    /// <summary>
    /// Conecta al servidor de Photon con la configuración por defecto.
    /// </summary>
    private void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
        statusText.text = "Conectando a Photon...";
    }

    /// <summary>
    /// Se llama cuando se conecta al servidor maestro.
    /// Intenta unirse a una sala aleatoria.
    /// </summary>
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        statusText.text = "Conectado a Photon. Buscando sala...";
        PhotonNetwork.JoinRandomRoom();
    }

    /// <summary>
    /// Se llama si no se pudo unir a una sala aleatoria.
    /// Crea una nueva sala con nombre fijo.
    /// </summary>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        statusText.text = "No se encontró una sala. Creando nueva sala...";
        CreateRoom();
    }

    /// <summary>
    /// Crea o se une a una sala con nombre fijo.
    /// </summary>
    private void CreateRoom()
    {
        string roomName = "Sala_001";
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        statusText.text = "Uniéndose o creando sala...";
    }

    /// <summary>
    /// Se llama cuando se une exitosamente a una sala.
    /// Instancia al jugador en el punto de aparición.
    /// </summary>
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        statusText.text = "Unido a la sala!";
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }
}
