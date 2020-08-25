using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject spawn;

    public void killPlayer()
    {
        if (gameObject.GetComponent<Chronobreak>().positionsSaved.tail == gameObject.GetComponent<Chronobreak>().positionsSaved.head)
        {
            // reset player player position to spawn
            gameObject.transform.position = spawn.transform.position;
        }
        else
        {
            gameObject.GetComponent<Chronobreak>().triggerBreak();
        }
    }

}
