using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ShootingGame_PlayerName : MonoBehaviourPunCallbacks
{
    public TMP_Text PlayerName;
    public Transform Canvas;

    // Start is called before the first frame update
    void Start()
    {
        print("NickNam:" + photonView.Owner.NickName);
        PlayerName.text = photonView.Owner.NickName;
        gameObject.name = photonView.Owner.NickName;
        if(photonView.IsMine)
        {
            PlayerName.color = Color.green;
        }
        else
        {
            PlayerName.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Canvas.forward = Camera.main.transform.forward;
    }


}
