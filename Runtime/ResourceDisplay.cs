using HexTecGames.Basics.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [System.Serializable]
    public class ResourceDisplay : MonoBehaviour
    {
        [SerializeField] private DisplayableDisplay display;
        [SerializeField] private TMP_Text textGUI;
        [SerializeField] private ResourceType resourceType = default;

        private Resource resource;


        public void Setup(List<Resource> resources)
        {
            Setup(resources.Find(resourceType));
        }
        public void Setup(Resource resource)
        {
            this.resource = resource;
            if (resource == null)
            {
                Debug.LogError("No resource provided");
                return;
            }
            UpdateValueText(resource.Value);
            resource.OnValueChanged += Resource_OnValueChanged;
        }

        private void UpdateValueText(int val)
        {
            textGUI.text = val.ToString(resourceType.DisplayFormat);
        }

        private void Resource_OnValueChanged(int val)
        {
            UpdateValueText(val);
        }
    }
}