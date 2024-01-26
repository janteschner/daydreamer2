using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CharacterController _characterController;
    public float speed = 10.0f;
    
    public float gravity = -9.81f;
    public float jumpHeight = 5;
    private float _verticalVelocity;
    private float _horizontalVelocity;


    // Start is called before the first frame update
    void Start()
    {
        _inputReader.OnJumpPerformed += HandleJump;
    }

    void HandleJump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * (gravity));
        }

    }

    // Update is called once per frame
    void Update()
    {
        _horizontalVelocity = _inputReader.horizontalMove * speed;
        if (!_characterController.isGrounded)
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }

        _characterController.Move(new Vector3(_horizontalVelocity, _verticalVelocity, 0f) * Time.deltaTime);
    }
}
