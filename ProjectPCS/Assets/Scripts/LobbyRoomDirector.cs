using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyRoomDirector : MonoBehaviour
{
    public Transform TargetCanvas;
    public TextMeshProUGUI p1_txt;

    string[] playersName = new string[8];

    private void Awake() {
        GetPlayersName();
        DrawScreen();
        
    }

    private void DrawScreen(){
        float x = 370f;
        float y = -480f;
        float y_term = -200f;
        
        for (int i=0; i < 8; i++){
            TextMeshProUGUI player_txt = Instantiate(p1_txt, TargetCanvas);
            player_txt.text = playersName[i];
            player_txt.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x, y + (y_term * i), 0);
        }
    }

    private void GetPlayersName(){
        for (int i=0; i < 8; i++){
            playersName[i] = "* " + (i+1).ToString();
            Debug.Log(playersName[i]);
        }
    }
}
