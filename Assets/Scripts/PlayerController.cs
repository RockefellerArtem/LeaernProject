using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _endRope;

    [SerializeField] private float _powerSwing;
    
    private Rigidbody2D _palyerBody;

    private void Start()
    {
        _palyerBody = GetComponent<Rigidbody2D>();
        
        SwiningPlayer();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _endRope.connectedBody = null;
            _endRope.enabled = false;
        }
    }

    private void SwiningPlayer()
    {
        _palyerBody.AddRelativeForce(Vector2.right * _powerSwing, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<HingeJoint2D>(out HingeJoint2D rope))
        {
            rope.connectedBody = _palyerBody;
            rope.enabled = true;
            _endRope = rope;
            transform.position = rope.transform.position;
            _palyerBody.velocity = Vector2.zero;
            _palyerBody.angularVelocity = 0;
        }
    }
}
