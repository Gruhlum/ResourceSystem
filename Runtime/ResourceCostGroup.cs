using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [System.Serializable]
    public class ResourceCostGroup
    {
        [SerializeField] private List<ResourceCost> resourceCosts;

        public int CurrentLevel
        {
            get
            {
                return currentLevel;
            }
            private set
            {
                currentLevel = value;
            }
        }
        private int currentLevel;

        public event Action<bool> OnCanAffordChanged;

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
                OnCanAffordChanged?.Invoke(value);
            }
        }
        private bool canAfford;


        public void Setup(ResourceController resourceC)
        {
            foreach (var resourceCost in resourceCosts)
            {
                resourceCost.Setup(resourceC);
                resourceCost.OnCanAffordChanged += ResourceCost_OnCanAffordChanged;
            }
            CheckIfCanAfford();
        }

        private void CheckIfCanAfford()
        {
            foreach (var cost in resourceCosts)
            {
                if (!cost.CanAfford)
                {
                    CanAfford = false;
                    return;
                }
            }
            CanAfford = true;
        }

        private void ResourceCost_OnCanAffordChanged(bool canAfford)
        {
            if (!canAfford)
            {
                CanAfford = false;
            }
            else CheckIfCanAfford();
        }

        public bool TryIncreaseLevel(List<Resource> resources)
        {
            Resource[] results = new Resource[resourceCosts.Count];

            for (int i = 0; i < resourceCosts.Count; i++)
            {
                var result = resources.Find(resourceCosts[i].type);
                if (!result.HasResource(resourceCosts[i].value))
                {
                    return false;
                }
                results[i] = result;
            }

            for (int i = 0; i < resourceCosts.Count; i++)
            {
                results[i].ChangeValue(-resourceCosts[i].value);
            }
            IncreaseLevel();
            return true;
        }

        public void IncreaseLevel()
        {
            CurrentLevel++;
            foreach (var cost in resourceCosts)
            {
                cost.IncreaseLevel();
            }
        }

        public override string ToString()
        {
            List<string> costStrings = new List<string>();
            foreach (var cost in resourceCosts)
            {
                costStrings.Add(cost.ToString());
            }
            return string.Join(", ", costStrings);
        }
    }
}