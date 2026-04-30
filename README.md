# 🎰 Unity Slot Machine Game

## 📌 Overview

This project is a 2D Slot Machine game developed in Unity as part of an assignment.
The game simulates a classic casino slot machine with spinning reels, randomized outcomes, and a basic betting system.

---

## 🎮 Features

* 🎰 3 Reel Slot Machine system
* 🔄 Smooth spinning animation with looping reels
* 🎯 Controlled random outcomes (win/lose system)
* 🧠 Result logic:

  * 3 matching symbols → Jackpot
  * 2 matching symbols → Small Win
  * No match → Loss
* 💰 Betting system with dynamic win calculation
* 🖥️ Responsive UI using Canvas Scaler and Anchors
* 🔘 Interactive Spin button (UI-based input)
* ✨ Symbol snapping for perfect alignment

---

## 🛠️ Tech Stack

* **Engine:** Unity 6 (6000.3.10f1)
* **Language:** C#
* **UI System:** Unity UI (Canvas, Image, Button)
* **Input:** New Input System (for extensibility)

---

## 🧱 Project Structure

```plaintext
Assets/
 ├── Scenes/
 ├── Scripts/
 │     ├── ReelController.cs
 │     ├── SlotMachineController.cs
 │     ├── SymbolItem.cs
 │     └── UILight.cs
 ├── Sprites/
 ├── Prefabs/
```

---

## ⚙️ How It Works

### 🎰 Reel System

* Each reel is a vertical list of symbols.
* Symbols loop infinitely during spinning.
* On stop, reels snap to the nearest valid position for alignment.

### 🎯 Result Generation

* Outcome is decided **before reels stop**.
* Controlled randomness ensures:

  * Fair distribution of wins and losses
  * Deterministic stopping behavior

### 🧠 Symbol Identification

* Each symbol uses a `SymbolItem` script with a unique ID.
* Ensures correct targeting regardless of reel order changes.

### 💰 Win Logic

* Jackpot → Bet × 5
* Small Win → Bet × 2
* Loss → 0

---

## ▶️ How to Play

1. Press the **SPIN** button
2. Reels start spinning simultaneously
3. Reels stop one by one (left → right)
4. Win amount is displayed based on result

---

## 📱 UI Responsiveness

* Uses **Canvas Scaler (Scale With Screen Size)**
* Anchors ensure consistent layout across resolutions
* Tested on multiple aspect ratios

---

## 🚀 Possible Improvements

* Add sound effects and background music
* Add reel spin easing (acceleration/deceleration)
* Implement advanced payout table
* Add animations (win effects, flashing lights)
* Mobile optimization and touch gestures

---

## 📂 Setup Instructions

1. Open project in Unity 6+
2. Open `SampleScene`
3. Press Play in Editor

---

## 👤 Author

Mayanksinh Jadeja

---

## 📄 License

This project is created for educational/assignment purposes.
