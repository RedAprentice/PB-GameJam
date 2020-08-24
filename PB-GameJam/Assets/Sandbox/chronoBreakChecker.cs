using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chronoBreakChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gameObject.GetComponentInParent<Chronobreak>().positionsSaved.chronoRetrieve();
    }
}
