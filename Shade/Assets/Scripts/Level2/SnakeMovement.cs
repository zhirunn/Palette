using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MovingObject
{
    public bool SnakeMode = false;
    [HideInInspector]
    public bool RetractMode = false;
    public GameObject MainBody;
    public Transform handPos;
    public List<Transform> BodyParts = new List<Transform>();

    public float speed = 0.5f;
    public float rotationspeed = 100;
    
    
    private float dis;



    [HideInInspector]
    public Footprints footprints;

    public float maxDistance = 20.0f;
    private float distanceTravelled = 0.0f;
    private Vector3 lastPosition;

    // Use this for initialization
    protected override void Start()
    {
        //BodyParts[size-1] connects to shoulder

        footprints = GetComponent<Footprints>();
        lastPosition = transform.position;

        base.Start();
    }


   
    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Window") && SnakeMode == true)
        {
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Window") 
        {
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

  



    // Update is called once per frame
    void Update()
    {
        if (SnakeMode == true)
        {
            //GetComponent<BoxCollider2D>().enabled = false;

            if (distanceTravelled < maxDistance)
            {
                FreeHand();
            }

            if (transform.position != lastPosition)
                distanceTravelled += Vector3.Distance(transform.position, lastPosition);

            if (Input.GetKeyUp(KeyCode.R))
            {
                SnakeMode = false;
                MainBody.GetComponent<Player>().PlayerMode = true;

            }
        }
        else
        {
            Shrink();

            if (transform.position != lastPosition)
            {
                distanceTravelled -= Vector2.Distance(transform.position, lastPosition);
            }
        }

        if ((transform.position - handPos.position).magnitude < 0.1)
        {
            distanceTravelled = 0.0f; // reset
            //GetComponent<BoxCollider2D>().enabled = true;
        }

        lastPosition = transform.position;
    }

    

    

    public void FreeHand()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime);
        Vector3 vec = transform.up * Input.GetAxis("Vertical") * speed;
        Move(vec.x, vec.y);
    }

    private Transform _targetToTravel = null;
    private float _angularVelocity;

    public void Shrink()
    {
        // TODO: Z, the hand is special and shouldn't be in this list
        Transform hand = BodyParts[0];

        if (footprints.footprints.Count == 0)
        {
            // Reset to default
            hand.position = handPos.position;
            hand.rotation = handPos.rotation;
            RetractMode = false;
        }
        else
        {
            RetractMode = true;

            Transform target = footprints.footprints[footprints.footprints.Count - 1].transform;

            //
            // Calculate the constant angular velocity
            //
            // We do this once and only once at the beginning of the movement since the angular velocity is dependent on the movement
            // If we calculated the angular velocity every frame, the rotation would not be in sync with the movement to the target
            if (_targetToTravel != target)
            {
                _targetToTravel = target;
                float angleToTravel = Quaternion.Angle(hand.rotation, target.rotation);
                float timeToTravel = Vector2.Distance(hand.position, target.position) / speed;
                _angularVelocity = angleToTravel / timeToTravel;
                //Debug.Log(string.Format("{0}: Angle To Travel: {1}, Time To Travel: {2}, Angular Velocity: {3}", 
                //    footprints.footprints.Count-1, 
                //    angleToTravel, 
                //    timeToTravel, 
                //    angularVelocity));
            }

            hand.position = Vector2.MoveTowards(hand.position, target.position, Time.deltaTime * speed);
            hand.rotation = Quaternion.RotateTowards(hand.rotation, target.rotation, Time.deltaTime * _angularVelocity);

            if (transform.position == target.position)
            {
                GameObject footprint = footprints.footprints[footprints.footprints.Count - 1];
                footprints.footprints.Remove(footprint);
                Destroy(footprint);
            }
        }

        // TODO: Z, adjust code so that the other body parts follow along
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            DispositionObject dispositionObj = coll.gameObject.GetComponent<DispositionObject>();
            if(dispositionObj.disposition.isSimilar(MainBody.GetComponent<Player>().disposition) == false)
            {
                StartCoroutine(GameManager.Instance.GameOver());
            }
        }
    }


    /*
    public GameObject bodyprefab; 
        private Transform cur_part;
    Vector2 dir = Vector2.left;
        public float minddistance;
            private Transform prev_part;
    public void Leap(float time)
     {
         foreach (Transform node in BodyParts)
         {
             node.position = Vector2.Lerp(node.position, BodyParts[0].transform.position, time);
             //cur_part.LookAt(prev_part);
             node.rotation = Quaternion.Slerp(node.rotation, BodyParts[0].transform.rotation, time);
         }
     }
     public void AddBodyPart()
     {
         int length = BodyParts.Count - 1;
         Transform newpart = (Instantiate(bodyprefab, BodyParts[length].position, BodyParts[length].rotation) as GameObject).transform;

         // newpart.SetParent(transform);
         newpart.SetParent(MainBody.transform);
         BodyParts.Add(newpart);
         // Create Line Renderer for each node
     }
     public void MoveBodyParts()
    {
        for (int i = 1; i < BodyParts.Count; i++)
        {
            cur_part = BodyParts[i];
            prev_part = BodyParts[i - 1];

            dis = Vector3.Distance(prev_part.position, cur_part.position);
            Vector3 newpos = prev_part.position;
            //newpos.y = BodyParts[0].position.y;
            float T = Time.deltaTime * dis / minddistance * speed;
            if (T > 0.5f)
            {
                T = 0.5f;
            }
            cur_part.position = Vector2.Lerp(cur_part.position, newpos, T);
            //cur_part.LookAt(prev_part);
            cur_part.rotation = Quaternion.Slerp(cur_part.rotation, prev_part.rotation, 0.1f);
        }
    }
     */


}
