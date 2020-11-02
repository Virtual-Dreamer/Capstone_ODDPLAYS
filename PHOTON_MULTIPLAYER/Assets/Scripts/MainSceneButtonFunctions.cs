using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneButtonFunctions : MonoBehaviourPunCallbacks
{

    public GameObject closePopUpWindow;
    public Button disableMainBtn;
    public Button closeGame;
    public Button settings;
    public Button infoCredits;


    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //OnConnectedToMaster();
       
    }
    public void OnClick_moveToMenuScene()
    {
        PhotonNetwork.LoadLevel("GameCreationScene");
    }

    public void OnClick_closeGame()
    {
        closePopUpWindow.SetActive(true);
        disableMainBtn.interactable = false;
        closeGame.interactable = false;
        settings.interactable = false;
        infoCredits.interactable = false;


    }

    public void OnClick_PopUpExitGame()
    {
        Debug.Log("EXITING");
        Application.Quit();
        
    }

    public void OnClick_cancelExit()
    {
        closePopUpWindow.SetActive(false);
        disableMainBtn.interactable = true;
        closeGame.interactable = true;
        settings.interactable = true;
        infoCredits.interactable = true;
    }

    public override void OnConnectedToMaster() // this is an override function. DONT CHANGE ITS NAME
    {
        PhotonNetwork.JoinLobby();
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("lobby");
    }
}
