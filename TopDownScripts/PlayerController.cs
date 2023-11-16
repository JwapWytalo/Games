using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody2D;
    public float _playerSpeed;
    private Vector2 _playerDirection;
    private Animator _playerAnimator;
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Ativando atransição das animações
        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }
        Flip();
    }

    void FixedUpdate()
    {
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerDirection
             * _playerSpeed * Time.fixedDeltaTime);    
    }
    //virando o player para o outro lado
    void Flip()
    {
        if(_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }else if (_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}
