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


    string[] playersName = new string[8];
    private Transform player_name_position;

    private void Awake() {
        GameDataObject.dataObj.before_scene = SceneManager.GetActiveScene().name;
        player_name_position = targetCanvas.Find("PlayerNameTxtPosition");
        GetPlayersName();
        DrawScreen();
        
    }

    private void DrawScreen(){
        //Draw RoomId, Chips
        room_ID_txt.text = "RoomID : " +GameDataObject.dataObj.roomID.ToString();
        chips_txt.text = "Chips : " +GameDataObject.dataObj.chips.ToString();


        //Draw Player Name
        Vector3 pos_vec = player_name_position.GetComponent<RectTransform>().anchoredPosition3D;
        for (int i=0; i < 8; i++){
            TextMeshProUGUI player_txt = Instantiate(p1_txt, targetCanvas);
            player_txt.text = "*  " + playersName[i];
            player_txt.transform.GetComponent<RectTransform>().anchoredPosition3D = pos_vec + new Vector3(0, player_txt_y_term * i, 0);
        }
    }

    private void GetPlayersName(){
        for (int i=0; i < 8; i++){
            playersName[i] = (i+1).ToString();
        }
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

    public void GameStartButtonListener(){
        SceneManager.LoadScene("InGameScene");
    }
    public void BackButtonListener(){
        SceneManager.LoadScene("StartScene");
    }

    public void RoomSettingButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }
}
