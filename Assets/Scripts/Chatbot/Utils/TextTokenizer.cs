using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using Sastrawi.Stemmer;

namespace Chatbot.Utils
{
    public static class TextTokenizer
    {
        // Static field supaya hanya inisialisasi sekali
        private static HashSet<string> dictionary;
        private static IStemmer stemmer;
        private static bool isInitialized = false;

        private static void Initialize()
        {
            if (!isInitialized)
            {
                var factory = new StemmerFactory();
                dictionary = factory.CreateDefaultDictionary();
                stemmer = new Stemmer(dictionary);
                isInitialized = true;
            }
        }

        public static List<string> Tokenize(string text)
        {
            Initialize();

            text = text.ToLower();
            text = Regex.Replace(text, "[^a-z0-9\\s]", "");
            // Tokenize dulu
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Lemmatize/stem per token
            var stemmedTokens = tokens.Select(token => stemmer.Stem(token)).ToList();

            return stemmedTokens;
        }
    }
}
