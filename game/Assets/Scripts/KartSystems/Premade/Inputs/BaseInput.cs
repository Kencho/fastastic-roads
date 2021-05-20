﻿using UnityEngine;

namespace KartGame.KartSystems
{

    public interface IInput
    {
        Vector2 GenerateInput();

        bool Blocked { get; set; }
    }

    public abstract class BaseInput : MonoBehaviour, IInput
    {
        public bool Blocked { get; set; }

        public Vector2 GenerateInput()
        {
            if (Blocked) return Vector2.zero;
            return GenerateRawInput();
        }

        protected abstract Vector2 GenerateRawInput();
    }
}
