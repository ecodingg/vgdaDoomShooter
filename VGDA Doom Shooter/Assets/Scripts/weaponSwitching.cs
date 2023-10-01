using TMPro;
using UnityEngine;

public class weaponSwitching : MonoBehaviour
{
    // Start is called before the first frame update

    public int selectedWeapon = 0;

    //public TextMeshProUGUI tommyText, shotgunText;
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon){
            SelectWeapon();
        }
    }

    // void switchText(){
    //     if (tommyText.gameObject.activeInHierarchy){
    //         tommyText.gameObject.SetActive(false);
    //         shotgunText.gameObject.SetActive(true);
    //     }
    //     if(shotgunText.gameObject.activeInHierarchy){
    //         shotgunText.gameObject.SetActive(false);
    //         tommyText.gameObject.SetActive(true);
    //     }
    // }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon){
                weapon.gameObject.SetActive(true);
                //switchText();
            }
            else{
                weapon.gameObject.SetActive(false);
                //switchText();
            }
            i++;
        }
    }


}
