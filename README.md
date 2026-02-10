# NPC State Pattern & Retrieval-Based Chatbot for Unity Visual Novel

An interactive NPC system for Unity visual novel games that combines State Design Pattern with retrieval-based chatbot technology to create emotionally adaptive and contextually aware character interactions.

## 🎯 Overview

This project implements an intelligent Non-Playable Character (NPC) system that responds dynamically to player interactions based on emotional states. The NPC features three distinct emotional states (Happy, Normal, Angry), each with unique dialogue datasets and behavioral patterns.

### Key Features

- **State Design Pattern**: Manages NPC emotional states with clean state transitions
- **Retrieval-Based Chatbot**: Uses cosine similarity algorithm for contextual response selection
- **Multi-State Dialogue System**: Three emotional states with dedicated conversation datasets
- **Natural Language Processing**: Text preprocessing with tokenization and lemmatization using Sastrawi (C# port)
- **Dynamic Response Selection**: Context-aware responses that adapt to player input and current emotional state

## 📊 Performance

- **Response Classification Accuracy**: 95.65% (tested on 230 inputs across 46 categories)
- **Emotional Adaptability Rate**: 45% for complex contextual scenarios
- **State Transition Success**: 100% across all test scenarios

## 🏗️ Architecture

### Core Components

```
NPCContext
├── State Management (Happy, Normal, Angry)
├── ChatbotService
│   ├── ChatDataset
│   ├── ChatCategory
│   └── Response Selection
└── NLP Pipeline
    ├── Preprocessing (Tokenization, Cleaning, Lemmatization)
    └── TextSimilarity (Cosine Similarity)
```

### State Design Pattern

The system uses a modular state pattern where:
- `NPCContext` manages active emotional states
- State transitions via `MakeHappy()`, `MakeAngry()`, `MakeNormal()` methods
- Each state links to specific dialogue datasets

### Chatbot Processing Flow

1. Player input received through `NPCInput`
2. Text preprocessing: tokenization, cleaning, lemmatization
3. Current emotional state determines active dataset
4. Cosine similarity calculates relevance scores
5. Most relevant response selected and returned

## 🚀 Getting Started

### Prerequisites

- Unity 2021.3.18f1 or later
- .NET Framework compatible with Unity

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/npc-state-chatbot-unity.git
```

2. Open the project in Unity Editor

3. Load the main scene from `Assets/Scenes/`

4. Press Play to test the NPC interaction system

### Dataset Structure

Dialogue datasets are structured in JSON format for each emotional state:

```json
{
  "categories": [
    {
      "tag": "greeting",
      "patterns": [
        "hai",
        "halo",
        "selamat pagi"
      ],
      "responses": [
        "Response variant 1",
        "Response variant 2",
        "Response variant 3"
      ]
    }
  ]
}
```

## 🎮 Usage Example

```csharp
// Initialize NPC with context
NPCContext npcContext = new NPCContext();

// Transition to Happy state
npcContext.MakeHappy();

// Process player input
string playerInput = "Halo, apa kabar?";
string npcResponse = npcContext.ProcessInput(playerInput);

// NPC responds with Happy-state dialogue
Debug.Log(npcResponse); // "Halo, sayang! Senang bisa bertemu denganmu!"
```

## 📐 Algorithm: Cosine Similarity

The chatbot uses cosine similarity to measure textual similarity:

```
cosine_similarity(A, B) = (A · B) / (||A|| × ||B||)
```

Where:
- A = player input vector
- B = response pattern vector
- Range: [0, 1] (1 = identical, 0 = completely different)

## 🧪 Testing

### State Transition Testing

All state transitions tested successfully:
- Normal → Happy
- Happy → Angry
- Angry → Normal
- And all reverse combinations

### Response Accuracy Testing

Tested with 230 unique inputs across 46 categories:
- 220 correct classifications
- 10 misclassifications
- Overall accuracy: **95.65%**

### Adaptability Testing

Scenarios tested:
- Same input across different emotional states
- Out-of-dataset contextual conversations
- Language style variations (formal, informal, synonyms)
- Irrelevant or out-of-context inputs

## 🔬 Research Foundation

This project is based on academic research published in *Jurnal Buana Informatika* (Volume 16, Number 2, October 2025).

**Citation:**
```
Maulana, D., Dila, M. N., & Putri, M. I. (2025). Penerapan State Pattern dan 
Retrieval-based Chatbot pada NPC Game Visual Novel di Unity Engine. 
Jurnal Buana Informatika, 16(2), 103-113.
```

## 📝 Limitations & Future Work

### Current Limitations

1. **Semantic Understanding**: Limited deep semantic comprehension
2. **Dataset Scope**: Template-based responses may feel repetitive
3. **Context Tracking**: No conversation history tracking
4. **Language Variation**: Difficulty with synonyms and informal language

### Planned Improvements

- [ ] Integration of advanced NLP models (sentiment analysis, context understanding)
- [ ] Expanded and diversified dialogue datasets
- [ ] Implementation of context tracking and memory-based dialogue
- [ ] Enhanced language preprocessing with synonym dictionary
- [ ] User testing and feedback integration

## Technical Stack

- **Game Engine**: Unity 2021.3.18f1
- **Programming Language**: C#
- **NLP Library**: Sastrawi (C# port) - Indonesian lemmatization
- **Algorithm**: Cosine Similarity for text matching
- **Design Pattern**: State Pattern (Finite State Machine)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Authors

- **Dzikri Maulana**
- **Muhammad Nurbayu Dila**
- **Meissy Irania Putri**

## Acknowledgments

- Sastrawi library contributors for Indonesian NLP tools
- Unity community for comprehensive documentation
- Research participants and testers

## 📧 Contact

For questions or collaboration opportunities:
- Email: dzikrimaulana1781945@gmail.com

## References

1. Jiang, Z. (2024). Emotional Simulation in Game AI and Its Impact on Player Experience
2. Pandey, S., & Sharma, S. (2023). A comparative study of retrieval-based and generative-based chatbots
3. Prakoso, D. W., et al. (2021). Short text similarity measurement methods: A review
<br>
...
etc.
---

for more details check: https://ojs.uajy.ac.id/index.php/jbi/article/view/11780

**⭐ If you find this project useful, please consider giving it a star!**