using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;


/// <summary>
/// Component the player to control the character this is attached to.
/// </summary>
public class Protagonist : Character
{
    public static Protagonist instance;

    [SerializeField] private ProtagonistStats pStats;
    [SerializeField] private ProtagonistEquipment equipment;
    [SerializeField] private ProtagonistInventory inventory;

    public ProtagonistStats PStats => pStats;
    public ProtagonistEquipment Equipment => equipment;
    public ProtagonistInventory Inventory => inventory;


    [Header("Player properties")]
    public Vector2 direction;
    public bool running;
    public CharacterController character;


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        character = GetComponent<CharacterController>();
        //SetState(GameManager.instance.currState.player);
    }
    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        running = Input.GetKeyDown(KeyCode.LeftShift);

        var quickSave = Input.GetKeyDown(KeyCode.F2);
        var quickLoad = Input.GetKeyDown(KeyCode.F3);
        pStats.ChangePosition(transform.position);

        if(quickSave)
        {
            GameManager.instance.Save();
        }
    }
    private void FixedUpdate()
    {
        Move(direction, running, false);
    }
    public ProtagonistState GetState() => new ProtagonistState(this);
    public void Move(Vector2 _inputVector, bool _running, bool _dodging)
    {
        // If the player wasn't moving, return.
        if (_inputVector == Vector2.zero)
        {
            return;
        }

        // Get camera rotation vector.
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;
        
        // Clear vertical rotation so it doesn't affect movement.
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Math the input vector, the camera look vector and get the actual direction
        // the character should move torwards.
        Vector3 relativeForwardMovement = _inputVector.y * forward;
        Vector3 relativeSidewaysMovement = _inputVector.x * right;
        Vector3 moveDirection = relativeForwardMovement + relativeSidewaysMovement;

        character.Move(moveDirection * Time.deltaTime * this.CStats.MoveSpeed);
    }
    public void UseItem(Item _item)
    {
        switch (_item.itemRole)
        {
            case ItemRole.TRASH:
                Debug.Log($"This has no use.");
                break;
            case ItemRole.WEAPON:
                equipment.EquipWeapon(_item as Weapon);
                break;
            case ItemRole.ARMOR:
                equipment.EquipArmor(_item as Armor);
                break;
            case ItemRole.CONSUMABLE:
                Consume(_item as Consumable);
                break;
            default:
                Debug.Log("I cannot use this.");
                break;
        }
    }
    public void Attack()
    {
        throw new NotImplementedException();
    }
    public void GetAttacked()
    {
        throw new NotImplementedException();
    }
    public void Consume(Consumable consumable)
    {
        throw new NotImplementedException();
    }
    public void Die()
    {
        throw new NotImplementedException();
    }
    public void GetAttacked(Damage[] damageApplied)
    {
        throw new NotImplementedException();
    }
}