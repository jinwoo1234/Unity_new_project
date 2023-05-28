using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class week12_chatting_Finish : MonoBehaviourPunCallbacks
{
    public TMP_Text ChatLog;
    public TMP_Text UserList;
    public TMP_InputField Userinput;
    List<string> ChatLogs = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if(string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 999);
            print("Player Name:" + PhotonNetwork.NickName);
        }
        foreach (var Player in PhotonNetwork.PlayerList)
        {
            print("Player:" + Player.NickName);
        }
        UpdateUsers();
    }

    void UpdateUsers()
    {
        print("Update Users");
        string users = "Users\n";
        foreach(var Player in PhotonNetwork.PlayerList)
        {
            if(Player.NickName == PhotonNetwork.LocalPlayer.NickName)
            {
                users += Player.NickName + "(Me)\n";
            }
            else
            {
                users += Player.NickName + "\n";
            }
        }
        UserList.text = users;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName + "entered the room");
        UpdateUsers();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateUsers();
    }

    public void OnClicked_SendMessage()
    {
        string Sender = PhotonNetwork.LocalPlayer.NickName;
        string input = Userinput.text;
        string Message = Sender + ":" + input;
        // RPC
        photonView.RPC("UpdateMessage", RpcTarget.AllBuffered, Message);

        Userinput.text = "";
        Userinput.ActivateInputField();
    }

    [PunRPC]
    void UpdateMessage(string _Message)
    {
        ChatLogs.Add(_Message);
        ChatLog.text = "";
        for(int i = 0; i < ChatLogs.Count; i++)
        {
            ChatLog.text += ChatLogs[i] + "\n";
        }
    }
}