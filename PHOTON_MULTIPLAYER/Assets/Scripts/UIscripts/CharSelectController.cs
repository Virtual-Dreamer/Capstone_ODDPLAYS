using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelectController : MonoBehaviour
{
    

    public void OnCharacterSelect(int characterChoice)
    {
        if (CharacterSelection.playerInfo != null && PhotonNetwork.IsMasterClient)
        {
            CharacterSelection.playerInfo.selectedCharacter = characterChoice;
            PlayerPrefs.SetInt("MyCharacter", characterChoice);

            Debug.Log(characterChoice.ToString());
                    
            PhotonNetwork.LoadLevel("Gameplay");
           

            
        }

        else if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.LoadLevel("Gameplay");

            /*GameObject[] spawnManager = SceneManager.GetActiveScene().GetRootGameObjects();
            Debug.Log(spawnManager.Length);
            foreach (GameObject obj in spawnManager)
            {
                Debug.Log(obj.name);
            }*/

            // DITO KA NASTOP ALLEXUS 31/10/2020
            /*CharacterSetup charSetup = spawnManager.GetComponent<CharacterSetup>();
            charSetup.pv.RPC("RPC_clientCharacterSpawn", RpcTarget.OthersBuffered, CharacterSelection.playerInfo.selectedCharacter);*/
        }
    }

    public void OnClick_LoadPreviousScene()
    {
        PhotonNetwork.LoadLevel("HostMenuScene");
    }

    
}
