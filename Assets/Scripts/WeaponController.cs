using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour // ten skrypt równie¿ nie by³ w pe³ni omówiony na zajêciach
{
    [SerializeField] WeaponSO[] weapon; //lista scriptable objects, ró¿nych typów broni.
    [SerializeField] ParticleSystem sparks; // system cz¹stek który bêdzie wyœwietlany przy trafieniu w element otoczenia
    [SerializeField] GameObject gun; //broñ
    [SerializeField] AudioSource audioSource; // Ÿród³o odtwarzania dŸwiêku
    [SerializeField] AudioClip gunShotSFX; // dŸwiêk jaki bêdzie wyœwietlany przy strzale

    Transform gunPosition; // miejsce w jakim znajduje siê broñ
    GameplayManager gameplayManager; // gameplayManager bêdzie potrzebny do sprawdzania czy gra nie jest zatrzymana
    Camera cam; //z kamery bêdzie startowa³ "promieñ" do sprawdzania czy i w co trafiliœmy
    WeaponSO pickedWeapon; // wybrana broñ
    int weaponIndex = 0; //numer wybranej broni
    void Start()
    {
        cam = Camera.main; // przypisanie g³ównej (i jedynej w tym przypadku) kamery
        gameplayManager = FindAnyObjectByType<GameplayManager>(); //wyszukanie gameplayManagera
        pickedWeapon = weapon[weaponIndex]; //przypisanie pierwszej broni z listy jako aktywnej
        gunPosition = gun.transform; //ustawienie wybranej broni na miejscu
        SwitchGun(); // uruchomienie metody do zmiany broni
    }

    void Update()
    {
        if (!gameplayManager.isPaused) //sprawdzenie czy gra nie jest zatrzymana
        {
            if (Input.GetMouseButtonDown(0)) // czy zosta³ wciœniêty lewy przycisk myszy
            {
                StartCoroutine(nameof(Shoot)); // uruchomienie korutyny o nazwie Shoot
            }
            if (Input.GetMouseButtonUp(0)) // sprawdzenie czy przycisk zosta³ puszczony
            {
                StopCoroutine(nameof(Shoot)); // zatrzymanie korutyny
            }
            if (Input.mouseScrollDelta.y > 0) //sprawdzanie czy scroll zosta³ u¿yty (tego na zajêciach nie robiliœmy
            {
                if (pickedWeapon != weapon[weapon.Length - 1] && weapon.Length != 1)
                {
                    pickedWeapon = weapon[weaponIndex+1];                    
                    weaponIndex++;
                    SwitchGun();
                }
                else
                {
                    pickedWeapon = weapon[0];
                    weaponIndex = 0;
                    SwitchGun();
                }
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                if (pickedWeapon != weapon[0] && weapon.Length != 1)
                {
                    pickedWeapon = weapon[weaponIndex-1];
                    weaponIndex--;
                    SwitchGun();
                }
                else
                {
                    pickedWeapon = weapon[weapon.Length-1];
                    weaponIndex = weapon.Length-1;
                    SwitchGun();
                }
            }
        }
    }

    IEnumerator Shoot() // korutyna wywo³ywana do strzelania
    {
        while (true)
        {
            if (pickedWeapon.ammoAmount > 0) //sprawdzenie czy broñ posiada jeszcze amunicjê w magazynku
            {
                audioSource.PlayOneShot(gunShotSFX); //odtwarzanie pojedyñczego wystrza³u
                RaycastHit hit; // zmienna do przechowywania informacji o "trafionym" obiekcie
                Ray ray = new Ray(cam.transform.position, cam.transform.forward); // definiowanie "promienia" z pozycji kamery "na wprost"
                Physics.Raycast(ray, out hit); // tworzenie zdefiniowanego promienia i zapisywanie danych o obiekcie
                pickedWeapon.Shoot();
                if (hit.collider != null) // sprawdzenie czy w coœ trafiliœmy
                {
                    if (hit.collider.tag == "Enemy") // i czy by³ to przeciwnik
                    {
                        hit.collider.GetComponent<Enemy>().OnShot(pickedWeapon.damage); // wywo³anie metody która ma zadaæ przeciwnikowi obra¿enia
                    }
                    else // je¿eli trafiony obiekt nie jest przeciwnikiem
                    {
                        ParticleSystem sparksInstance = Instantiate(sparks, hit.point, hit.collider.transform.rotation); // stworzenie "iskier" w miejscu trafienia
                        Destroy(sparksInstance.gameObject, 0.5f); // zniszczenie obiektu w ramach czyszczenia pamiêci
                    }
                    print(hit.collider.name); // wyœwietlanie nazwy trafionego obiektu (w celach debugowania)
                }
            }
            else // je¿eli broñ nie posiada amunicji
            {
                print("No ammo!"); // wyœwietlanie w konsoli komunikatu
            }
            yield return new WaitForSeconds(1 / pickedWeapon.fireRate); // przerwa pomiêdzy kolejnymi wystrza³ami je¿eli gracz trzyma wciœniêty lewy przycisk myszy
        }
    }

    void SwitchGun() // metoda do zmiany broni
    {
        Destroy(gun);
        gun = Instantiate(pickedWeapon.visualRepresentation, gameObject.transform.GetChild(0));
        gun.SetActive(true);
    }

}
