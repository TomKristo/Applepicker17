using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    //Initiating apples
    public GameObject applePrefab;

    //Speed AppleTree moves (meters/second)
    public float speed = 1f;

    //Distance where AppleTree changes direction
    public float leftAndRightEdge = 10f;

    //Chance AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Apple spawn rate
    public float secondsBetweenAppleDrops = 1f;

    // Use this for initialization
    void Start()
    {
        //Dropping Apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
    }

    void FixedUpdate()
    {
        //Changing Directions Randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //Change directions
        }
    }
}