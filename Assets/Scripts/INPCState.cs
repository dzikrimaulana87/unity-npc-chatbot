public interface INPCState
{
    string GetDatasetPath();
    string Respond(NPCContext context, string userInput);
}
