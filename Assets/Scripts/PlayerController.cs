using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;

    private static PlayerController instance;
    private Vector3 destination;
    private Queue<Vector3> points;
    private bool hasDestination;

    public static PlayerController Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
        points = new Queue<Vector3>();
    }

    private void Start()
    {
        LineDrawer.Instance.AddPoint(transform.position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.IsGameOver)
        {
            AddPoint();
        }

        if(hasDestination)
        {
            Move();
        }
        else
        {
            SetDestination();
        }
    }

    private void AddPoint()
    {
        Vector3 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPoint.z = transform.position.z;
        points.Enqueue(newPoint);
        LineDrawer.Instance.AddPoint(newPoint);
    }

    private void SetDestination()
    {
        if (points.Count > 0)
        {
            destination = points.Dequeue();
            hasDestination = true;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if(transform.position == destination)
        {
            hasDestination = false;
        }
    }
}
