# Ecosystem project 
Auteur : **Nomena R**
## Description
Ce projet vise à simuler le comportement de différentes créatures vivantes dans un écosystème, y compris les animaux et les plantes. Leurs comportements naturels, tels que la reproduction, l'alimentation et la chasse, sont simulés de manière autonome dans cette application. Différentes entités sont simulées et ont chacune des caractères différentes : animaux carnivores, animaux herbivores, plantes.
![Image de la simulation](Images/screenshot.png)
## Diagrammes UML
### Diagramme de classes
![Diagramme de classes](Diagrams/ClassDiagram.png)
### Diagramme de séquence
![Diagramme de séquence](Diagrams/SequenceDiagram.png)
### Diagramme d'activité
![Diagramme d'activité](Diagrams/ActivityDiagram.png)

## Principe SOLID
### Single Responsibility Principle
> Les classes et les méthodes ne doivent être responsables que d'une chose.
Chaque classe du diagramme a une responsabilité unique et bien définie :
- Animal : Responsable des comportements généraux des animaux (mouvement, reproduction, mort, etc.).
- Plant : Responsable des comportements spécifiques aux plantes (consommation de déchets organiques, dispersion des graines).
- Carnivore / Herbivore : Héritent d’Animal et ajoutent des comportements spécifiques, comme la chasse pour les carnivores et la consommation de plantes pour les herbivores.
- OrganicWaste : Représente les déchets organiques, sans autre responsabilité.
- Meat : Représente la viande produite par les carnivores après une chasse.