
# RDR2 Visual Novel

## English Version

## Project Overview

RDR2 Visual Novel is a C# Windows Forms project developed as a university assignment. The project is inspired by the atmosphere of Red Dead Redemption 2 and presents an interactive visual novel where the player follows a story, makes decisions, and influences the final outcome.

The game uses images, dialogue, background music, decision buttons, and a simple reputation system called Apreciere Gang. The player’s choices can increase or decrease the gang’s appreciation level, which later affects the ending of the story.

## Main Features

- Interactive visual novel story
- Scene-based progression using pasPoveste
- Dialogue system with character names and text
- Background images and character sprites
- Background music for different scenes
- Branching story choices
- Gang appreciation system
- Good ending and bad ending based on player choices
- Save and Load system using a text file
- HUD display for the current gang appreciation value
- Basic exception handling for file operations

## Story and Gameplay

The player begins as a protagonist wandering through the Wild West. After hearing about Dutch’s gang, the protagonist tries to join the group. In order to prove loyalty and usefulness, the player must complete different actions such as hunting or robbing people in Valentine.

At certain points, the player must choose between different story paths. These choices influence the value of Apreciere Gang. A positive value can lead to acceptance into the gang, while a negative value leads to rejection.

## Technical Implementation

The story is controlled through a switch structure inside the IncarcaScena() method. Each case represents a different scene in the game. For every scene, the program updates:

- background image
- character image
- character visibility
- dialogue name
- dialogue text
- background music

The player advances through the story by clicking on the background. When a decision is required, automatic progression stops and choice buttons become visible.

## Save and Load System

The game stores two important values in a text file named salvare.txt:

- pasPoveste – the current story step
- apreciereGang – the current gang appreciation value

These values allow the player to save progress and continue the story later from the same point.

## Technologies Used

- C#
- Windows Forms
- Visual Studio
- System.IO
- Windows Media Player component
- GitHub for version control and documentation

## Educational Purpose

This project demonstrates several important programming concepts, including event-driven programming, file input/output, conditional logic, UI updates, multimedia integration, and basic game state management.


---

# RDR2 Visual Novel

## Versiunea în limba română

## Prezentare generală

RDR2 Visual Novel este un proiect realizat în C# Windows Forms pentru o temă universitară. Proiectul este inspirat de atmosfera jocului Red Dead Redemption 2 și prezintă o poveste interactivă de tip visual novel, în care jucătorul urmărește acțiunea, ia decizii și influențează finalul poveștii.

Jocul folosește imagini, dialoguri, muzică de fundal, butoane pentru alegeri și un sistem simplu de reputație numit Apreciere Gang. Alegerile jucătorului pot crește sau scădea nivelul de apreciere al gangului, iar această valoare influențează finalul jocului.

## Funcționalități principale

- Poveste interactivă de tip visual novel
- Progresie pe scene folosind variabila pasPoveste
- Sistem de dialog cu nume de personaje și text
- Imagini de fundal și personaje
- Muzică de fundal pentru scene diferite
- Alegeri ramificate în poveste
- Sistem de apreciere al gangului
- Final pozitiv sau negativ în funcție de alegerile jucătorului
- Sistem de salvare și încărcare folosind un fișier text
- HUD pentru afișarea valorii curente de apreciere
- Tratarea erorilor pentru operațiile cu fișiere

## Poveste și gameplay

Jucătorul începe în rolul unui protagonist care călătorește prin Vestul Sălbatic. După ce aude despre gangul lui Dutch, acesta încearcă să se alăture grupului. Pentru a demonstra că este loial și util, jucătorul trebuie să facă diferite acțiuni, precum vânătoare sau jafuri în Valentine.

În anumite momente, jucătorul trebuie să aleagă între mai multe direcții ale poveștii. Aceste alegeri modifică valoarea sistemului Apreciere Gang. O valoare pozitivă poate duce la acceptarea în gang, iar o valoare negativă poate duce la respingerea protagonistului.

## Implementare tehnică

Povestea este controlată printr-o structură switch în metoda IncarcaScena(). Fiecare case reprezintă o scenă diferită a jocului. Pentru fiecare scenă, programul actualizează:

- imaginea de fundal
- imaginea personajului
- vizibilitatea personajului
- numele personajului care vorbește
- textul dialogului
- muzica de fundal

Jucătorul avansează în poveste prin click pe fundal. Atunci când este necesară o alegere, progresia automată se oprește, iar butoanele de alegere devin vizibile.

## Sistemul Save/Load

Jocul salvează două valori importante într-un fișier text numit salvare.txt:

- pasPoveste – pasul curent al poveștii
- apreciereGang – valoarea curentă a aprecierii gangului

Aceste valori permit jucătorului să salveze progresul și să continue povestea mai târziu din același punct.

## Tehnologii utilizate

- C#
- Windows Forms
- Visual Studio
- System.IO
- Componenta Windows Media Player
- GitHub pentru versionare și documentație

## Scop educațional

Acest proiect demonstrează mai multe concepte importante de programare, precum programarea orientată pe evenimente, operațiile cu fișiere, logica condițională, actualizarea interfeței grafice, integrarea elementelor multimedia și gestionarea stării jocului.
