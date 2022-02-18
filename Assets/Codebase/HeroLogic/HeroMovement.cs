using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [Space]

    [SerializeField] private AudioSource _jump;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private Animator _animator;

    [SerializeField] private Transform _circlePoint;
    [SerializeField] private float _circleRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private void OnDrawGizmosSelected()
    {
        if (_circlePoint == null) return;

        Gizmos.DrawSphere(_circlePoint.position, _circleRadius);
    }

    private void Update()
    {
        var onGround = Physics2D.OverlapCircle(_circlePoint.position, _circleRadius, _whatIsGround);

        var input = Input.GetAxisRaw("Horizontal");

        _animator.SetBool("Moving", input != 0);
        _animator.SetBool("OnAir", !onGround);

        var velosity = _rigidbody.velocity;

        velosity.x = input * _speed * Time.deltaTime;

        _rigidbody.velocity = velosity;

        Flip(input);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            Jump();

            _jump.Play();
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Flip(float velosity)
    {
        if (velosity == 0) return;

        var scale = _transform.localScale;

        if(velosity > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        _transform.localScale = scale;
    }
}
