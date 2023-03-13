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


    string[] playersName = {"", "", "", "", "", "", "", ""};
    private int dummy_number = 1;
    private Vector3 player_name_position;
    
    private void Awake() {
        GameDataObject.dataObj.before_scene = SceneManager.GetActiveScene().name;
        player_name_position = targetCanvas.Find("PlayerNameTxtPosition").GetComponent<RectTransform>().anchoredPosition3D;
        GetPlayersName();
        DrawScreen();
        
    }

    private void DrawScreen(){
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("PlayerNameTxt");
        foreach  (GameObject prefab in prefabs){
            Destroy(prefab);
        }
        
        //Draw RoomId, Chips
        room_ID_txt.text = "RoomID : " + GameDataObject.dataObj.roomID.ToString();
        chips_txt.text = "Chips : " + GameDataObject.dataObj.chips.ToString();


        //Draw Player Name
        for (int i=0; i < 8; i++){
            TextMeshProUGUI player_txt = Instantiate(p1_txt, targetCanvas);
            player_txt.text = "*  " + playersName[i];
            player_txt.transform.GetComponent<RectTransform>().anchoredPosition3D = player_name_position + new Vector3(0, player_txt_y_term * i, 0);
        }
    }

    private void GetPlayersName(){
        // for (int i=0; i < 8; i++){
        //     playersName[i] = (i+1).ToString();
        // }
        try
        {
            playersName[0] = GameDataObject.dataObj.player_name;
        }
        catch (System.NullReferenceException ex)
        {
            Debug.Log(ex);
            playersName[0] = "NullPlayerCome";
        }
        
    }

    private void NewPlayerComeIn(){
        for (int i=0; i < 8; i++){
            if (playersName[i] == ""){
                playersName[i] = "DummYPlayer " + dummy_number.ToString();
                dummy_number++;
                break;
            }
        }
        DrawScreen();
    }

    private void PlayerGetOut(){
        for (int i=0; i < 8; i++){
            string[] target_name = playersName[i].Split();
            if (target_name[0] == "DummYPlayer"){
                playersName[i] = "";
                break;
            }
        }
        DrawScreen();
    }


    public void GameStartButtonListener(){
        SceneManager.LoadScene("InGameScene");
    }
    public void BackButtonListener(){
        SceneManager.LoadScene("StartScene");
    }

    public void RoomSettingButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }

    public void DummyPlusButtonListener(){
        NewPlayerComeIn();
    }
    public void DummyMinusButtonListener(){
        PlayerGetOut();
    }
    
}
