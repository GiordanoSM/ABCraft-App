using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public GameObject token;
    public GameObject mainCamera;
    public static System.Random rnd = new System.Random();
    public string turnedToken = "";
    public int n_turned = 0;
    public int n_tokens;
    public bool matching = false;
    
    Vector3 pos;
    GameObject new_token;
    List<int> faceIndexes = new List<int> {0, 1, 2, 3, 0, 1, 2, 3};

    float camera_height;
    float camera_width;
    float token_size;
    float separation;
    float margin_x;
    int list_index;

    // Start is called before the first frame update
    void Start()
    {
        n_tokens = token.GetComponent<TokenBehaviour>().faces.Length * 2;

        camera_height = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        camera_width = mainCamera.GetComponent<Camera>().aspect * camera_height;

        token_size = token.GetComponent<SpriteRenderer>().bounds.size.x;

        margin_x = camera_width*2/15;
        separation = camera_width/15;

        // Configuration of original token
        pos = new Vector3(margin_x + token_size/2 - camera_width/2, camera_height/2 - token_size, 0);
        token.GetComponent<Transform>().position = pos;
        list_index = rnd.Next(faceIndexes.Count);

        token.GetComponent<TokenBehaviour>().faceIndex = faceIndexes[list_index];
        faceIndexes.RemoveAt(list_index);

        // Configuration of the other tokens
        for(int i =1; i< n_tokens; i++){
            pos.y -= separation + token_size;
            if (i == (int) n_tokens/2){
                pos.y = token.GetComponent<Transform>().position.y;
                pos.x += separation + token_size;
            }
            new_token = Instantiate(token, pos, Quaternion.identity);
            list_index = rnd.Next(faceIndexes.Count);

            new_token.GetComponent<TokenBehaviour>().faceIndex = faceIndexes[list_index];
            new_token.name = "Token" + i;
            faceIndexes.RemoveAt(list_index);
        }
    }

}
