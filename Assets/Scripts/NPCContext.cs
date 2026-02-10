using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCContext : MonoBehaviour
{
    private INPCState currentState;
    public TextMeshProUGUI npcText;
    public Image emotionImage; // assign di Inspector (UI Image)
    public Sprite happySprite, angrySprite, normalSprite;

    void Start()
    {
        currentState = new NormalState();

        if (npcText == null)
        {
            Debug.LogError("NPC Text component is not assigned in the inspector.");
        }



    }

    public void SetState(INPCState state)
    {
        currentState = state;
        
        UpdateEmotionSprite();

    }

    public void ReceiveInput(string userInput)
    {
        string nama = "Dzikri";

        // Dapatkan response asli dari currentState
        string response = currentState.Respond(this, userInput);

        // Ganti placeholder [nama] di response, bukan di input user
        if (response.Contains("[nama]"))
        {
            response = response.Replace("[nama]", nama);
        }

        npcText.text = response;

        // Debug.Log("NPC Response: " + npcText.text);
    }

//test area
    public string TestInput(string userInput)
    {
        // Dapatkan response asli dari currentState
        string response = currentState.Respond(this, userInput);

        // Ganti placeholder [nama] di response, bukan di input user
        if (response.Contains("[nama]"))
        {
            response = response.Replace("[nama]", "Dzikri");
        }

        return response;
    }
    

// end test area

    public void UpdateEmotionSprite()
    {
        if (currentState is HappyState)
            emotionImage.sprite = happySprite;
        else if (currentState is AngryState)
            emotionImage.sprite = angrySprite;
        else if (currentState is NormalState)
            emotionImage.sprite = normalSprite;
    }


    public void MakeHappy() => SetState(new HappyState());
    public void MakeAngry() => SetState(new AngryState());
    public void MakeNormal() => SetState(new NormalState());
}
