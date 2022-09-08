using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.AssetsResources
{
    public class AssetDictionary : MonoBehaviour
    {
        [SerializeField] private GameObject[] _requiredAssets;
        private Dictionary<string, GameObject> _dictionary;

        private void Awake()
        {
            _dictionary = new Dictionary<string, GameObject>(_requiredAssets.Length);
            foreach (var asset in _requiredAssets)
            {
                _dictionary.Add(asset.name, asset);
            }
        }

        public GameObject GetAsset(string key)
        {
            return _dictionary[key];
        }
    }
}