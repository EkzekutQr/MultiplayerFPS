using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningPlayersCube : MonoBehaviour
{
    [SerializeField] GameObject newPlayer;
    public void RespawnPlayer(GameObject currentPlayer)
    {
        PhotonNetwork.Instantiate(newPlayer.name, newPlayer.transform.position, Quaternion.identity);
        PhotonNetwork.Destroy(currentPlayer.GetPhotonView());
    }
}
