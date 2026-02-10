using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public NPCContext npcContext; // drag your NPCContext object here in inspector

    private List<string> testInputs = new List<string>
    {
        "Hai", "Halo, apa kabar?", "Lagi ngapain?", "Selamat pagi", "Bro, kabar lo gimana?",
        "Kamu sedang bahagia ya?", "Jangan marah ya", "Ngomong dong", "Ceritain sesuatu", "Apa hobi kamu?",
        "Kamu kenapa kelihatan sedih?", "Kamu baik banget deh", "Kamu nyebelin!", "Aku kesel sama kamu",
        "2+2 berapa?", "Siapa presiden Amerika?", "Aku lapar banget nih", "Lagi hujan ya?", "Kenapa kamu diem aja?",
        "Aku sedih banget hari ini"
    };

    private IEnumerator Start()
    {
        // Uji untuk setiap emosi
        string[] states = { "Normal", "Happy", "Angry" };

        foreach (string state in states)
        {
            SetState(state);
            Debug.Log($"\n====== TESTING STATE: {state} ======");

            foreach (string input in testInputs)
            {
                string response = npcContext.TestInput(input); // anggap metode ini tersedia
                Debug.Log($"[State: {state}] Input: \"{input}\" → Response: \"{response}\"");
                yield return new WaitForSeconds(0.5f); // beri jeda agar log tidak numpuk
            }

            yield return new WaitForSeconds(2f); // jeda antar state
        }

        Debug.Log("=== Pengujian selesai ===");
    }

    private void SetState(string state)
    {
        switch (state)
        {
            case "Happy":
                npcContext.MakeHappy();
                break;
            case "Angry":
                npcContext.MakeAngry();
                break;
            case "Normal":
                npcContext.MakeNormal();
                break;
        }
    }
}
