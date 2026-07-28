using System;
using System.Collections.Generic;
using UnityEngine;


namespace SaveLoadSystem
{
    public class CassetteHolder
    {
        [field: SerializeField] public SaveCassette SaveCassette { get; private set; }

        public List<CassetteItem> LoadedItems;
        public List<CassetteItem> LoadedHandItems;

        public event Action OnUpdateItems;
        public event Action OnSave;

        public void AddCassette(List<CassetteObject> cassetteObject, List<CassetteObject> handCassette)
        {
            GetCassetteItems(cassetteObject, out List<CassetteItem> items);
            GetCassetteItems(handCassette, out List<CassetteItem> handItems);
            SaveCassette = new SaveCassette(items.ToArray(), handItems.ToArray());
        }

        public void SetUpdate(List<CassetteObject> cassetteObject)
        {
            CassetteObject tempCassette;
            CassetteItem tempCassetteItem;

            for (int i = 0; i < cassetteObject.Count; i++)
            {

                tempCassette = cassetteObject[i];
                tempCassetteItem = LoadedItems[i];

                if (tempCassette.Id != tempCassetteItem.Id)
                {
                    Debug.LogError($"Not found Id, tempCassette.Id:{tempCassette.Id},tempCassetteItem.Id:{tempCassetteItem.Id} ");
                }
                tempCassette.transform.position = ChangeVector(tempCassetteItem.Position);
                tempCassette.transform.rotation = ChangeQuaternion(tempCassetteItem.Rotation);
                tempCassette.Rigidbody.isKinematic = tempCassetteItem.IsKinematic;
                tempCassette.Rigidbody.useGravity = tempCassetteItem.UseGravity;
                tempCassette.Collider.enabled = tempCassetteItem.IsCollider;
                tempCassette.transform.parent = null;
            }
        }

        public void SetHandUpdate(Dictionary<int, CassetteObject> _cassetsDictionary)
        {
            CassetteObject tempCassette;
            for (int i = 0; i < LoadedHandItems.Count; i++)
            {
                if (_cassetsDictionary.TryGetValue(LoadedHandItems[i].Id, out tempCassette))
                {
                    tempCassette.Rigidbody.isKinematic = false;
                    tempCassette.Collider.enabled = true;
                    tempCassette.Rigidbody.useGravity = true;
                }
            }
        }

        public void UpdateItems()
        {
            LoadedItems = SaveCassette.Items;
            LoadedHandItems = SaveCassette.HandItems;
            OnUpdateItems?.Invoke();
        }

        public void Save()
        {
            OnSave?.Invoke();
        }

        private void GetCassetteItems(List<CassetteObject> cassetteObjects, out List<CassetteItem> cassetteItems)
        {
            CassetteObject tempCassette = null;
            List<CassetteItem> items = new List<CassetteItem>();
            for (int i = 0; i < cassetteObjects.Count; i++)
            {
                tempCassette = cassetteObjects[i];
                if (tempCassette == null) { break; }
                items.Add(new CassetteItem()
                {
                    Id = tempCassette.Id,
                    Position = ChangeVector(tempCassette.transform.position),
                    Rotation = ChangeQuaternion(tempCassette.transform.rotation),
                    IsKinematic = tempCassette.Rigidbody.isKinematic,
                    UseGravity = tempCassette.Rigidbody.useGravity,
                    IsCollider = tempCassette.Collider,
                });
            }
            cassetteItems = items;
        }

        private SavePosition ChangeVector(Vector3 vector3)
        {
            SavePosition savePosition = new SavePosition()
            {
                X = vector3.x,
                Y = vector3.y,
                Z = vector3.z,
            };
            return savePosition;
        }

        private Vector3 ChangeVector(SavePosition vector3)
        {
            Vector3 position = new Vector3()
            {
                x = vector3.X,
                y = vector3.Y,
                z = vector3.Z,
            };
            return position;
        }

        private SaveQuaternion ChangeQuaternion(Quaternion quaternion)
        {
            SaveQuaternion savePosition = new SaveQuaternion()
            {
                X = quaternion.x,
                Y = quaternion.y,
                Z = quaternion.z,
                W = quaternion.w
            };
            return savePosition;
        }

        private Quaternion ChangeQuaternion(SaveQuaternion quaternion)
        {
            Quaternion rotation = new Quaternion()
            {
                x = quaternion.X,
                y = quaternion.Y,
                z = quaternion.Z,
                w = quaternion.W
            };
            return rotation;
        }
    }
}