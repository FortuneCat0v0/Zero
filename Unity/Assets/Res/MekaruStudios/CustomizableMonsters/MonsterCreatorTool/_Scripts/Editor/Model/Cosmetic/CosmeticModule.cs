using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MekaruStudios.MonsterCreator
{
    [Serializable]
    public class CosmeticModule
    {
        [SerializeField]
        CosmeticSlot[] _slots;

        Cosmetic[] _cosmetics;

        Dictionary<Cosmetic, GameObject> _activeCosmetics = new Dictionary<Cosmetic, GameObject>();

        #region Constructor

        public CosmeticModule(params CosmeticSlot[] slots)
        {
            _slots = slots;
        }
        public CosmeticModule() : this(Array.Empty<CosmeticSlot>()) { }

        #endregion
        public Cosmetic[] GetCosmetics() => _cosmetics;
        public void ClearCosmetics() => _cosmetics = Array.Empty<Cosmetic>();
        public void BindCosmetic(Cosmetic cosmetic)
        {
            var entityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();

            if (IsSameCosmeticExist(cosmetic))
                DestroyCosmetic(cosmetic);
            else
            {
                ClearCosmeticInSameSlot(cosmetic);
                InstantiateCosmetic(cosmetic, entityModel.Get());
            }

            entityModel.NotifyObservers();
        }
        void DestroyCosmetic(Cosmetic cosmetic)
        {
            var activeCosmeticPrefab = _activeCosmetics[cosmetic];
            Object.DestroyImmediate(activeCosmeticPrefab);
            _activeCosmetics.Remove(cosmetic);
        }
        public void Init()
        {
            LoadCosmeticsWithMatchedSlotTypes();
        }

        bool IsSameCosmeticExist(Cosmetic cosmetic)
        {
            return _activeCosmetics.ContainsKey(cosmetic);
        }
        void LoadCosmeticsWithMatchedSlotTypes()
        {
            var cosmeticsStorage = AssetDatabaseExtension.GetAsset<CosmeticStorage>();

            var cosmeticList = new List<Cosmetic>();
            foreach (var cosmetic in cosmeticsStorage.GetCosmetics())
            {
                foreach (var slot in _slots)
                {
                    if (string.Equals(slot.Type, cosmetic.Type))
                    {
                        cosmeticList.Add(cosmetic);
                        break;
                    }
                }
            }

#if UNITY_EDITOR
            Debug.Log($"<color=yellow>{cosmeticList.Count}</color> cosmetics associated with unit");
#endif
            _cosmetics = cosmeticList.ToArray();
        }

        #region Private Methods

        CosmeticSlot FindCorrespondedCosmeticSlot(Cosmetic cosmetic)
        {
            foreach (var slot in _slots)
            {
                if (string.Equals(slot.Type, cosmetic.Type))
                    return slot;
            }

            return new CosmeticSlot
            {
                Type = "null",
                Offset = Vector3.zero,
                ParentBonePath = ""
            };
        }
        void InstantiateCosmetic(Cosmetic cosmetic, GameObject tempGameObject)
        {
            var instantiatedGameObject = (GameObject)PrefabUtility.InstantiatePrefab(cosmetic.Prefab);

            var correspondedCosmeticSlot = FindCorrespondedCosmeticSlot(cosmetic);
            var parentBone = tempGameObject.transform.Find(correspondedCosmeticSlot.ParentBonePath);

            if (parentBone == null)
                throw new InvalidOperationException(
                    "While creating cosmetic, associated parent bone not exist.");


            instantiatedGameObject.transform.localPosition = correspondedCosmeticSlot.Offset;
            instantiatedGameObject.transform.localRotation = Quaternion.Euler(correspondedCosmeticSlot.Rotation);
            instantiatedGameObject.transform.SetParent(parentBone, true);
            
            _activeCosmetics.Add(cosmetic, instantiatedGameObject);
        }
        void ClearCosmeticInSameSlot(Cosmetic newCosmetic)
        {
            var cosmeticsToRemove = (
                from activeCosmetic in _activeCosmetics 
                where activeCosmetic.Key.Type == newCosmetic.Type 
                select activeCosmetic.Key)
                .ToList();

            foreach (var cosmetic in cosmeticsToRemove)
                DestroyCosmetic(cosmetic); 
        }

        #endregion
    }

}
