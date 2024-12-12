using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    public class TestUnit : MonoBehaviour
    {
        [SerializeField] private List<Resource> resources = default;

        [SerializeField] private ResourceCostGroup upgradeCost = default;


        [ContextMenu("Upgrade")]
        public void Upgrade()
        {
            if (upgradeCost.TryIncreaseLevel(resources))
            {
                Debug.Log("Upgrade");
            }
            else Debug.Log("Failed!");
        }
    }
}