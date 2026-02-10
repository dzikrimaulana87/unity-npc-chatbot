using UnityEngine;
public class HappyState : INPCState
{
    public string GetDatasetPath()
    {
        return "Datasets/dataset_happy";
    }

    public string Respond(NPCContext context, string userInput)
    {
        string response = ChatbotService.RetrieveResponse(userInput, GetDatasetPath());
        return response;
    }
}
