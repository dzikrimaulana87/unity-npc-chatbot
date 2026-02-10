using System;
using System.Collections.Generic;
using System.Linq;

namespace Chatbot.Utils
{
    public static class TextSimilarity
    {
        public static double CosineSimilarity(string a, string b)
        {
            var wordsA = TextTokenizer.Tokenize(a);
            var wordsB = TextTokenizer.Tokenize(b);
            var allWords = wordsA.Union(wordsB).Distinct().ToList();

            var vecA = allWords.Select(w => wordsA.Count(x => x == w)).ToArray();
            var vecB = allWords.Select(w => wordsB.Count(x => x == w)).ToArray();

            double dot = 0, magA = 0, magB = 0;
            for (int i = 0; i < allWords.Count; i++)
            {
                dot += vecA[i] * vecB[i];
                magA += vecA[i] * vecA[i];
                magB += vecB[i] * vecB[i];
            }

            if (magA == 0 || magB == 0) return 0;
            return dot / (Math.Sqrt(magA) * Math.Sqrt(magB));
        }
    }
}
