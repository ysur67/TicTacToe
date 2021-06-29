using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string value;
    [SerializeField] private Sprite image;

    public string Value => value;

    public Sprite Image => image;
}
