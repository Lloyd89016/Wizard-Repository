using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSegment : MonoBehaviour
{
    //Yes this is 100% my code I stole none of it *Wink*.
    public GameObject connectedAbove, connectedBelow;

    private void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        ropeSegment aboveSegment = connectedAbove.GetComponent<ropeSegment>();
        if(aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
