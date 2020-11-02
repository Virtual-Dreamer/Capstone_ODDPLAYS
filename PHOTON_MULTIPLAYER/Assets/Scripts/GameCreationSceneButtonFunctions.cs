using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreationSceneButtonFunctions : MonoBehaviourPunCallbacks
{
    
    public void OnClick_LoadCreateRoomScene()
    {
        PhotonNetwork.LoadLevel("HostMenuScene");
    }

    public void OnClick_JoinRoom()
    {

        Debug.Log("JOINED ROOM");
        Debug.Log(PhotonNetwork.InLobby);
        PhotonNetwork.LoadLevel("JoinRoomList");
        
        //PhotonNetwork.JoinRoom(joinRoomInputField.text);
    }

    public void OnClick_LoadPreviousScene()
    {
        PhotonNetwork.LoadLevel("MainScene");
    }

}
