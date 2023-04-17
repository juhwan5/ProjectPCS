using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI now_chips_txt;
    public TMP_InputField betting_chips_txt;
    public Slider chips_slider;
    public GameObject scoreboard_ui;

    private int now_chips;
    private int betting_chips;
    private bool is_scoreboard_open;

    private void Awake() {
        now_chips = GameDataObject.dataObj.playerData.reserved_chips;
        betting_chips = 0;
        is_scoreboard_open = true;
        ScoreboardButtonListener();
    }

    void Start()
    {
        chips_slider.onValueChanged.AddListener(delegate {SliderValueChanged();});
        betting_chips_txt.onEndEdit.AddListener(delegate {InputFieldValueChanged();});
        chips_slider.value = betting_chips;
        DrawUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InputFieldValueChanged(){
        if (betting_chips_txt.text == ""){
            betting_chips_txt.text = "0";
        }
        betting_chips = int.Parse(betting_chips_txt.text);
        chips_slider.value =  (float)betting_chips / (float)now_chips;
        DrawUI();
    }

    void SliderValueChanged(){
        betting_chips =  (int)(chips_slider.value * (float)now_chips);
        DrawUI();
    }


    void DrawUI(){
        betting_chips_txt.text = betting_chips.ToString();
        now_chips_txt.text = (now_chips - betting_chips).ToString();
        
    }


    public void ScoreboardButtonListener(){
        if (is_scoreboard_open){
            scoreboard_ui.SetActive(false);
            is_scoreboard_open = false;
        }else{
            scoreboard_ui.SetActive(true);
            is_scoreboard_open = true;
        }
    }


    public void BettingButtonListener(){
    }

}
