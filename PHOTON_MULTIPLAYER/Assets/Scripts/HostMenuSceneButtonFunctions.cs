using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HostMenuSceneButtonFunctions : MonoBehaviourPunCallbacks
{
    public TMP_InputField createRoomInputField;
    public GameObject loadingScreen;
    public Slider slider;

   

    private void Start()
    {
        createRoomInputField.characterLimit = 10;
     
        
    }

    public void OnClick_CreateRoom()
    {
        try
        {
           

            if (createRoomInputField.text == "")
            {
                return;
            }
            else
            {
                RoomOptions roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 4 };

                PhotonNetwork.CreateRoom(createRoomInputField.text, roomOptions, TypedLobby.Default);
                Debug.Log(createRoomInputField.text + " room created");
                OnJoinedRoom();
            }
        }
        catch(Exception e)
        {
            Debug.Log("Cant connect to master server. " + e);
        }
        

    }


    public override void OnJoinedRoom() // this is an override function. DONT CHANGE ITS NAME
    {
        
        Debug.Log("NASA ROOM KA NA");
    }

    /*public void SetRoomInfo(RoomInfo roomInfo)
    {
         string roomName = roomInfo.Name;

        //roomName.text = HMSBF_roomPlayersCount.createRoomInputField.text;
    }*/

    public void OnClick_LoadPreviousScene()
    {
        PhotonNetwork.LoadLevel("GameCreationScene");
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadSceneAsynchronously(sceneName));
    }

    IEnumerator LoadSceneAsynchronously(string sceneName)
    {
        AsyncOperation sceneOperation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!sceneOperation.isDone)
        {
            float progress = Mathf.Clamp01(sceneOperation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
