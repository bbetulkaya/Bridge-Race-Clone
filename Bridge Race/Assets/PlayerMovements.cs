using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] public float playerSpeed;
    private Vector3 _target;
    private Vector3 _lookAtTarget;
    private Quaternion _playerRot;
    private bool _isMoving;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
    }

    // PC MOVEMENTS CONTROL
    private void Movement()
    {
        SetTargetPosition();
        Move();
    }
    private void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            _target = hit.point;
            _target.y = this.transform.position.y;
            _lookAtTarget = new Vector3(_target.x - this.transform.position.x, transform.position.y, _target.z - this.transform.position.z);
            Debug.Log(_lookAtTarget);
            _playerRot = Quaternion.LookRotation(_lookAtTarget);

        }
    }
    private void Move()
    {  
        transform.rotation = Quaternion.Slerp(this.transform.rotation, _playerRot, playerSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(this.transform.position, _target, playerSpeed * Time.deltaTime);
    }

    // MOBILE MOVEMENTS CONTROL

    
}
