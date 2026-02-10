using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine; // Tambahkan ini!

namespace Sastrawi.Stemmer
{
    public class StemmerFactory
    {
        public CachedStemmer CreateStemmer()
        {
            var stemmer = new Stemmer(CreateDefaultDictionary());
            IDictionary<string, string> resultCache = new Dictionary<string, string>();
            var cachedStemmer = new CachedStemmer(resultCache, stemmer);
            return cachedStemmer;
        }

        public HashSet<string> CreateDefaultDictionary()
        {
            var words = GetWordsFromFile()
                .Select(w => w.Trim())         // Buang spasi di depan/belakang
                .Where(w => !string.IsNullOrEmpty(w)) // Buang baris kosong
                .ToHashSet();
            return words;
        }

        protected string[] GetWordsFromFile()
        {
            //file kata-dasar.txt harus berada pada folder Scripts/StreamingAssets
            string dictionaryFile = Path.Combine(Application.streamingAssetsPath, "kata-dasar.txt");
            // Debug.Log("Mencari dictionary di: " + dictionaryFile);

            if (!File.Exists(dictionaryFile))
                throw new FileNotFoundException(
                    $"Data directory is missing: {dictionaryFile}.\n" +
                    "It seems that your installation is corrupted."
                );

            return File.ReadAllText(dictionaryFile)
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}