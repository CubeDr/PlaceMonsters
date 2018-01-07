using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBox : MonoBehaviour {

    public Color defaultColor;
    public Color hightlightColor;

    public bool isHighlighted {
        set {
            if(value) {
                renderer.color = hightlightColor;
            } else {
                renderer.color = defaultColor;
            }
        }
    }

    private GameObject _monster;
    public GameObject monster {
        set {
            if (_monster) Destroy(_monster);
            _monster = value;
            _monster.transform.SetParent(transform, false);
            _monster.transform.Translate(0, 0, 1);
        }
    }

    private new SpriteRenderer renderer;

    private void Awake() {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start () {
        renderer.color = defaultColor;
	}

	
}
