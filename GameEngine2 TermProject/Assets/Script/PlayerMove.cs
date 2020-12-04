using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public GameObject deadScene;

    private float _applySpeed;

    [SerializeField] private AudioSource audio;

    [SerializeField] private float lookSensitivity;

    [SerializeField] 
    private float cameraRotationLimit;

    [SerializeField] private float jumpForce;

    private float currentCameraRotationX = 0;

    private Camera _camera;
    
    private Rigidbody _rigid;
    
    // 상태변수
    private bool _isWalk = false;
    private bool _isRun = false;
    private bool _isGround = true;
    private CapsuleCollider _capsuleCollider;
    
    //시작위치
    public Transform startPos;
    // Start is called before the first frame update
    void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _rigid = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
        
        // initialize
        _applySpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();
        TryRun();
        Move();
        CameraRotation();
        CharacterRotation();
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized *_applySpeed;
        
        _rigid.MovePosition(transform.position+ _velocity * Time.deltaTime);
    }
    // 달리기
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
    
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }
    
    private void Running()
    {
        _isRun = true;
        _applySpeed = runSpeed;
    }
    private void RunningCancel()
    {
        _isRun = false;
        _applySpeed = walkSpeed;
    }
    ///////////////////////////////////////////////////////
    /// 점프
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigid.velocity = transform.up * jumpForce;
    }

    private void IsGround()
    {
        _isGround = Physics.Raycast(transform.position, Vector3.down, _capsuleCollider.bounds.extents.y + 0.1f);
    }
    /// 점프
    ///////////////////////////////////////////////////////
    
    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        
        _camera.transform.localEulerAngles = new Vector3(currentCameraRotationX,0f,0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _charcterRotationY = new Vector3(0f, _yRotation, 0f)*lookSensitivity;
        _rigid.MoveRotation(_rigid.rotation*Quaternion.Euler(_charcterRotationY));
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Killable"))
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        audio.Play();
        gameObject.transform.position = startPos.position;
        Debug.Log("Player Die");
        deadScene.SetActive(true);
    }
}
