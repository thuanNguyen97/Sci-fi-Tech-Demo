using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeReference]
    private float _gravity = 9.8f;
    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;

    private bool _isReloading;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        //hide mouse cursor
        //and lock it in the center
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _controller = GetComponent<CharacterController>(); //Get access to Character controller component    

        _currentAmmo = _maxAmmo;

        //find the canvas to access the component of it
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse clicked
        //cast a ray at the center of the main camera
        if (Input.GetMouseButton(0) && _currentAmmo > 0) // get mouse left click (hold)
        {
            Shoot();
        }
        else 
        {
            //turn off muzzle flash
            _muzzleFlash.SetActive(false);

            //turn off weapon sound
            _weaponAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;  
            StartCoroutine(Reload());
        }

        //if escape key pressed
        //unhide mouse cursor
        //unlock it
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
    }

    void Shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f,  0.5f, 0)); // cast a ray from the center of the screen
            RaycastHit hitInfo; // this parameter store the data of what we hit

            //turn on muzzle flash
            _muzzleFlash.SetActive(true);

            //minus current ammo
            _currentAmmo--;

            //update ui ammo
            _uiManager.UpdateAmmo(_currentAmmo);

            //if weapon sound is not play
            //play the weapon sound
            if (_weaponAudio.isPlaying == false)
            {
                _weaponAudio.Play();
            }

            //check if we ray cast hit something
            //get the exact name of what we hit
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);

                // instantiate hit marker as a game object
                // then destroy it
                GameObject hitMarker = (GameObject) Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.identity);
                Destroy(hitMarker, 0.5f); 
            }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Specify direction of the character's movement

        // y = 0 because it is related to gravity
        Vector3 direction = new Vector3(horizontalInput, 0,verticalInput); 

        // create player velocity
        Vector3 velocity = direction * _speed;

        // apply gravity in every frame
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity); // convert local space to world space

        // parsing direction variable to Move()
        _controller.Move(velocity * Time.deltaTime); // *Time.deltaTime to apply it in real time
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;

        //update ui ammo
        _uiManager.UpdateAmmo(_currentAmmo);

        _isReloading = false;
    }
}
