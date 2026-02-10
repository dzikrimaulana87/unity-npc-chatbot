using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NPCInput : MonoBehaviour
{
    public Image emotionImage;
    public Sprite happySprite, angrySprite, normalSprite;
    public NPCContext npc;
    public TMP_InputField inputField;

    void Update()
    {

        // Kirim input jika TextMeshPro aktif dan tombol Enter ditekan
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendInput();
            // Opsional: kembali fokus ke inputField
            EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
            inputField.OnPointerClick(new PointerEventData(EventSystem.current));
        }
    }

    // Kirim input dari inputField ke NPC
    public void SendInput()
    {
        string userInput = inputField.text.Trim();
        if (!string.IsNullOrEmpty(userInput))
        {
            npc.ReceiveInput(userInput);

            inputField.text = "";
        }
    }
}
