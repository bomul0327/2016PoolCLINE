using UnityEngine;
using System.Collections;

public class MemoryPool: IEnumerable, System.IDisposable {

    class Item {
        public bool active;
        public GameObject gameObject;
    }
    Item[] table;

    public IEnumerator GetEnumerator () {
        if (table == null) yield break;

        int count = table.Length;

        for(int i = 0; i < count; i++) {
            Item item = table[i];
            if (item.active)
                yield return item.gameObject;
        }
    }
    public void Create(Object original, int count) {
        Dispose();
        table = new Item[count];

        for(int i = 0; i < count; i++) {
            Item item = new Item();
            item.active = false;
            item.gameObject.SetActive(false);
            table[i] = item;
        }
    }

    public GameObject NewItem () {
        if(table == null) {
            return null;
        }
        int count = table.Length;
        for(int i = 0; i < count; i++) {
            Item item = table[i];
            if(item.active == false) {
                item.active = true;
                item.gameObject.SetActive(true);
                return item.gameObject;
            }
        }
        return null;
    }

    public void RemoveItem(GameObject gameObject) {
        if(table == null || gameObject == null) {
            return;
        }
        int count = table.Length;

        for(int i = 0; i < count; i++) {
            Item item = table[i];
            if(item.gameObject == gameObject) {
                item.active = false;
                item.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void ClearItem () {
        if(table == null) {
            return;
        }
        int count = table.Length;
        for(int i = 0; i < count; i++) {
            Item item = table[i];
            if(item != null && item.active) {
                item.active = false;
                item.gameObject.SetActive(false);
            }
        }
    }

    public void Dispose () {
        if(table == null) {
            return;
        }
        int count = table.Length;

        for(int i = 0; i < count; i++) {
            Item item = table[i];
            GameObject.Destroy(item.gameObject);
        }
        table = null;
    }
}