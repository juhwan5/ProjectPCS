using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMaster : MonoBehaviour
{

    public GameObject player_prefab;

    private void Awake() {
        GameDataObject.dataObj.total_betting = 0;
        SetPlayerPosition(GameDataObject.dataObj.player_data_list.Count);
    }


    private void Start() {
    }


    void SetPlayerPosition(int num_of_players){
        int idx = 0;
        float position_jump = 8 / (float)num_of_players;

        for (float stk = 0; stk < 8; stk += position_jump){
            //플레이어 객체 세팅
            int pos_of_player = (int)stk;
            GameObject playerObj = Instantiate(player_prefab);
            float turnAngle = pos_of_player * -45f;
            playerObj.transform.position = new Vector3(0, 3.2f, 0);
            playerObj.transform.localEulerAngles = new Vector3(0,0,0);
            playerObj.transform.Rotate(new Vector3(0, turnAngle, 0));
            playerObj.transform.Translate(new Vector3(0,0, -7.5f));
            playerObj.GetComponent<PlayerPrefabScript>().user_ID = GameDataObject.dataObj.player_data_list[idx++].user_ID;

            
        }
    }
}
