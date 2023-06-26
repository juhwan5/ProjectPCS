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
    }


    public void RoomCreateButtonListener(){
        if(chips_field.text == ""){
            Debug.Log("No Chips");
            return;
        }
    
        int start_chips = int.Parse(chips_field.text);

        bool create_room_message = RoomCreateMessager(int.Parse(chips_field.text), player_name_field.text);

        if (create_room_message){

            SceneManager.LoadScene("LobbyScene");
        }else{
            Debug.Log("Room creating connection fail");
        }
    }

    public void BackButtonListener(){
        SceneManager.LoadScene(GameDataObject.dataObj.before_scene);
    }


    bool RoomCreateMessager(int start_chips, string player_name){
        ServerMessage msg = TestDataStreamer.dataObj.RoomCreateMessager(start_chips, player_name);

        if (msg.is_connect_success){
            GameDataObject.dataObj.room_ID = msg.room_ID;
            GameDataObject.dataObj.personal_user_ID = msg.user_ID;
            GameDataObject.dataObj.start_chips = msg.start_chips;
            GameDataObject.dataObj.player_data_list.Add(msg.player_data_instance);

            return true;
        }
        
        return false;
    }
}
