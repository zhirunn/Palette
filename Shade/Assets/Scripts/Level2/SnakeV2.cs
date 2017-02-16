using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeV2 : MonoBehaviour
{
    public GameObject bodyprefab;
    List<Transform> tail = new List<Transform>();
    Vector2 dir = Vector2.up;
    private Transform cur_part;
    private Transform prev_part;
    private float dis;
    public float minddistance;
    public int size;
    public float speed = 0.5f;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.smoothDeltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector2.down;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector2.left; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    void AddNewNode()
    {

    }
    public void Move()
    {
        for (int i = 1; i < tail.Count; i++)
        {
            cur_part = tail[i];
            prev_part = tail[i - 1];

            dis = Vector3.Distance(prev_part.position, cur_part.position);
            Vector3 newpos = prev_part.position;
            //newpos.y = BodyParts[0].position.y;
            float T = Time.deltaTime * dis / minddistance * speed;
            if (T > 2f)
            {
                T = 2f;
            }
            cur_part.position = Vector2.Lerp(cur_part.position, newpos, T);
            cur_part.rotation = Quaternion.Slerp(cur_part.rotation, prev_part.rotation, T);
        }
    }
}