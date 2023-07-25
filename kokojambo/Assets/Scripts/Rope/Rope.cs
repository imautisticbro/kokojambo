
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Scripting;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefabRopeSegments;
    public GameObject player;
    public int Linksnumber = 5;
    public float ropeForceThreshold;
    public ThresholdCalculationMode thresholdCalculationMode;
    private LinkedList<GameObject> _ropeSegments = new();

    //misha kotenochek
    void Start()
    {
        GenerateRope();
    }
    private void FixedUpdate()
    {
        ExtendRope();
        Debug.Log(_ropeSegments.First().GetComponent<HingeJoint2D>().reactionForce.magnitude);
    }
    void GenerateRope()
    {
        Rigidbody2D previousRigidBody = hook;
        for(int i = 0; i < Linksnumber; i++)
        {
            int index = Random.Range(0, prefabRopeSegments.Length);
            GameObject newSegment = Instantiate(prefabRopeSegments[index]);
            newSegment.transform.parent = transform;
            newSegment.transform.position = transform.position;
            HingeJoint2D hj = newSegment.GetComponent<HingeJoint2D>();
            hj.connectedBody = previousRigidBody;

            previousRigidBody=newSegment.GetComponent<Rigidbody2D>();
            _ropeSegments.AddLast(newSegment);
        }
        player.GetComponent<HingeJoint2D>().connectedBody = _ropeSegments.Last().GetComponent<Rigidbody2D>();
        player.transform.position = _ropeSegments.Last().transform.position;
    }
    public void AddSegmentLast()
    {
        Rigidbody2D previousRigidBody = _ropeSegments.Last<GameObject>().GetComponent<Rigidbody2D>();
        int index = Random.Range(0, prefabRopeSegments.Length);
        GameObject newSegment = Instantiate(prefabRopeSegments[index]);
        _ropeSegments.AddLast(newSegment);
        newSegment.transform.parent = transform;
        newSegment.transform.position = transform.position;
        HingeJoint2D hingeJoint2D = newSegment.GetComponent<HingeJoint2D>();
        hingeJoint2D.connectedBody = previousRigidBody;
    }
    public void AddSegmentFirst()
    {
        Rigidbody2D previousRigidBody = _ropeSegments.First<GameObject>().GetComponent<Rigidbody2D>();
        int index = Random.Range(0, prefabRopeSegments.Length);
        GameObject newSegment = Instantiate(prefabRopeSegments[index]);
        _ropeSegments.AddFirst(newSegment);
        newSegment.transform.parent = transform;
        newSegment.transform.position = transform.position;
        HingeJoint2D hingeJoint2D = newSegment.GetComponent<HingeJoint2D>();
        hingeJoint2D.connectedBody = hook;
        previousRigidBody.gameObject.GetComponent<HingeJoint2D>().connectedBody = newSegment.GetComponent<Rigidbody2D>();
        previousRigidBody.gameObject.GetComponent<RopeSegment>().Reconfigure();
    }
    public void ExtendRope()
    {
        switch (thresholdCalculationMode)
        {


            case ThresholdCalculationMode.First:
        if (_ropeSegments.First().GetComponent<HingeJoint2D>().reactionForce.magnitude >= ropeForceThreshold)
        {
            AddSegmentFirst();
            player.GetComponent<HingeJoint2D>().connectedBody = _ropeSegments.Last().GetComponent<Rigidbody2D>();
        }
                break;
            case ThresholdCalculationMode.Last:
                if (_ropeSegments.Last().GetComponent<HingeJoint2D>().reactionForce.magnitude >= ropeForceThreshold)
                {
                    AddSegmentFirst();
                    player.GetComponent<HingeJoint2D>().connectedBody = _ropeSegments.Last().GetComponent<Rigidbody2D>();
                }
                break;
            default:
                if (_ropeSegments.First().GetComponent<HingeJoint2D>().reactionForce.magnitude >= ropeForceThreshold)
                {
                    AddSegmentFirst();
                    player.GetComponent<HingeJoint2D>().connectedBody = _ropeSegments.Last().GetComponent<Rigidbody2D>();
                }
                break;
    }
    }
 
}
   public enum ThresholdCalculationMode {First, Last, Middle, Combined }