using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ShootingGame_NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 600, false); // fullscreen = false

        string PlayerName = "Player " + Random.Range(0, 100);
        PhotonNetwork.NickName = PlayerName;
        print("Player Nickname: " + PhotonNetwork.NickName);

        //start connecting
        print("Starting Connect Process...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master Server");
        RoomOptions ro = new RoomOptions()
        {
            MaxPlayers = 8
        };

        PhotonNetwork.JoinOrCreateRoom("Room", ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.NickName + " has joined the Room");
        // instantiate player prefab
        Vector2 randomPos = Random.insideUnitCircle * 5f;
        PhotonNetwork.Instantiate("Player", new Vector3(randomPos.x, 1, randomPos.y), Quaternion.identity);
    }
}
