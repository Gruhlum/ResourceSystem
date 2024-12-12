using HexTecGames.ResourceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Resource Find(this IList<Resource> resources, ResourceType type)
    {
        foreach (var resource in resources)
        {
            if (resource.Type == type)
            {
                return resource;
            }
        }
        return null;
    }
}