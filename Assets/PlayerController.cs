using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _cam;
    private CharacterController _controller;
    private const float Speed = 60f;
    private const float JumpSpeed = 8.0f;
    private const float Gravity = 20.0f;
    private Vector3 _moveDirection = Vector3.zero;

    void Start()
    {
        _cam = Camera.main;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_controller.isGrounded)
        {
            _moveDirection = (_cam.transform.position - _controller.transform.position) * Input.GetAxis("Vertical");
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection = _moveDirection * Speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = JumpSpeed;
            }
        }

        _moveDirection.y = _moveDirection.y - Gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }
}