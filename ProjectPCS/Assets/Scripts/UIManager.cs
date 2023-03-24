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

    private int now_chips;
    private int betting_chips;

    private void Awake() {
        now_chips = GameDataObject.dataObj.chips;
        betting_chips = 0;
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

}
