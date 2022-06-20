using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 0;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer sprite;
    private float dirX = 0f;


    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f) {
            sprite.flipX = true;
            currentWayPointIndex ++;

            if (currentWayPointIndex >= waypoints.Length) {
                currentWayPointIndex = 0;
                sprite.flipX = false;
                print("End points 1");
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
