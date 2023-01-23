using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;

[Serializable]
public class ProtagonistUI
{
    [Header("Stats"), Space]
    [SerializeField] private Canvas statsCanvas;
    [SerializeField] private TextMeshProUGUI currentHealth;
    [SerializeField] private TextMeshProUGUI maximumHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private TextMeshProUGUI currentEnergy;
    [SerializeField] private TextMeshProUGUI maximumEnergy;
    [SerializeField] private Image energyFill;
    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private TextMeshProUGUI currentExperience;
    [SerializeField] private TextMeshProUGUI requiredExperience;
    [SerializeField] private Image experienceFill;
    [Header("Inventory"), Space]
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private TextMeshProUGUI currentWeight;
    [SerializeField] private TextMeshProUGUI maximumWeight;
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private AssetReference inventorySlotPrefab;
    [Header("Dialogue"), Space]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private TextMeshProUGUI dialogueTitle;
    [SerializeField] private TextMeshProUGUI dialogueMessage;
    [SerializeField] private Transform dialogueOptionContainer;
    [SerializeField] private AssetReference dialogueOptionPrefab;
    [Header("Equipment"), Space]
    [SerializeField] private Image mainHand;
    [SerializeField] private Image offHand;
    [SerializeField] private Image head;
    [SerializeField] private Image torso;
    [SerializeField] private Image legs;
    
    public void UpdateHealth(int currentHealth, int maximumHealth)
    {
        if (this.currentHealth != null) this.currentHealth.text = currentHealth.ToString();
        if (this.maximumHealth != null) this.maximumHealth.text = maximumHealth.ToString();
        if(this.healthFill != null) this.healthFill.fillAmount = (float)currentHealth / (float)maximumHealth;
    }
    public void UpdateEnergy(float currentEnergy, float maximumEnergy)
    {
        if (this.currentEnergy != null) this.currentEnergy.text = currentEnergy.ToString();
        if (this.maximumEnergy != null) this.maximumEnergy.text = maximumEnergy.ToString();
        if (this.energyFill != null) this.energyFill.fillAmount = (float)currentEnergy / (float)maximumEnergy;
    }
    public void UpdateExperience(int currentExperience, int requiredExperience, int currentLevel)
    {
        if (this.currentExperience != null) this.currentExperience.text = currentExperience.ToString();
        if (this.requiredExperience != null) this.requiredExperience.text = requiredExperience.ToString();
        if (this.experienceFill != null) this.experienceFill.fillAmount = (float)currentExperience / (float)requiredExperience;
        if (this.currentLevel != null) this.currentLevel.text = currentLevel.ToString();
    }
    public async void UpdateInventory(ItemByQuantity[] inventory, float currentWeight, float maximumWeight)
    {
        if (this.currentWeight != null) this.currentWeight.text = currentWeight.ToString();
        if (this.maximumWeight != null) this.maximumWeight.text = maximumWeight.ToString();

        if (inventoryContainer == null) return;
        // limpiar inventario
        foreach(Transform t in inventoryContainer) GameObject.Destroy(t.gameObject);
        // llenar inventario
        if((inventory != null) && (inventory.Length > 0))
        {
            GameObject invSlot = await GameManager.GetReferenceGameObject(inventorySlotPrefab, this.inventoryContainer);
            invSlot.SetActive(false);
        }
    }

    public async void UpdateDialogue(string title, Message message, Sprite sprite = null)
    {
        if (this.dialogueTitle != null) this.dialogueTitle.text = "-";
        if (this.dialogueMessage != null) this.dialogueMessage.text = "-";
        if (this.dialogueImage != null) this.dialogueImage.sprite = null;
        
        if (this.dialogueTitle != null) this.dialogueTitle.text = title;
        if (this.dialogueMessage != null) this.dialogueMessage.text = message.content;
        if (this.dialogueImage != null && sprite != null) this.dialogueImage.sprite = sprite;
        
        if (dialogueOptionContainer == null) return;
        // limpiar opciones de dialogo
        foreach (Transform t in dialogueOptionContainer) GameObject.Destroy(t);
        // llenar opciones de dialogo
        if((message != null) && (message._messages.Length > 0))
        {
            GameObject dialogueOption = await GameManager.GetReferenceGameObject(dialogueOptionPrefab, this.dialogueOptionContainer);
            dialogueOption.SetActive(false);
        }

    }

    public void UpdateEquipment(Sprite head = null, Sprite torso = null, Sprite legs = null, Sprite mainHand = null, Sprite offHand = null)
    {
        if ((this.head != null) && (head != null)) this.head.sprite = head;
        if ((this.torso != null) && (torso != null)) this.torso.sprite = torso;
        if ((this.legs != null) && (legs != null)) this.legs.sprite = legs;
        if ((this.mainHand != null) && (mainHand != null)) this.mainHand.sprite = mainHand;
        if ((this.offHand != null) && (offHand != null)) this.offHand.sprite = offHand;
    }
}
