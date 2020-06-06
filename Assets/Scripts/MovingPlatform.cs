using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private float _speed = 2f;
    private bool _switchMoveDirection = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (_switchMoveDirection == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else if (_switchMoveDirection == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        if (transform.position == _targetB.position)
        {
            _switchMoveDirection = true;
        }
        else if (transform.position == _targetA.position)
        {
            _switchMoveDirection = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
