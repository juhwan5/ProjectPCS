using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoomSettingDirector : MonoBehaviour
{
    public TMP_InputField player_name_field;
    public TMP_InputField chips_field;

    private void Awake() {
        if (GameDataObject.dataObj.before_scene == "LobbyScene"){
            player_name_field.text = GameDataObject.dataObj.player_name;
            chips_field.text = GameDataObject.dataObj.chips.ToString();
        }
    }


    public void RoomCreateButtonListener(){
        if(chips_field.text == ""){
            Debug.Log("No Chips");
            return;
        }

        if(GameDataObject.dataObj.before_scene != "LobbyScene"){
            GameDataObject.dataObj.roomID = Random.Range(1000, 9999);
        }

        GameDataObject.dataObj.ChangePlayerName(player_name_field.text);
        GameDataObject.dataObj.chips = int.Parse(chips_field.text);

        SceneManager.LoadScene("LobbyScene");
    }

    public void BackButtonListener(){
        SceneManager.LoadScene(GameDataObject.dataObj.before_scene);
    }
}
