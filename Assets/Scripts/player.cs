using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 bounds;
    [SerializeField] private float speed;
    public soEvent startFireEvent;
    public soEvent stopFireEvent;
    public GameObject menu;
    public soEventWithPrefabArgs switchWeaponEvent;

    private void Start()
    {
        switchWeaponEvent.events.Add((GameObject new_weapon) => { Instantiate(new_weapon, playerTransform); });
    }

    public void Aim(Vector2 position)
    {
        pointer.position += playerTransform.right * position.x + playerTransform.up * position.y;
        pointer.position = new Vector3(Mathf.Clamp(pointer.position.x, -bounds.x, bounds.x), Mathf.Clamp(pointer.position.y, -bounds.y, bounds.y), 5);
    }

    private void Awake()
    {
        pointer.position = playerTransform.position;
    }

    private void Update()
    {
        Vector3 toPointer = new Vector3(pointer.position.x - playerTransform.position.x, pointer.position.y - playerTransform.position.y, pointer.position.z - playerTransform.position.z);
        toPointer.Normalize();
        playerTransform.forward = Vector3.Lerp(playerTransform.forward, toPointer, Time.deltaTime * speed);
    }

    public void startFire()
    {
        startFireEvent.invoke();
    }

    public void stopFire()
    {
        stopFireEvent.invoke();
    }

    public void toggleMainMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
