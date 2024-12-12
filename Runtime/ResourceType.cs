using HexTecGames.Basics.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.ResourceSystem
{
    [CreateAssetMenu(menuName = "HexTecGames/PackageTest/ResourceType")]
    public class ResourceType : DisplayableObject
    {
        public override string ToString()
        {
            return Name;
        }
    }
}