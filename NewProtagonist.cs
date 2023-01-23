using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NewProtagonist: MonoBehaviour, IDamageable
{
    public static NewProtagonist Instance;

    // stats
    public int currentHP;   // current health points
    public int maxHP;       // maximum health points
    public float moveSpeed;
    public Vector3 respawnPoint; // where in the world will there character respawn after death
    // inventory
    public List<ItemByQuantity> itemsInInventory; // list of each item by quantity.
    public float currentWeight;
    public float maxWeight = 100;
    private float SumCurrentWeight => itemsInInventory.Select(itemInside => itemInside.Item.weight).Sum();
    // equipment
    public NewWeapon weapon;
    // movement
    private CharacterController charController;
    private Vector2 moveDirection;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        charController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        bool running = Input.GetKeyDown(KeyCode.LeftShift);

        Move(new Vector2(horizontal, vertical), running);
    }
    
    // Movement
    private void Move(Vector2 direction, bool running)
    {
        if(direction == Vector2.zero)
        {
            return;
        }

        charController.Move(new Vector3(direction.x, 0, direction.y));
    }
    
    // Stats
    public void ChangeHealth(int health)
    {
        currentHP = Math.Clamp(currentHP + health, 0, maxHP);
        if(currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }
    
    // Interaction
    public bool Interact()
    {
        return false;
    }
    public void UseItem(Item item)
    {
        switch (item.itemRole)
        {
            case ItemRole.TRASH:
                Debug.Log($"This has no use.");
                break;
            case ItemRole.WEAPON:
                EquipWeapon(item as NewWeapon);
                break;
            case ItemRole.CONSUMABLE:
                Consume(item as Consumable);
                break;
            default:
                Debug.Log("I cannot use this.");
                break;
        }
    }
    
    // Equipment
    public void EquipWeapon(NewWeapon weapon)
    { 
        if(weapon == null)
        {   // failsafe
            return;
        }

        if (this.weapon != null)
        {   // if there is a weapon already equipped, return it to the inventroy.
            AddItemToInventory(weapon, 1);
        }

        this.weapon = weapon;
    }
    
    // Inventory
    private bool CanAddToInventory(Item item, int quantity = 1)
    {
        float newWeight = currentWeight + item.weight;
        if(newWeight > maxWeight)
        {
            Debug.Log($"This item is too heavy for me.");
            return false;
        }

        return true;
    }
    private ItemByQuantity FindInInventory(Item item) => itemsInInventory.Find(itemInInventory => itemInInventory.Item == item);
    private void AddItemToInventory(Item item, int quantity = 1)
    {
        var foundItem = FindInInventory(item);
        // if there are no items in inventory, add a new element.
        if (foundItem == null)
        {   
            itemsInInventory.Add(new ItemByQuantity(foundItem.Item, foundItem.Quantity));
            return;
        }
        // if the item is already in the inventory, increase its quantity
        foundItem.ModifyQuantity(quantity);
    }
    
    // Damageable
    public void Attack()
    {
        throw new NotImplementedException();
    }
    public void Consume(Consumable consumable)
    {
        ChangeHealth(-consumable.healthRestore);
    }
    public void Die()
    {
        Debug.Log("lmao you died. now respawn somehow xd");
    }
    public void GetAttacked(Damage[] damageApplied)
    {
        int healthChange = 0;
        foreach(var damage in damageApplied)
        {
            healthChange += damage.DamageAmmount;
        }
        ChangeHealth(healthChange);
    }

    // Player savegame
    public class State
    {
        // name
        public string name;
        // stats
        public int currentHP;
        public int maxHP;
        public float moveSpeed;
        // respawn
        public float respawnX;
        public float respawnY;
        public float respawnZ;
        // equipment
        public string weapon;
        // inventory
        public float maxWeight;
        public ProtagonistInventoryItemState[] itemsInInventory;
        // position
        public float positionX;
        public float positionY;
        public float positionZ;
        public State(NewProtagonist protagonist)
        {
            // name
            name = protagonist.name;
            // stats
            currentHP = protagonist.currentHP;
            maxHP = protagonist.maxHP;
            moveSpeed = protagonist.moveSpeed;
            maxWeight = protagonist.maxWeight;
            // respawn
            respawnX = protagonist.respawnPoint.x;
            respawnY = protagonist.respawnPoint.y;
            respawnZ = protagonist.respawnPoint.z;
            // equipment
            weapon = protagonist.weapon.name;
            // inventory
            itemsInInventory = new ProtagonistInventoryItemState[protagonist.itemsInInventory.Count];
            for(int i = 0; i < protagonist.itemsInInventory.Count; i++)
            {
                var slot = protagonist.itemsInInventory[i];
                itemsInInventory[i] = new ProtagonistInventoryItemState(slot);
            }
            // position
            positionX = protagonist.transform.position.x;
            positionY = protagonist.transform.position.y;
            positionZ = protagonist.transform.position.z;
        }
    }
}