using System;
using UniRx;
using UnityEngine;

namespace Services
{
    public class InputService : IInputService
    {
        private readonly Subject<Vector3> _moveSubject = new Subject<Vector3>();
        private readonly Subject<Quaternion> _rotateSubject = new Subject<Quaternion>();
        private readonly Subject<float> _scaleSubject = new Subject<float>();

        public IObservable<Vector3> OnMove => _moveSubject;
        public IObservable<Quaternion> OnRotate => _rotateSubject;
        public IObservable<float> OnScale => _scaleSubject;

        private void Update()
        {
            // Пример обработки движения
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (moveInput != Vector3.zero) _moveSubject.OnNext(moveInput);

            // Пример обработки вращения
            Quaternion rotateInput = Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);
            _rotateSubject.OnNext(rotateInput);

            // Пример обработки масштаба
            float scaleInput = Input.GetAxis("Mouse ScrollWheel");
            _scaleSubject.OnNext(scaleInput);
        }
    }
}