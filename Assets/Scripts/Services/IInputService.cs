using System;
using UnityEngine;

namespace Services
{
    public interface IInputService
    {
        IObservable<Vector3> OnMove { get; }
        IObservable<Quaternion> OnRotate { get; }
        IObservable<float> OnScale { get; }
    }
}

