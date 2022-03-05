using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed;

    private void Start()
    {
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        TransformPlayer();
    }

    void TransformPlayer()
    {

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;

        plane.Raycast(ray, out distance);

        Vector3 point = ray.GetPoint(distance);

        _rigidbody.AddForce(point * _speed, ForceMode.VelocityChange);
     
    }
}
