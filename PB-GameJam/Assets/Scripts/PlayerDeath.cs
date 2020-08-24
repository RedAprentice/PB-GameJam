using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killPlayer()
    {
        if (gameObject.GetComponent<Chronobreak>().positionsSaved.tail == gameObject.GetComponent<Chronobreak>().positionsSaved.head)
        {
            // trigger some kind of game over
        }
        else
        {
            gameObject.GetComponent<Chronobreak>().triggerBreak();
        }
    }

}
