using HexTecGames.Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [System.Serializable]
    public class Resource
    {
        public int Value
        {
            get
            {
                return value;
            }
            private set
            {
                if (hasMaximum && value > maximum)
                {
                    value = maximum;
                }
                else if (hasMinimum && value < minimum)
                {
                    value = minimum;
                }
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }
        [SerializeField] private int value;
        public ResourceType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        [SerializeField] private ResourceType type;
        [Space]
        [SerializeField] private bool hasMinimum;
        public int Minimum
        {
            get
            {
                return minimum;
            }
            private set
            {
                minimum = value;
                OnMinimumChanged?.Invoke(minimum);
            }
        }
        [SerializeField, DrawIf(nameof(hasMinimum), true)] private int minimum;

        [SerializeField] private bool hasMaximum;
        public int Maximum
        {
            get
            {
                return maximum;
            }
            private set
            {
                maximum = value;
                OnMaximumChanged?.Invoke(maximum);
            }
        }
        [SerializeField, DrawIf(nameof(hasMaximum), true)] private int maximum;


        public event Action<int> OnValueChanged;
        public event Action<int> OnMinimumChanged;
        public event Action<int> OnMaximumChanged;


        public bool IsAtMinimum()
        {
            if (!hasMinimum)
            {
                return false;
            }
            return Value >= Minimum;
        }
        public bool IsAtMaximum()
        {
            if (!hasMaximum)
            {
                return false;
            }
            return Value >= Maximum;
        }
        public bool HasResource(int amount)
        {
            return Value >= amount;
        }
        public void RemoveMaximum()
        {
            hasMaximum = false;
        }
        public void RemoveMinimum()
        {
            hasMinimum = false;
        }

        public void ChangeValue(int amount)
        {
            Value += amount;
        }

        public void SetMaximum(int val)
        {
            Maximum = val;
            hasMaximum = true;
        }
        public void SetMinimum(int val)
        {
            Minimum = val;
            hasMinimum = true;
        }
    }
}