using UnityEngine;
using TMPro;
using Photon.Pun;

public class NamePlayer : MonoBehaviourPunCallbacks
{
    public static NamePlayer Instance { get; private set; }
    public TMP_Text[] playerNameTexts;
    private string playerName;
    private new PhotonView photonView;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
             DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        photonView = GetComponent<PhotonView>();
        if (photonView == null)
        {
            Debug.LogError("[NamePlayer] PhotonView no encontrado en el objeto");
        }
    }

    void Start()
    {
        Debug.Log("[NamePlayer] Start - Iniciando configuración de nombre");
        playerName = Name.GetPlayerName();
        Debug.Log($"[NamePlayer] Nombre obtenido: {playerName}");

        if (playerNameTexts == null || playerNameTexts.Length == 0)
        {
            Debug.LogError("[NamePlayer] Array de TMP_Text no configurado o vacío");
            return;
        }

        Debug.Log($"[NamePlayer] Número de textos configurados: {playerNameTexts.Length}");
        
        // Asignar nombre automáticamente al iniciar
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            AssignPlayerName();
        }

        // Solicitar nombres actuales a todos los jugadores
        if (photonView.IsMine)
        {
            photonView.RPC("RequestPlayerNames", RpcTarget.All);
        }
    }

    public void AssignPlayerName()
    {
        Debug.Log("[NamePlayer] AssignPlayerName - Iniciando asignación");
        
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogError("[NamePlayer] No conectado a Photon");
            return;
        }

        if (playerNameTexts == null)
        {
            Debug.LogError("[NamePlayer] playerNameTexts es null");
            return;
        }

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = Name.GetPlayerName();
        }

        int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        Debug.Log($"[NamePlayer] ActorNumber del jugador: {PhotonNetwork.LocalPlayer.ActorNumber}");
        Debug.Log($"[NamePlayer] Número de jugador calculado: {playerNumber}");
        Debug.Log($"[NamePlayer] Total de jugadores en la sala: {PhotonNetwork.CurrentRoom.PlayerCount}");

        if (playerNumber >= 0 && playerNumber < playerNameTexts.Length)
        {
            Debug.Log($"[NamePlayer] Asignando nombre {playerName} al jugador {playerNumber}");
            photonView.RPC("SyncPlayerName", RpcTarget.All, playerName, playerNumber);
            Debug.Log("[NamePlayer] RPC SyncPlayerName enviado");
        }
        else
        {
            Debug.LogError($"[NamePlayer] Índice de jugador fuera de rango: {playerNumber}, Máximo permitido: {playerNameTexts.Length - 1}");
        }
    }

    [PunRPC]
    void SyncPlayerName(string name, int playerIndex)
    {
        Debug.Log($"[NamePlayer] SyncPlayerName recibido - Nombre: {name}, Índice: {playerIndex}");

        if (playerNameTexts == null)
        {
            Debug.LogError("[NamePlayer] playerNameTexts es null en SyncPlayerName");
            return;
        }

        if (playerIndex >= 0 && playerIndex < playerNameTexts.Length)
        {
            playerNameTexts[playerIndex].text = name;
            Debug.Log($"[NamePlayer] Nombre sincronizado correctamente para el jugador {playerIndex}");
        }
        else
        {
            Debug.LogError($"[NamePlayer] Índice inválido en SyncPlayerName: {playerIndex}");
        }
    }

    [PunRPC]
    void RequestPlayerNames()
    {
        Debug.Log("[NamePlayer] Recibida solicitud de nombres");
        if (!string.IsNullOrEmpty(playerName))
        {
            int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber - 1;
            if (playerNumber >= 0 && playerNumber < playerNameTexts.Length)
            {
                photonView.RPC("SyncPlayerName", RpcTarget.All, playerName, playerNumber);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (photonView.IsMine)
        {
            // Enviar nuestro nombre al nuevo jugador
            int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber - 1;
            if (playerNumber >= 0 && playerNumber < playerNameTexts.Length)
            {
                photonView.RPC("SyncPlayerName", RpcTarget.All, playerName, playerNumber);
            }
        }
    }
}