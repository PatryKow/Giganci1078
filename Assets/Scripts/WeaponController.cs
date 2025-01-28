using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour // ten skrypt r�wnie� nie by� w pe�ni om�wiony na zaj�ciach
{
    [SerializeField] WeaponSO[] weapon; //lista scriptable objects, r�nych typ�w broni.
    [SerializeField] ParticleSystem sparks; // system cz�stek kt�ry b�dzie wy�wietlany przy trafieniu w element otoczenia
    [SerializeField] GameObject gun; //bro�
    [SerializeField] AudioSource audioSource; // �r�d�o odtwarzania d�wi�ku
    [SerializeField] AudioClip gunShotSFX; // d�wi�k jaki b�dzie wy�wietlany przy strzale

    Transform gunPosition; // miejsce w jakim znajduje si� bro�
    GameplayManager gameplayManager; // gameplayManager b�dzie potrzebny do sprawdzania czy gra nie jest zatrzymana
    Camera cam; //z kamery b�dzie startowa� "promie�" do sprawdzania czy i w co trafili�my
    WeaponSO pickedWeapon; // wybrana bro�
    int weaponIndex = 0; //numer wybranej broni
    void Start()
    {
        cam = Camera.main; // przypisanie g��wnej (i jedynej w tym przypadku) kamery
        gameplayManager = FindAnyObjectByType<GameplayManager>(); //wyszukanie gameplayManagera
        pickedWeapon = weapon[weaponIndex]; //przypisanie pierwszej broni z listy jako aktywnej
        gunPosition = gun.transform; //ustawienie wybranej broni na miejscu
        SwitchGun(); // uruchomienie metody do zmiany broni
    }

    void Update()
    {
        if (!gameplayManager.isPaused) //sprawdzenie czy gra nie jest zatrzymana
        {
            if (Input.GetMouseButtonDown(0)) // czy zosta� wci�ni�ty lewy przycisk myszy
            {
                StartCoroutine(nameof(Shoot)); // uruchomienie korutyny o nazwie Shoot
            }
            if (Input.GetMouseButtonUp(0)) // sprawdzenie czy przycisk zosta� puszczony
            {
                StopCoroutine(nameof(Shoot)); // zatrzymanie korutyny
            }
            if (Input.mouseScrollDelta.y > 0) //sprawdzanie czy scroll zosta� u�yty (tego na zaj�ciach nie robili�my
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

    IEnumerator Shoot() // korutyna wywo�ywana do strzelania
    {
        while (true)
        {
            if (pickedWeapon.ammoAmount > 0) //sprawdzenie czy bro� posiada jeszcze amunicj� w magazynku
            {
                audioSource.PlayOneShot(gunShotSFX); //odtwarzanie pojedy�czego wystrza�u
                RaycastHit hit; // zmienna do przechowywania informacji o "trafionym" obiekcie
                Ray ray = new Ray(cam.transform.position, cam.transform.forward); // definiowanie "promienia" z pozycji kamery "na wprost"
                Physics.Raycast(ray, out hit); // tworzenie zdefiniowanego promienia i zapisywanie danych o obiekcie
                pickedWeapon.Shoot();
                if (hit.collider != null) // sprawdzenie czy w co� trafili�my
                {
                    if (hit.collider.tag == "Enemy") // i czy by� to przeciwnik
                    {
                        hit.collider.GetComponent<Enemy>().OnShot(pickedWeapon.damage); // wywo�anie metody kt�ra ma zada� przeciwnikowi obra�enia
                    }
                    else // je�eli trafiony obiekt nie jest przeciwnikiem
                    {
                        ParticleSystem sparksInstance = Instantiate(sparks, hit.point, hit.collider.transform.rotation); // stworzenie "iskier" w miejscu trafienia
                        Destroy(sparksInstance.gameObject, 0.5f); // zniszczenie obiektu w ramach czyszczenia pami�ci
                    }
                    print(hit.collider.name); // wy�wietlanie nazwy trafionego obiektu (w celach debugowania)
                }
            }
            else // je�eli bro� nie posiada amunicji
            {
                print("No ammo!"); // wy�wietlanie w konsoli komunikatu
            }
            yield return new WaitForSeconds(1 / pickedWeapon.fireRate); // przerwa pomi�dzy kolejnymi wystrza�ami je�eli gracz trzyma wci�ni�ty lewy przycisk myszy
        }
    }

    void SwitchGun() // metoda do zmiany broni
    {
        Destroy(gun);
        gun = Instantiate(pickedWeapon.visualRepresentation, gameObject.transform.GetChild(0));
        gun.SetActive(true);
    }

}
