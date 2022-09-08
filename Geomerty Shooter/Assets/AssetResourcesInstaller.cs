using System.Collections;
using System.Collections.Generic;
using Code.Scripts.AssetsResources;
using UnityEngine;
using Zenject;

public class AssetResourcesInstaller : MonoInstaller
{
    [SerializeField] private AssetDictionary _assetDictionary;

    public override void InstallBindings()
    {
        Container.Bind<AssetDictionary>().FromInstance(_assetDictionary).AsSingle();
    }
}