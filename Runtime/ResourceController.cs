using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private List<Resource> resources = default;
        [SerializeField] private List<ResourceDisplay> resourceDisplays = default;


        private void Start()
        {
            SetupDisplays();
        }

        private void SetupDisplays()
        {
            foreach (var display in resourceDisplays)
            {
                display.Setup(resources);
            }
        }

        public Resource GetResource(ResourceType type)
        {
            return resources.Find(type);
        }

        public void IncreaseResource(ResourceType type, int amount)
        {
            var result = resources.Find(type);
            result.ChangeValue(amount);
            //Debug.Log($"Increase Resource {type} by {amount}");
        }
    }
}