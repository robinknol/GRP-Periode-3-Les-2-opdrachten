using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class CubeMovement : MonoBehaviour
    {
        public Vector3 endPos;
        public float moveTime;
        private Vector3 _startPos;
        private float _percent;
        private void Start()
        {
            _startPos = transform.position;
            _percent = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(EaseInQuad(10));
            }
        }

        private IEnumerator OldMovement()
        {
            while (_percent < 1)
            {
                _percent += (Time.deltaTime / moveTime);

                transform.position = Vector3.Lerp(_startPos, endPos, _percent);
                
                yield return null;
            }
        }

        private IEnumerator EaseInQuad(int number)
        {
            while (_percent < 1)
            {
                _percent += (Time.deltaTime / number * number);

                transform.position = Vector3.Lerp(_startPos, endPos, _percent);

                yield return null;
            }
        }
    }
}