using UnityEngine;

public class AngryState : INPCState
{
    public string GetDatasetPath()
    {
        return "Datasets/dataset_angry";
    }

    public string Respond(NPCContext context, string userInput)
    {
        string response = ChatbotService.RetrieveResponse(userInput, GetDatasetPath());
        return response;
    }
}
