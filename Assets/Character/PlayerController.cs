using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CharacterController _characterController;
    public float speed = 10.0f;
    
    public float gravity = -9.81f;
    public float jumpHeight = 5;
    public float horizontalFrictionTime = 0.06f;
    public float rotationSmoothingTime = 0.05f;
    private float _verticalVelocity;
    private float _horizontalVelocity;
    private float _horizontalVelocitySmoothing;

    private float _yRotation = 0f;
    private float _yTargetRotation = 0f;
    private float _yRotationSmoothing;


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
        OnomatopoeiaSpawner.Instance.InstantiateAt(this.transform.position);
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
        float targetHorizontalVelocity = _inputReader.horizontalMove * speed;
        if (_characterController.isGrounded || Mathf.Abs(targetHorizontalVelocity) > 0.05f)
        {
            _horizontalVelocity = Mathf.SmoothDamp(_horizontalVelocity, targetHorizontalVelocity, ref _horizontalVelocitySmoothing, horizontalFrictionTime);
        }
        if (!_characterController.isGrounded)
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }

        if (Mathf.Abs(targetHorizontalVelocity) > 0.02f)
        {
            _yTargetRotation = targetHorizontalVelocity > 0 ? 0 : 180;
        }
        _yRotation = Mathf.SmoothDamp(_yRotation, _yTargetRotation,
            ref _yRotationSmoothing, rotationSmoothingTime);
        this.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
        
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
