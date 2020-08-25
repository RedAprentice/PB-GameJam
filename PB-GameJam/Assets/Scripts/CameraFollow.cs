using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        gameObject.transform.position = newPos;
    }
}
