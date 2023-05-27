using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameObject[] _doorsGameObjects;
    private List<Door> _doors;
    private void Awake()
    {
        _doorsGameObjects = GameObject.FindGameObjectsWithTag("Door");
        _doors = new List<Door>(_doorsGameObjects.Length);
        foreach (GameObject door in _doorsGameObjects)
            _doors.Add(door.AddComponent<Door>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _doors.ForEach(x=> x.SwitchState());
    }
}

public class Door : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(Random.Range(0,2) == 0);
    }

    public void SwitchState()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}

