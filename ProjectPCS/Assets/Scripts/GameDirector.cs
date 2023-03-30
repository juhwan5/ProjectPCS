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


    int player_number = 0;
    GameObject playerObject;
    Dictionary<KeyCode, int> numkey_list = new Dictionary<KeyCode, int>{
        {KeyCode.Keypad1, 1}, {KeyCode.Keypad2, 2},
        {KeyCode.Keypad3, 3}, {KeyCode.Keypad4, 4},
        {KeyCode.Keypad5, 5}, {KeyCode.Keypad6, 6},
        {KeyCode.Keypad7, 7}, {KeyCode.Keypad8, 8}
    };
    
    // Start is called before the first frame update
    void Awake(){
        main_Camera.enabled = true;
    }

    private void Start() {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown){
            

            if(Input.GetKeyDown(KeyCode.Keypad0)){
                main_Camera.enabled = true;
                player_Camera.enabled = false;
            }
            foreach(var dic in numkey_list){
                if(Input.GetKeyDown(dic.Key)){
                    player_number = dic.Value-1;
                    if (player_number >= TestDataStreamer.dataObj.player_data_list.Count){
                        return;
                    }
                    player_Camera.enabled = false;
                    GameObject obj =  TestDataStreamer.dataObj.player_data_list[player_number].playerObj;

                    player_Camera = obj.transform.Find("PlayerCamera").GetComponent<Camera>();
                    main_Camera.enabled = false;
                    player_Camera.enabled = true;
                }
            }
        }
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

}
