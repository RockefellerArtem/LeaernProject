using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _endRope;
    
    private HingeJoint2D _palyerJoint;
    private Rigidbody2D _palyerBody;

    private void Start()
    {
        _palyerJoint = GetComponent<HingeJoint2D>();
        _palyerBody = GetComponent<Rigidbody2D>();
        
        //SwiningPlayer();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _palyerJoint.connectedBody = null;
            _palyerJoint.enabled = false;
            _endRope.connectedBody = null;
            _endRope.enabled = false;
        }
        //SwiningPlayer();
        //Debug.Log(_palyerBody.angularVelocity);
    }

    private void SwiningPlayer()
    {
        bool isActive = true;
        while (isActive)
        {
            _palyerBody.angularDrag += 1;
            if(_palyerBody.angularDrag > 5)
            {
                isActive = false;
            }
        }
        
    }
}
