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
        _inputReader.OnWeakPerformed += HandleWeak;
        _inputReader.OnWeakUpPerformed += HandleWeakUp;
        _inputReader.OnWeakSidePerformed += HandleWeakSide;
        _inputReader.OnWeakDownPerformed += HandleWeakDown;
            ;
    }

    void HandleJump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * (gravity));
        }

    }
    
    void HandleWeak()
    {
        Debug.Log("Weak!");
    }
    
    void HandleWeakUp()
    {
        Debug.Log("Weak Up!");
    }
    void HandleWeakSide()
    {
        Debug.Log("Weak Side!");
    }
    void HandleWeakDown()
    {
        Debug.Log("Weak Down!");
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalVelocity = _inputReader.horizontalMove * speed;
        if (!_characterController.isGrounded)
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }
        
        CheckHeadBump();

        _characterController.Move(new Vector3(_horizontalVelocity, _verticalVelocity, 0f) * Time.deltaTime);
    }

    void CheckHeadBump()
    {
        //TODO: Implement CheckHeadBump
        // RaycastHit hit;
        // Vector3 start = transform.position + new Vector3(0, 0.5f * _characterController.height, 0);
        // Vector3 end = start + Vector3.up * 0.01f;
        // if (Physics.CapsuleCast(start, end, 0.1f, Vector3.up, out hit))
        // {
        //     // Debug.Log("HIT!");
        // }
        //
    }
}
