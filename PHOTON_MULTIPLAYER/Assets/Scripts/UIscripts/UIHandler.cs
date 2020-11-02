using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // import tong namespace na to para maka-interact tayo sa UI elements (Text, Input Field etc...) ng Unity
using Photon.Pun;
using Photon.Realtime; // kailangan ata to sa room creation di ko pa sure


public class UIHandler : MonoBehaviourPunCallbacks
{
    public InputField createRoom;
    public InputField joinRoom;


    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text, new RoomOptions {MaxPlayers = 4 }, null); // itong method na to
        //magte-take ng tatlong parameters. Yung una is yung magiging ROOM NAME galing sa INPUT FIELD NA createRoom.text
        // Yung pangalawa is ROOM OPTIONS. sa case na to, ang nilagay ko lang is yung MAX PLAYERS which is 4.
        // Yung pangatlo is type ng lobby. wala pa akong alam gaano about dyan pero di naman ata big deal sa ngayon
        // matatawag tong method na to kapag pinindot yung button na CREATE ROOM

        if (createRoom.text == "")
        {
            return;
        }
        else
        {
            Debug.Log(createRoom.text + "ROOM CREATED!");
            PhotonNetwork.LoadLevel("CharacterSelect");
           
        }


        

        
    }

    /*first, i'm new too, I just started learning photon

What I do is:

Set PhotonNetwork.AutosyncScene = true; at the start

then

If(PhotonNetwork.IsMasterClient)
    {
        PhotonNetwork.LoadScene("SceneName");
    }

this way all clients will load the same scene that the host loads...
*/
    
 

    public void OnClick_JoinRoom()
    {

        if (joinRoom.text == "")
        {
            return;
        }
        else
        {
            Debug.Log("wala ka pa sa room");
            PhotonNetwork.LoadLevel("CharacterSelect");

            
            
        }
        // tulad ng nasa taas, matatawag tong method na to pag pinindot yung JOIN ROOM na button
        // need nito ng dalawang parameters. Yung una is yung name ng room na gusto mong salihan.
        // manggagaling yon sa INPUT FIELD nung join room.
        // Yung pangalawa is yung expected players. not a big deal din as of now
        
        
    }


    public override void OnJoinedRoom() // matatawag tong method na to pag nakasali tayo ng room successfully
    {
        // HINDI TO NATATAWAG ALLEXUS!

        Debug.Log("HINDI NATATAWAG TONG OnJoinedRoom() ALLEXUS!");
        //PhotonNetwork.LoadLevel("CharacterSelect");

    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room: " + joinRoom.text + ". " + message);
        Debug.Log("Return code: " + returnCode);
    }

}
