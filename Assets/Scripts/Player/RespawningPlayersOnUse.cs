using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningPlayersOnUse : MonoBehaviour, IUsingControllable
{
    [SerializeField] GameObject player;

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void Use()
    {
        PhotonNetwork.Destroy(photonView);
        PhotonNetwork.Instantiate(player.name, player.transform.position, Quaternion.identity);
    }
}
