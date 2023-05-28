using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingGame_Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PhotonView pv = other.gameObject.GetComponent<PhotonView>();
            if(!pv.IsMine)
            {
                pv.RPC("Damage", RpcTarget.AllBuffered, 0.1f);
            }
        }
        Destroy(gameObject);
    }
}
