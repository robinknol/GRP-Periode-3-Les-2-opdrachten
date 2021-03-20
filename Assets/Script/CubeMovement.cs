using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class CubeMovement : MonoBehaviour
    {
        public Vector3 endPos;
        public Vector3 endScale;
        
        private Vector3 _startPos;
        private Vector3 _startScale;
        
        public float moveTime;
        private float _percent;
        private float _easeStep;

        public bool move;
        public bool grow;
        public bool easeInQuad;
        public bool easeOutQuad;
        public bool easeOutQuart;

        private void Start()
        {
            
            _startScale = transform.localScale;
            _startPos = transform.position;
            _percent = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(EaseIn());
            }
        }

        private IEnumerator linear()
        {
            while (_percent < 1)
            {
                _percent += (Time.deltaTime / moveTime);

                transform.position = Vector3.Lerp(_startPos, endPos, _percent);
                
                yield return null;
            }
        }

        private IEnumerator EaseIn()
        {
            while (_percent < 1)
            {
                print("Percent: " + _percent);
                print("Time.deltaTime " + Time.deltaTime);
                print(_percent + " += " + Time.deltaTime + " / " + moveTime);
                print("");
                _percent += Time.deltaTime / moveTime;

                if (easeInQuad)
                {
                    _easeStep = _percent * _percent;
                }
                else if (easeOutQuad)
                {
                    float sum = 1 - _percent;
                    _easeStep = 1 - sum * sum;
                }
                else if (easeOutQuart)
                {
                    float pow = Mathf.Pow(1 - _percent, 4);
                    _easeStep = 1 - pow;
                }
                
                if (move)
                {
                    Vector3 distance = endPos - _startPos;
                    Vector3 travelDistance = distance * _easeStep;
                    Vector3 newPos = _startPos + travelDistance;
                    transform.position = newPos;
                }

                if (grow)
                {
                    Vector3 scale = endScale - _startScale;
                    Vector3 scaleIncrease = scale * _easeStep;
                    Vector3 newScale = _startScale + scaleIncrease;
                    transform.localScale = newScale;
                }

                yield return null;
            }
        }
    }
}