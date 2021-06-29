using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private T3Controller controller;
    [SerializeField] private Character character;
    [SerializeField] private Sprite image;
    private int _id;
    private bool _isCovered = false;
    public int id
    {
        get { return _id; }
    }

    public void SetTile(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }


    public void SetCharacter(Character value)
    {
        if (value == null)
            throw new NullReferenceException("Character can not be null");

        character = value;

        StartCoroutine(ApplyCharacter(character.Image));
    }

    public bool TrySetCharacter()
    {
        return !_isCovered;
    }
    private IEnumerator ApplyCharacter(Sprite image)
    {
        _isCovered = true;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = image;
        yield return this;
    }

}
