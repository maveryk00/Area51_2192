using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    [System.Serializable]
    public class Inventory {

        public List<Item> slots;
        public int currentItemIndex = 0;
        public int maxCapacity = 3;

        public Item currentItem {
            get {
                return slots[currentItemIndex];
            }
        }


        private void HideAll() {
            foreach (Item item in slots) {
                item.SetActive(false);
            }
        }
        
        public Item GetItem(int index) {
            return slots[index];
        }

        public void Next() {
            currentItemIndex++;
            if (currentItemIndex >= slots.Count)
                currentItemIndex = slots.Count - 1;
        }

        public void Prev() {
            currentItemIndex--;
            if (currentItemIndex < 0)
                currentItemIndex = 0;
        }

        public void AddItem(Item item) {
            if (slots.Count < maxCapacity)
                slots.Add(item);
        }

        public void SelectItem(int index) {
            HideAll();

            currentItemIndex = index;
            currentItem.SetActive(true);
        }
    }
}