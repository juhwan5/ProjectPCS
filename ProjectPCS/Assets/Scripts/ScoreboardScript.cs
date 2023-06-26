using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreboardScript : MonoBehaviour
{
    public GameObject player_data_txt_box;

    private void Awake() {
        DrawScoreboard();
    }


    public void DrawScoreboard(){
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(player_data_txt_box, transform);
            obj.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -120 - (i * 50), 0);
            if (i < GameDataObject.dataObj.player_data_list.Count)
            {
                PlayerData pdata = GameDataObject.dataObj.player_data_list[i];
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = pdata.user_name;
                obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = pdata.current_chips.ToString();
                obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = pdata.betting_chips.ToString();
            }
        }
    }
}
