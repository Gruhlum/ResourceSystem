using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [System.Serializable]
    public class ResourceCostGroup
    {
        [SerializeField] private List<ResourceValue> resourceValues;
        [SerializeField] private int increasePerLevel = default;

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
        

        public void Setup(List<Resource> resource)
        {

        }

        public bool TryIncreaseLevel(List<Resource> resources)
        {
            Resource[] results = new Resource[resourceValues.Count];

            for (int i = 0; i < resourceValues.Count; i++)
            {
                var result = resources.Find(x => x.Type == resourceValues[i].type);
                if (!result.HasResource(resourceValues[i].value))
                {
                    return false;
                }
                results[i] = result;
            }

            for (int i = 0; i < resourceValues.Count; i++)
            {
                results[i].ChangeValue(-resourceValues[i].value);
            }
            IncreaseLevel();
            return true;
        }

        public void IncreaseLevel()
        {
            CurrentLevel++;
            foreach (var cost in resourceValues)
            {
                cost.value += increasePerLevel;
            }
        }
    }
}