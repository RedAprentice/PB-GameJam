using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chronobreak : MonoBehaviour // Might be moved into player later
{

    /// <summary>
    /// Options for Storage
    /// 1. Queue
    /// 2. Single Vector3
    /// 3. Custom Array
    /// </summary>

    // Queue<Vector3> tenSecPos;
    public ChronoArray positionsSaved;
    private float playerZ;
    private float saveTimer;
    private float internalTimer;
    [SerializeField] private int saveLength = 8, saveInterval = 4, chronoJump = 16;

    // Start is called before the first frame update
    void Start()
    {
        positionsSaved = new ChronoArray(saveLength, saveInterval, chronoJump);
        ////might need?
        //for (int i = 0; i < saveLength*saveInterval; i++)
        //{
        //    positionsSaved.addPosition(transform.position);
        //}
        playerZ = transform.position.z;
        saveTimer = 1.0f / saveInterval;
        internalTimer = saveTimer;
    }

    // Update is called once per frame
    void Update()
    {
        // when button press
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggerBreak();
        }

    }

    private void FixedUpdate()
    {
        internalTimer -= Time.deltaTime;
        if (internalTimer <= 0.0f)
        {
            positionsSaved.addPosition(transform.position);
            internalTimer = saveTimer;
        }
    }

    public bool triggerBreak()
    {
        Vector3 chronoPos = positionsSaved.chronoRetrieve();
        Debug.Log("triggerBreak: We got " + chronoPos);
        if (chronoPos != new Vector3(0, 0, 999))
        {
            // valid
            transform.position = chronoPos;
            if (!positionsSaved.chronoActivate())
            {
                Debug.Log("chronoActivate Failed");
            }
        }
        else
        {
            // not valid
        }
        return true;
    }

}
