using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoArray
{
    public Vector3[] positionArr;
    public int head, tail, chronoDefault, chronoDifference; // indexes
    public int arrLength;

    // saveLength: How many seconds we want to save
    // saveInterval: How many times we are going to save in a second
    // chronoJump: How far back we are going to jump in one Chronobreak
    public ChronoArray(int saveLength, int saveInterval, int chronoJump)
    {
        arrLength = saveLength * saveInterval;
        head = -1;
        tail = arrLength;
        chronoDefault = head - chronoJump;
        chronoDifference = chronoJump;

        positionArr = new Vector3[arrLength];
    }

    // should be called every "saveInterval"
    public void addPosition(Vector3 pos)
    {
        head++;
        chronoDefault++;
        if (head >= arrLength) head = 0;
        if (chronoDefault >= arrLength) chronoDefault = 0;
        if (tail == head)
        {
            tail++;
            if (tail >= arrLength) tail = 0;
        }
        positionArr[head] = pos;
    }

    // call right after chronobreak is finished
    public bool chronoActivate()
    {
        if (chronoDefault >= arrLength || chronoDefault < 0) return false;
        else
        {
            bool loop = false;
            if (head == tail) return false;
            // no loop: if tail isn't between the start and end coordinates then we good
            // loop: if tail IS between the start and end coordinates then we good

            // what happens when we aren't good
            // cD will not care
            // head will move to tail OR stop

            if (chronoDefault > head) loop = true;
            // might need a double check on logic
            // if head doesn't pass over tail, then true
            if ((loop && tail > head && tail < chronoDefault) || (!loop && (tail > head || tail < chronoDefault)))
            {
                head = chronoDefault;
                chronoDefault -= chronoDifference;
                if (chronoDefault < 0) chronoDefault = arrLength + chronoDefault;
            } else
            {
                int temp = head - tail;
                if (temp < 0) temp = arrLength + temp;
                head = tail;
                chronoDefault -= temp;
                if (chronoDefault < 0) chronoDefault = arrLength + chronoDefault;
            }

            return true;
        }
    }

    // returns the location of chronobreak
    public Vector3 chronoRetrieve()
    {
        if (chronoDefault >= arrLength || chronoDefault < 0) return new Vector3(0, 0, 999);
        else return positionArr[chronoDefault];
    }
}
