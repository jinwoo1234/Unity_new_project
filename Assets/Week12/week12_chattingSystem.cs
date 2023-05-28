using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class week12_chattingSystem : MonoBehaviourPunCallbacks
{
    public GameObject SetName;
    public GameObject ConnectionStatus;
    public TMP_InputField UserName;

    // Start is called before the first frame update
    void Start()
    {
        ConnectionStatus.SetActive(true);
        SetName.SetActive(false);

        Screen.SetResolution(800, 600, false);
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.AutomaticallySyncScene = true;

        print("Starting Connection Process...");
        ConnectionStatus.GetComponent<TMP_Text>().text = "Starting Connection Process...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server");
        ConnectionStatus.GetComponent<TMP_Text>().text = "Connected to Server.";
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
        ConnectionStatus.GetComponent<TMP_Text>().text = "Joined Lobby";

        ConnectionStatus.SetActive(false);
        SetName.SetActive(true);
    }

    public void OnClick_JoinOnCreateRoom()
    {
        RoomOptions ro = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 10
        };

        PhotonNetwork.NickName = UserName.text;
        PhotonNetwork.JoinOrCreateRoom("Room", ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("Joined Room");

        PhotonNetwork.LoadLevel("week12_chatting_Finish");
    }
}
