using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingGame_PlayerMove : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if(photonView.IsMine)
        {
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500f;
            transform.Rotate(0, h, 0);

            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
            transform.Translate(0, 0, v);
        }

        if(transform.position.y < -5)
        {
            Vector2 randomPos = Random.insideUnitCircle * 5f;
            transform.position = new Vector3(randomPos.x, 1, randomPos.y);


        }
    }
}
