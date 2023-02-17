using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _endRope;

    [SerializeField] private float _powerSwing;
    
    private HingeJoint2D _palyerJoint;
    private Rigidbody2D _palyerBody;

    private void Start()
    {
        _palyerJoint = GetComponent<HingeJoint2D>();
        _palyerBody = GetComponent<Rigidbody2D>();
        
        SwiningPlayer();
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
    }

    private void SwiningPlayer() => _palyerBody.AddForce(transform.right * _powerSwing);
    
    
}
