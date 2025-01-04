using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [System.Serializable]
    public class ResourceCost : ResourceValue
    {
        public int increasePerLevel;

        public Resource Resource
        {
            get
            {
                return resource;
            }
        }
        private Resource resource;

        public bool CanAfford
        {
            get
            {
                return canAfford;
            }
            private set
            {
                if (canAfford == value)
                {
                    return;
                }
                canAfford = value;
                OnCanAffordChanged?.Invoke(canAfford);
            }
        }
        private bool canAfford;

        public event Action<bool> OnCanAffordChanged;


        public void Setup(ResourceController resourceC)
        {
            this.resource = resourceC.GetResource(type);
            resource.OnValueChanged += Resource_OnValueChanged;
        }

        private void Resource_OnValueChanged(int val)
        {
            CanAfford = resource.HasResource(value);
        }

        public void IncreaseLevel()
        {
            resource.ChangeValue(-value);
            value += increasePerLevel;
        }

        public override string ToString()
        {
            return $"{value}";
        }
    }
}