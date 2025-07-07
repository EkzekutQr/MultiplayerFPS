using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMPro.TextMeshProUGUI logText;
    public TMPro.TextMeshProUGUI LogText { get => logText; }

    void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        Log("Player's name is set to " + PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("ConnectedToMaster");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new Photon.Realtime.RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.CreateRoom(Random.Range(1000, 9999).ToString(), roomOptions);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        //PhotonNetwork.LoadLevel("Game");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");

        PhotonNetwork.LoadLevel("Game");
    }

    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    PhotonNetwork.ReconnectAndRejoin();
    //}

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
}
