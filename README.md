# RDR2 Visual Novel

## Overview

RDR2 Visual Novel is a story-driven visual novel inspired by the world of Red Dead Redemption 2. The project was developed in C# using Windows Forms and combines narrative gameplay, branching choices, dynamic character reputation, background music, and external story management through JSON files.

The application allows players to interact with the story through choices that influence the outcome of the game. In addition, a dedicated Story Editor was developed to simplify story creation and modification without changing the source code.

---

## Features

### Main Menu System
- Video background using Windows Media Player.
- New Game option.
- Continue option with save-file detection.
- Exit functionality.

### JSON-Based Story Engine
- Story content is stored externally in a story.json file.
- Each story scene is represented by a BlocPoveste object.
- Story progression is controlled through unique block IDs.
- New story content can be added without modifying the game code.

### Branching Narrative
- Multiple player choices influence story progression.
- Different paths lead to different outcomes.
- Dynamic story navigation through decision targets.

### Gang Appreciation System
- Player actions modify the Apreciere Gang value.
- Positive and negative decisions affect reputation.
- Story endings depend on the player's accumulated reputation.

### Dynamic Multimedia System
- Automatic background image loading.
- Dynamic character portrait loading.
- Character image mirroring support.
- Scene-specific background music.

### Save and Load System
- Saves the current story block ID.
- Saves the current Gang Appreciation value.
- Allows players to continue from the exact point where they left the game.

### Story Editor
A separate Windows Forms application used to:
- Load story data from JSON files.
- Create new story blocks.
- Edit characters, dialogue, and backgrounds.
- Export updated stories back to JSON.

---

## Technologies Used

- C#
- .NET Framework
- Windows Forms
- Windows Media Player Component
- JSON Serialization (System.Text.Json)
- Object-Oriented Programming

---

## Project Structure

text RDR2_Visual_Novel/ │ ├── Form1.cs ├── FormNewGame.cs ├── story.json │ ├── Models/ │   └── BlocPoveste.cs │ ├── Audio/ ├── Video/ ├── Resources/ │ └── salvare.txt  EditorPoveste/ └── Form1.cs 

---

## Story Architecture

The story is represented using three core classes:

### BlocPoveste
Represents a story scene.

Contains:
- Character name
- Dialogue text
- Background image
- Character image
- Background music
- Available choices

### Decizie
Represents a player choice.

Contains:
- Button text
- Target story block
- Reputation effect
- Availability conditions

### PovesteData
Container class that stores all story blocks loaded from JSON.

---

## Educational Objectives

This project demonstrates:
- Event-driven programming
- Data-driven game design
- JSON serialization and deserialization
- State management
- User interface development
- Multimedia integration
- Object-oriented software architecture

---

## Authors

MOHSENPOUR Seyedmohammadhossein

LUCA Alexandru

---

## Future Improvements

- Additional story chapters
- More character interactions
- Inventory system
- Multiple save slots
- Advanced story editor
- Sound effects and animations

---



# RDR2 Visual Novel

## Prezentare Generală

RDR2 Visual Novel este un joc de tip visual novel inspirat din universul Red Dead Redemption 2. Proiectul a fost realizat în C# folosind Windows Forms și combină o poveste interactivă, alegeri ramificate, un sistem de reputație, muzică de fundal și gestionarea externă a poveștii prin fișiere JSON.

Jucătorul poate influența desfășurarea poveștii prin deciziile sale, iar rezultatul final depinde de alegerile făcute pe parcursul jocului. În plus, a fost dezvoltat și un editor dedicat pentru modificarea poveștii fără schimbarea codului sursă.

---

## Funcționalități

### Sistem Main Menu
- Fundal video utilizând Windows Media Player.
- Opțiunea New Game.
- Opțiunea Continue.
- Funcție Exit.

### Motor de Poveste Bazat pe JSON
- Povestea este stocată într-un fișier extern story.json.
- Fiecare scenă este reprezentată printr-un obiect BlocPoveste.
- Navigarea prin poveste se realizează folosind identificatori unici.
- Conținutul poate fi extins fără modificarea codului aplicației.

### Poveste Ramificată
- Alegerile jucătorului influențează progresul poveștii.
- Există mai multe trasee narative.
- Deciziile conduc către scene diferite.

### Sistemul Apreciere Gang
- Acțiunile jucătorului modifică valoarea reputației.
- Deciziile pot avea efecte pozitive sau negative.
- Finalul jocului depinde de reputația acumulată.

### Sistem Multimedia Dinamic
- Încărcare automată a imaginilor de fundal.
- Încărcare automată a personajelor.
- Suport pentru rotirea imaginilor personajelor.
- Muzică specifică fiecărei scene.

### Sistem Save / Load
- Salvează ID-ul blocului curent.
- Salvează valoarea Apreciere Gang.
- Permite continuarea jocului din punctul exact în care a fost oprit.

### Editor de Poveste
Aplicația separată EditorPoveste permite:
- Încărcarea poveștii din JSON.
- Crearea de blocuri noi.
- Editarea personajelor și dialogurilor.
- Exportarea poveștii actualizate în format JSON.

---

## Tehnologii Utilizate

- C#
- .NET Framework
- Windows Forms
- Windows Media Player Component
- JSON Serialization (System.Text.Json)
- Programare Orientată pe Obiecte

---

## Structura Proiectului

text RDR2_Visual_Novel/ │ ├── Form1.cs ├── FormNewGame.cs ├── story.json │ ├── Modele/ │   └── BlocPoveste.cs │ ├── Audio/ ├── Video/ ├── Resources/ │ └── salvare.txt  EditorPoveste/ └── Form1.cs 

---

## Arhitectura Poveștii

### BlocPoveste
Reprezintă o scenă individuală.

Conține:
- numele personajului
- textul dialogului
- imaginea de fundal
- imaginea personajului
- muzica de fundal
- lista deciziilor disponibile

### Decizie
Reprezintă o alegere făcută de jucător.

Conține:
- textul butonului
- blocul țintă
- efectul asupra reputației
- condițiile de afișare

### PovesteData
Clasă care conține toate blocurile poveștii încărcate din JSON.

---

## Obiective Educaționale

Proiectul demonstrează:
- programare orientată pe evenimente
- proiectare bazată pe date
- serializare și deserializare JSON
- gestionarea stării aplicației
- dezvoltarea interfețelor grafice
- integrarea elementelor multimedia
- arhitectură software orientată pe obiecte

---

## Autori

MOHSENPOUR Seyedmohammadhossein

LUCA Alexandru

---

## Dezvoltări Viitoare

- capitole suplimentare
- mai multe interacțiuni între personaje
- sistem de inventar
- mai multe sloturi de salvare
- editor de poveste avansat
- efecte sonore și animații

  
