using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3Player : MonoBehaviour
{
    [SerializeField] private Character character; 

    private CheckedCells _checkedCells;
    private string username;
    public void SetUsername(string value) { username = value; }

    private void Awake()
    {
        _checkedCells = new CheckedCells();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ApplyMouseClick();
    }

    private void ApplyMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject hitObject = hit.transform.gameObject;
            Tile tile = hitObject.GetComponent<Tile>();
            int id = tile.id;

            if (tile.TrySetCharacter())
            {
                tile.SetCharacter(character);
                _checkedCells.AppendCheckedCells(id);
            }
        }
    }
}
