using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Scene_PlayButtonCallNextScene : MonoBehaviour
{
    public Button main_scene_call_next_scene_btn;

    public void callNextScene()
    {
        PhotonNetwork.LoadLevel("MenuScene");
    }
}
