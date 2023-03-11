using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class StartSceneDirector : MonoBehaviour
{
    public TMP_InputField player_name_field;
    public TMP_InputField room_id_field;
    private Regex regex = new Regex(@"^[0-9]{4}$");


    private void Awake() {
        GameDataObject.dataObj.before_scene = SceneManager.GetActiveScene().name;
    }

    public void RoomCreateButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }

    public void RoomEnterButtonListener(){
        
        if(!regex.IsMatch(room_id_field.text)){
            Debug.Log("room Id error");
            return ;
        }

        GameDataObject.dataObj.ChangePlayerName(player_name_field.text);
        GameDataObject.dataObj.roomID = int.Parse(room_id_field.text);
        GameDataObject.dataObj.chips = 10000;
        
        SceneManager.LoadScene("LobbyScene");
    }
}
