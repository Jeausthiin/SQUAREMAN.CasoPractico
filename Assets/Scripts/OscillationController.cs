using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationController : MonoBehaviour
{
    [SerializeField]
    bool backAndForth;

    [SerializeField]
    bool reverse;

    [SerializeField]
    bool moveInX;

    [SerializeField]
    bool moveInY;

    [SerializeField]
    bool moveInZ;

    [SerializeField]
    float travelDistance;

    [SerializeField]
    float speed;

    Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (!backAndForth)
        {
            return;
        }

        Vector3 position = transform.position;

        if (moveInX)
        {
            int reverseFactor = reverse ? -1 : 1;
            position.x = _startPosition.x + Mathf.PingPong(Time.time * speed, travelDistance) * reverseFactor;
        }

        if (moveInY)
        {
            int reverseFactor = reverse ? -1 : 1;
            position.y = _startPosition.y + Mathf.PingPong(Time.time * speed, travelDistance) * reverseFactor;
        }

        if (moveInZ)
        {
            int reverseFactor = reverse ? -1 : 1;
            position.z = _startPosition.z + Mathf.PingPong(Time.time * speed, travelDistance) * reverseFactor;
        }

        transform.position = position;
    }
}
