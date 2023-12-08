using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GUI : MonoBehaviour
{
    public UIDocument uiDocument;
    public GunSystem tommy, shotgun;

    private Label ammoLabel;

    void Update()
    {
        VisualElement root = uiDocument.rootVisualElement;

        // Find the Label element with the name "Ammo" in the UI Document
        ammoLabel = root.Q<Label>("Ammo");

        // Update ammo based on the active gun system
        if (tommy.gameObject.activeInHierarchy)
        {
            UpdateAmmoLabel(TommyAmmo());
        }
        else if (shotgun.gameObject.activeInHierarchy)
        {
            UpdateAmmoLabel(ShotgunAmmo());
        }
    }

    void UpdateAmmoLabel(string ammoCount)
    {
        // Update the ammo label with the provided ammo count
        if (ammoLabel != null)
        {
            ammoLabel.text = ammoCount;
        }
    }

    string TommyAmmo()
    {
        // Get the ammo count from the Tommy gun system
        return tommy.bltCount();
    }

    string ShotgunAmmo()
    {
        // Get the ammo count from the Shotgun gun system
        return shotgun.bltCount();
    }
}

