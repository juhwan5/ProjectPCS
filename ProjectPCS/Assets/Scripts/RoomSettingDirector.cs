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
            player_name_field.text = GameDataObject.dataObj.playerData.player_name;
            chips_field.text = GameDataObject.dataObj.playerData.reserved_chips.ToString();
        }
    }


    public void RoomCreateButtonListener(){
        if(chips_field.text == ""){
            Debug.Log("No Chips");
            return;
        }

        GameDataObject.dataObj.playerData.ChangePlayerName(player_name_field.text);
        GameDataObject.dataObj.playerData.reserved_chips = int.Parse(chips_field.text);

        bool create_room_message = CreateRoomMessager();

        if (create_room_message){
            SceneManager.LoadScene("LobbyScene");
        }else{
            Debug.Log("Room creating connection fail");
        }
    }

    public void BackButtonListener(){
        SceneManager.LoadScene(GameDataObject.dataObj.before_scene);
    }


    bool CreateRoomMessager(){
        GameDataObject.dataObj.playerData.room_ID = Random.Range(1000,9999);
        return true;
    }
}
