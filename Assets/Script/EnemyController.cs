using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string type;
    
    [SerializeField] private new string name;
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    [HideInInspector]
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;


    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }
    
    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].position;
       
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;

        transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
         
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;

                //transform.LookAt(waypoints[currentWaypoint + 1]);
                RotateIntoMoveDirection();  
            }
            else
            {
                Destroy(gameObject);

                //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                //// TODO: вычитать здоровье
            }
        }

    }
    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = waypoints[currentWaypoint].position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].position;
        Vector3 newDirection = (newEndPosition - newStartPosition);

        Quaternion rotation = Quaternion.LookRotation(newDirection);
        transform.rotation = rotation;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Endpoint"))
    //    {
    //        Destroy(gameObject);
    //        //HP
    //    }
    //}
}
