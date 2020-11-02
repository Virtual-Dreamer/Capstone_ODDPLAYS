using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetup : MonoBehaviour
{
    public PhotonView pv; // declare a PhotonView variable
    public GameObject myCharacter;
    //public int valueOfCharacter;


    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>(); // get the "PhotonView" component and set it to pv variable
        if (pv.IsMine) // check kung local player tayo
        {
            if (PhotonNetwork.InRoom)
            {
                pv.RPC("RPC_CharacterAdd", RpcTarget.AllBuffered, CharacterSelection.playerInfo.selectedCharacter);
            }
            
        }
        else
        {
    
            pv.RPC("RPC_clientCharacterSpawn", RpcTarget.OthersBuffered, CharacterSelection.playerInfo.selectedCharacter);
            Debug.Log("JOIN A ROOM");
        }
    }

    [PunRPC]
    public void RPC_CharacterAdd(int chosenCharacter)
    {
        //valueOfCharacter = chosenCharacter;
        myCharacter = PhotonNetwork.Instantiate(CharacterSelection.playerInfo.allCharacters[chosenCharacter].name, transform.position, transform.rotation, 0);
       
        Debug.Log(pv.ViewID + "ITO YUNG ID");
       /* pv.ViewID = pv.ViewID++;
        PhotonNetwork.AllocateViewID(true);*/

    }

    [PunRPC]
    public void RPC_clientCharacterSpawn_(int chosenCharacter)
    {
        //valueOfCharacter = chosenCharacter;
       myCharacter = PhotonNetwork.Instantiate(CharacterSelection.playerInfo.allCharacters[chosenCharacter].name, transform.position, transform.rotation, 0);

        Debug.Log(pv.ViewID + "ITO YUNG ID");
        /*pv.ViewID = pv.ViewID++;
        PhotonNetwork.AllocateViewID(true);*/

    }

}
