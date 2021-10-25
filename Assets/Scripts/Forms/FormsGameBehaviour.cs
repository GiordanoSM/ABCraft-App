using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormsGameBehaviour : MonoBehaviour
{
    public GameObject form;
    public GameObject mainCamera;
    public static System.Random rnd = new System.Random();

    Vector3 pos;
    GameObject new_form;

    List<int> formIndexes = new List<int> {0, 1, 2, 3, 4, 5, 6, 7};

    float camera_height;
    float camera_width;
    float form_size;
    float separation;
    float margin_x;
    int list_index;
    int n_forms;

    // Start is called before the first frame update
    void Start()
    {
        n_forms = form.GetComponent<FormBehaviour>().forms.Length;

        camera_height = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        camera_width = mainCamera.GetComponent<Camera>().aspect * camera_height;
        form_size = form.GetComponent<SpriteRenderer>().bounds.size.x;
        margin_x = camera_width*2/15;
        separation = camera_width/15;

        // Configuration of original form
        pos = new Vector3(margin_x + form_size/2 - camera_width/2, camera_height/2 - form_size, 0);
        form.GetComponent<Transform>().position = pos;
        list_index = rnd.Next(formIndexes.Count);

        form.GetComponent<FormBehaviour>().ChangeForm(formIndexes[list_index]);
        formIndexes.RemoveAt(list_index);

        // Configuration of the other forms
        for(int i =1; i< n_forms; i++){
            pos.y -= separation + form_size;
            if (i == (int) n_forms/2){
                pos.y = form.GetComponent<Transform>().position.y;
                pos.x += separation + form_size;
            }
            new_form = Instantiate(form, pos, Quaternion.identity);
            list_index = rnd.Next(formIndexes.Count);

            new_form.GetComponent<FormBehaviour>().ChangeForm(formIndexes[list_index]);
            new_form.name = "Form" + i;
            formIndexes.RemoveAt(list_index);
            new_form.AddComponent<PolygonCollider2D>();
        }
        form.AddComponent<PolygonCollider2D>();
    }

    public void setObj(int id_sprite, GameObject obj){
        Vector2[] p_triangle = {new Vector2(), new Vector2(), new Vector2()};
        Vector2[] p_star = {
            new Vector2(), new Vector2(), new Vector2(),
            new Vector2(), new Vector2(), new Vector2(),
            new Vector2(), new Vector2()
        };


        obj.GetComponent<FormBehaviour>().ChangeForm(id_sprite);

        switch (id_sprite%4)
        {
            case 0:
                obj.AddComponent<CircleCollider2D>();
                break;
            case 1:
                //obj.AddComponent<BoxCollider2D>();
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
