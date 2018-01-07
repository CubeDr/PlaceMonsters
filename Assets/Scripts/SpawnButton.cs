using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler {
    public Engine engine;

    public Sprite monsterIcon;
    public Sprite monster;

    public void OnPointerDown(PointerEventData data) {
        engine.SetMonsterDrag(monsterIcon, monster);
    }
}
