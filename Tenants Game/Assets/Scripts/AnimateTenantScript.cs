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

    private void Awake()
    {
        _entryPoint = GameObject.FindGameObjectWithTag("Tenant Entry Point").transform.position;
        _exitPoint = GameObject.FindGameObjectWithTag("Tenant Exit Point").transform.position;
        _stopPoint = GameObject.FindGameObjectWithTag("Tenant Stop Point").transform.position;

        _desiredPos = _stopPoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            EnterScene();
        }

        if (Input.GetKeyDown("x"))
        {
            ExitScene();
        }
        
        if (!_animating)
        {
            return;
        }

        if (Vector3.Distance(transform.position, _desiredPos) <= 0.01)
        {
            _animating = false;
            return;
        }

        transform.position = Vector3.Lerp(transform.position, _desiredPos, 2f * Time.deltaTime);
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
    }
}
