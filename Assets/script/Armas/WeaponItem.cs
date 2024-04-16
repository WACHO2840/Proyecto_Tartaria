using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject weapongPrefab;
    private bool justDropped;

    // Start is called before the first frame update
    void Start()
    {
        this.justDropped = true;
        Invoke("ActivatePicktUpMode", 1f);
    }

    private void ActivatePicktUpMode()
    {
        this.justDropped = false;
    }

    private void OntriggerEnter2D(Collider2D other)
    {
        if (this.justDropped)
            return;

        WeaponManager manager = other.GetComponent<WeaponManager>();

        if (manager == null)
            return;

        if (manager.HasRoomForWeapon == false)
            return;


        var newWeapon = Instantiate(this.weapongPrefab);
        manager.PickUpWeapon(newWeapon.GetComponent<Weapon>());
        Destroy(this.gameObject);

    }


}
