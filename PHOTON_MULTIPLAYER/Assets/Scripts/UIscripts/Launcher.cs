using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject connectedScreen;
    public GameObject DisconnectedScreen;
    public bool disconnected;


    public void OnClickBtn()
    {
        disconnected = true; // to avoid warnings, we should be disconnected before runtime
        PhotonNetwork.ConnectUsingSettings(); // connect to the master server using your settings in PhotonServerSettings
        
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        DisconnectedScreen.SetActive(true); // if we disconnect, the disconnect screen will be activated
        Debug.Log("DC AKO!");
        Debug.Log(cause.ToString());
    }

    /*public override void OnJoinedLobby() // kapag nakasali na tayo sa lobby, matatawag tong method na to. getchi?
    {
        if (DisconnectedScreen.activeSelf)
        {
            DisconnectedScreen.SetActive(false);
        }

        connectedScreen.SetActive(true); // activate the connected screen UI 
        


    }*/
 

}
