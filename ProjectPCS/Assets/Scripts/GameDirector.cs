using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject blue_Chip;
    public GameObject black_Chip;
    public GameObject red_Chip;
    public GameObject green_Chip;

    public Camera main_Camera;
    public Camera player_Camera;

    float player_Distance = 7.5f;

    int player_number = 0;
    GameObject playerObject;
    Dictionary<KeyCode, int> numkey_list = new Dictionary<KeyCode, int>{
        {KeyCode.Keypad1, 1}, {KeyCode.Keypad2, 2},
        {KeyCode.Keypad3, 3}, {KeyCode.Keypad4, 4},
        {KeyCode.Keypad5, 5}, {KeyCode.Keypad6, 6},
        {KeyCode.Keypad7, 7}, {KeyCode.Keypad8, 8}
    };
    
    // Start is called before the first frame update
    void Start()
    {
       playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown){
            if(Input.GetKeyDown(KeyCode.Q)){
                ChipDrop(blue_Chip);
            }
            if(Input.GetKeyDown(KeyCode.W)){
                ChipDrop(black_Chip);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                ChipDrop(red_Chip);
            }
            if(Input.GetKeyDown(KeyCode.R)){
                ChipDrop(green_Chip);
            }

            if(Input.GetKeyDown(KeyCode.Keypad0)){
                player_number = 0;
                main_Camera.enabled = true;
                player_Camera.enabled = false;
            }
            foreach(var dic in numkey_list){
                if(Input.GetKeyDown(dic.Key)){
                    player_number = dic.Value;
                    SetPlayerPosition(dic.Value);
                    main_Camera.enabled = false;
                    player_Camera.enabled = true;
                }
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                ChipsDelete();
            }
        }
    }

    void SetPlayerPosition(int posnum){
        
        float turnAngle = (posnum-1) * -45f;
        playerObject.transform.position = new Vector3(0, 3.2f, 0);
        playerObject.transform.localEulerAngles = new Vector3(0,0,0);
        playerObject.transform.Rotate(new Vector3(0, turnAngle, 0));
        playerObject.transform.Translate(new Vector3(0,0,-player_Distance));
    }

    void ChipDrop(GameObject color_Chip)
    {
        float chip_drop_range = 0.3f;
        Transform chip_drop_area = playerObject.transform.Find("ChipArea");
        GameObject chip = Instantiate(color_Chip) as GameObject;
        chip.GetComponent<Chips>().id_number = player_number;

        float x = Random.Range(-chip_drop_range, chip_drop_range);
        float z = Random.Range(-chip_drop_range, chip_drop_range);
        chip.transform.position = chip_drop_area.position + new Vector3(x, 1f, z);
    }

    void ChipsDelete(){
        
    }
}
