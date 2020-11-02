using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection playerInfo;
    public int selectedCharacter;
    public GameObject[] allCharacters;

    private void OnEnable()
    {
        // initalize singleton
        if (CharacterSelection.playerInfo == null)
        {
            CharacterSelection.playerInfo = this;
        }
        else
        {
            if (CharacterSelection.playerInfo != this)
            {
                Destroy(CharacterSelection.playerInfo.gameObject);
                CharacterSelection.playerInfo = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            selectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        
        }
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", selectedCharacter);
        }
    }

   
}
