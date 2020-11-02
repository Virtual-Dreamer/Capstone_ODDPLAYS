using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitRoomButtonFunctions : MonoBehaviourPunCallbacks
{
    
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       
        Debug.Log("You left");
        PhotonNetwork.LoadLevel("GameCreationScene");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect(); 
        Debug.Log("You left the room");
        
        PhotonNetwork.LoadLevel("GameCreationScene");
        
    }
}
