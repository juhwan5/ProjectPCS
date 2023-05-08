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

        bool create_room_message = RoomCreateMessager(int.Parse(chips_field.text),player_name_field.text);

        if (create_room_message){
            GameDataObject.dataObj.ServerSynch();
            SceneManager.LoadScene("LobbyScene");
        }else{
            Debug.Log("Room creating connection fail");
        }
    }

    public void BackButtonListener(){
    }


    bool RoomCreateMessager(int start_chips, string player_name){
        int room_ID = TestDataStreamer.dataObj.RoomCreateMessager(start_chips, player_name);

        if (room_ID >= 1000){
            GameDataObject.dataObj.room_ID = room_ID;
            return true;
        }
        
        return false;
    }
}
