using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LobbyRoomDirector : MonoBehaviour
{
    public Transform targetCanvas;
    public TextMeshProUGUI p1_txt;
    public TextMeshProUGUI room_ID_txt;
    public TextMeshProUGUI chips_txt;

    public float player_txt_y_term = -200f;


    private List<PlayerData> player_data_list = new List<PlayerData>();
    private int dummy_number = 1;
    private Vector3 player_name_position;
    
    private void Awake() {
        player_data_list.Add(GameDataObject.dataObj.playerData);
        GameDataObject.dataObj.before_scene = SceneManager.GetActiveScene().name;
        player_name_position = targetCanvas.Find("PlayerNameTxtPosition").GetComponent<RectTransform>().anchoredPosition3D;
        
        DrawScreen();
        
    }

    private void DrawScreen(){
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("PlayerNameTxt");
        foreach  (GameObject prefab in prefabs){
            Destroy(prefab);
        }
        
        //Draw RoomId, Chips
        room_ID_txt.text = "RoomID : " + GameDataObject.dataObj.playerData.room_ID.ToString();
        chips_txt.text = "Chips : " + GameDataObject.dataObj.playerData.reserved_chips.ToString();


        //Draw Player Name
        for (int i=0; i < 8; i++){
            string next_name = "";
            if (i < player_data_list.Count){
                next_name = player_data_list[i].player_name;
            }
            TextMeshProUGUI player_txt = Instantiate(p1_txt, targetCanvas);
            player_txt.text = "*  " + next_name;
            player_txt.transform.GetComponent<RectTransform>().anchoredPosition3D = player_name_position + new Vector3(0, player_txt_y_term * i, 0);
        }
    }


    private void NewPlayerComeIn(){
        PlayerData dummyPlayerData = new PlayerData();
        dummyPlayerData.player_name = "DummYPlayer " + dummy_number++.ToString();
        player_data_list.Add(dummyPlayerData);
        DrawScreen();
    }

    private void PlayerGetOut(){
        bool is_getout = false;
        for (int i=0; i < player_data_list.Count; i++){
            string[] target_name = player_data_list[i].player_name.Split();
            if (target_name[0] == "DummYPlayer"){
                player_data_list.RemoveAt(i);
                is_getout = true;
                break;
            }
        }
        
        if (is_getout){
            DrawScreen();
        }
        else{
            Debug.Log("Getout Fail");
        }
    }


    public void GameStartButtonListener(){
        TestDataStreamer.dataObj.player_data_list = player_data_list;
        SceneManager.LoadScene("InGameScene");
    }
    public void BackButtonListener(){
        SceneManager.LoadScene("StartScene");
    }

    public void RoomSettingButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }

    public void DummyPlusButtonListener(){
        if (player_data_list.Count < 8){
            NewPlayerComeIn();
        }
    }
    public void DummyMinusButtonListener(){
        PlayerGetOut();
    }
    
}
