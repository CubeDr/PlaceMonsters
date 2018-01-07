using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour {
    public Canvas canvas;
    public Image monsterIconHolderPrefab;
    public GameObject monsterHolderPrefab;

    public Vector3 mousePosition {
        get {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            return pos;
        }
    }

    private bool _isDragging = false;
    public bool isDragging { get { return _isDragging; } }
    private Image monsterIcon;
    private Sprite monsterSprite;

    private MonsterBox highlightedMonsterBox;

    public void SetMonsterDrag(Sprite monsterIcon, Sprite monster) {
        _isDragging = true;

        this.monsterIcon = Instantiate(monsterIconHolderPrefab, Input.mousePosition, Quaternion.identity, canvas.transform);
        this.monsterIcon.GetComponent<Image>().sprite = monsterIcon;
        monsterSprite = monster;
    }

	void Update () {
		if(isDragging) {
            monsterIcon.transform.position = Input.mousePosition;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit) {
                highlightedMonsterBox = hit.collider.GetComponent<MonsterBox>();
                highlightedMonsterBox.isHighlighted = true;
            } else if(highlightedMonsterBox) {
                highlightedMonsterBox.isHighlighted = false;
                highlightedMonsterBox = null;
            }

            if (Input.GetMouseButtonUp(0)) {
                if(highlightedMonsterBox) {
                    GameObject monster = Instantiate(monsterHolderPrefab);
                    monster.GetComponent<SpriteRenderer>().sprite = monsterSprite;
                    highlightedMonsterBox.monster = monster;

                    highlightedMonsterBox.isHighlighted = false;
                    highlightedMonsterBox = null;
                }

                Destroy(monsterIcon);
                monsterIcon = null;
                monsterSprite = null;
                _isDragging = false;
            }
        }
	}
}
