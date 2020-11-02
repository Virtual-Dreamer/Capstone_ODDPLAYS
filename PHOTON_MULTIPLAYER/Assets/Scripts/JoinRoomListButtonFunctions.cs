using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class JoinRoomListButtonFunctions : MonoBehaviourPunCallbacks
{


    private void Start()
    {
       
    }

    public void OnClick_LoadPreviousScene()
    {
        PhotonNetwork.LoadLevel("GameCreationScene");

    }

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.LoadLevel("CharacterSelect");
    }



    
}
