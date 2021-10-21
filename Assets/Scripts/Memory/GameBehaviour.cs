using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public GameObject token;
    GameObject new_token;
    public GameObject mainCamera;
    public int n_tokens = 8;
    Vector3 pos;
    //Vector3 init_pos;
    float camera_height;
    float camera_width;
    float token_size;
    float separation;
    float margin_x;

    // Start is called before the first frame update
    void Start()
    {
        camera_height = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        camera_width = mainCamera.GetComponent<Camera>().aspect * camera_height;

        token_size = token.GetComponent<SpriteRenderer>().bounds.size.x;

        margin_x = camera_width*2/15;
        separation = camera_width/15;

        pos = new Vector3(margin_x + token_size/2 - camera_width/2, camera_height/2 - token_size, 0);
        token.GetComponent<Transform>().position = pos;

        //init_pos = mainCamera.GetComponent<Camera>().WorldToScreenPoint(world_pos);
        //pos = init_pos;

        for(int i =1; i< n_tokens; i++){
            pos.y -= separation + token_size;
            if (i == (int) n_tokens/2){
                pos.y = token.GetComponent<Transform>().position.y;
                pos.x += separation + token_size;
            }
            //world_pos = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(pos);
            new_token = Instantiate(token, pos, Quaternion.identity);

        }
    }

}
