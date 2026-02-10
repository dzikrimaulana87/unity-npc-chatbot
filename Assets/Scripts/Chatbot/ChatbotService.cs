using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Chatbot.Models;
using Chatbot.Utils;

public static class ChatbotService
{
    public static string RetrieveResponse(string input, string datasetPath)
    {
        TextAsset dataset = Resources.Load<TextAsset>(datasetPath);
        if (dataset == null)
        {
            Debug.LogWarning("Dataset tidak ditemukan: " + datasetPath);
            return "Maaf, aku tidak tahu harus bilang apa.";
        }

        ChatDataset parsedData = JsonUtility.FromJson<ChatDataset>(dataset.text);
        if (parsedData == null || parsedData.categories == null || parsedData.categories.Count == 0)
            return "Dataset kosong atau format salah.";

        var datasetList = parsedData.categories;

        List<string> allPatterns = new List<string>();
        List<string> tags = new List<string>();

        foreach (var category in datasetList)
        {
            foreach (var pattern in category.patterns)
            {
                allPatterns.Add(pattern);
                tags.Add(category.tag);
            }
        }

        int bestIndex = -1;
        double bestScore = -1.0;

        for (int i = 0; i < allPatterns.Count; i++)
        {
            double sim = TextSimilarity.CosineSimilarity(input, allPatterns[i]);
            if (sim > bestScore)
            {
                bestScore = sim;
                bestIndex = i;
            }
        }

        if (bestIndex >= 0)
        {
            string matchedTag = tags[bestIndex];
            var matchedCategory = datasetList.FirstOrDefault(cat => cat.tag == matchedTag);
            if (matchedCategory != null && matchedCategory.responses.Count > 0)
            {
                return matchedCategory.responses[UnityEngine.Random.Range(0, matchedCategory.responses.Count)];
            }
        }

        return "Maaf, aku tidak tahu harus bilang apa.";
    }


    //start of testing area

    //     public static string RetrieveResponseTesting(string input, string datasetPath)
    // {
    //     TextAsset dataset = Resources.Load<TextAsset>(datasetPath);
    //     if (dataset == null)
    //     {
    //         Debug.LogWarning("Dataset tidak ditemukan: " + datasetPath);
    //         return "Maaf, aku tidak tahu harus bilang apa.";
    //     }

    //     ChatDataset parsedData = JsonUtility.FromJson<ChatDataset>(dataset.text);
    //     if (parsedData == null || parsedData.categories == null || parsedData.categories.Count == 0)
    //         return "Dataset kosong atau format salah.";

    //     var datasetList = parsedData.categories;

    //     List<string> allPatterns = new List<string>();
    //     List<string> tags = new List<string>();

    //     foreach (var category in datasetList)
    //     {
    //         foreach (var pattern in category.patterns)
    //         {
    //             allPatterns.Add(pattern);
    //             tags.Add(category.tag);
    //         }
    //     }

    //     int bestIndex = -1;
    //     double bestScore = -1.0;

    //     for (int i = 0; i < allPatterns.Count; i++)
    //     {
    //         double sim = TextSimilarity.CosineSimilarity(input, allPatterns[i]);
    //         if (sim > bestScore)
    //         {
    //             bestScore = sim;
    //             bestIndex = i;
    //         }
    //     }

    //     if (bestIndex >= 0)
    //     {
    //         string matchedTag = tags[bestIndex];
    //         var matchedCategory = datasetList.FirstOrDefault(cat => cat.tag == matchedTag);
    //         if (matchedCategory != null && matchedCategory.responses.Count > 0)
    //         {

    //             // return matchedCategory.responses[UnityEngine.Random.Range(0, matchedCategory.responses.Count)];
    //             //return nama kelasnya
    //             return matchedCategory.tag;

    //         }
    //     }

    //     return "Maaf, aku tidak tahu harus bilang apa.";
    // }

    //end of testing area
}
