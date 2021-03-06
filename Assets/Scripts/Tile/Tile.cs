using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private T3Controller controller;
    [SerializeField] private Character character;
    [SerializeField] private Sprite image;

    public int Row { get; private set; }
    public int Column { get; private set; }

    private int _id;
    private bool _isCovered = false;
    public int id
    {
        get { return _id; }
    }

    public static Tile GetTileById(int id)
    {
        Tile[] tilesArray = (Tile[])Resources.FindObjectsOfTypeAll(typeof(Tile));
        List<Tile> tilesList = new List<Tile>();
        tilesList.AddRange(tilesArray);
        return tilesList.Find(item => item.id.Equals(id));
    }

    public void SetTile(int id, Sprite image, Vector2 position)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
        Row = (int)position.x;
        Column = (int)position.y;
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
