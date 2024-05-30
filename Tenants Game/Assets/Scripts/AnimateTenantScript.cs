using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimateTenantScript : MonoBehaviour
{
    private Vector3 _entryPoint;
    private Vector3 _exitPoint;
    private Vector3 _stopPoint;

    private Vector3 _desiredPos;
    private bool _animating;

    private bool _exiting;

    private float _bobOffset = 0.0f;
    private float _bobStrength = 0.1f;
    private float _bobSpeed = 10;

    private float _defaultY;

    private float _timer;
    private float _timerMax = 1;

    private void Awake()
    {
        _entryPoint = GameObject.FindGameObjectWithTag("Tenant Entry Point").transform.position;
        _exitPoint = GameObject.FindGameObjectWithTag("Tenant Exit Point").transform.position;
        _stopPoint = GameObject.FindGameObjectWithTag("Tenant Stop Point").transform.position;

        _desiredPos = _stopPoint;

        _defaultY = _entryPoint.y;

        _timer = _timerMax;
    }

    private void Update()
    {
        if (!_animating)
        {
            return;
        }

        if (_desiredPos.x - transform.position.x <= 0.01f)
        {
            _animating = false;

            if (_exiting)
            {
                Destroy(gameObject);
            }
            return;
        }

        Vector3 setPos = new Vector3();
        setPos.x = transform.position.x;

        setPos.x += 5 * Time.deltaTime;

        setPos.y = (Mathf.Sin(_timer * _bobSpeed) * _bobStrength) + _defaultY;

        transform.position = setPos;

        if (_animating)
        {
            _timer -= 1 * Time.deltaTime;
        }
    }

    public void EnterScene()
    {
        transform.position = _entryPoint;
        _animating = true;
        _desiredPos = _stopPoint;
    }

    public void ExitScene()
    {
        _animating = true;
        _desiredPos = _exitPoint;
        _exiting = true;
    }
}
