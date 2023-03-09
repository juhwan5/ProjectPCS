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
    public float player_txt_y_term = -200f;
        

    string[] playersName = new string[8];
    private Transform player_name_position;

    private void Awake() {
        player_name_position = targetCanvas.Find("PlayerNameTxtPosition");
        GetPlayersName();
        DrawScreen();
        
    }

    private void DrawScreen(){
        Vector3 pos_vec = player_name_position.GetComponent<RectTransform>().anchoredPosition3D;
        
        for (int i=0; i < 8; i++){
            TextMeshProUGUI player_txt = Instantiate(p1_txt, targetCanvas);
            player_txt.text = playersName[i];
            player_txt.transform.GetComponent<RectTransform>().anchoredPosition3D = pos_vec + new Vector3(0, player_txt_y_term * i, 0);
        }
    }

    private void GetPlayersName(){
        for (int i=0; i < 8; i++){
            playersName[i] = "* " + (i+1).ToString();
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
