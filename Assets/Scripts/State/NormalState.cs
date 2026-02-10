using UnityEngine;

public class NormalState : INPCState
{
    public string GetDatasetPath()
    {
        return "Datasets/dataset_normal";
    }

    public string Respond(NPCContext context, string userInput)
    {
        string response = ChatbotService.RetrieveResponse(userInput, GetDatasetPath());
        return response;
    }
}
