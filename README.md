# Transportfactory

En fabrik i mitten skickar gods längs fyra grenar: väg, järnväg, luft och sjö. Varje gren har en terminal som skapar sitt transportmedel. Först med konsolen som UI, sedan med 2D-visualisering i Unity.

Projektet är min övning i designmönster och SOLID för kursen Problemlösning. Planen och diskussionen finns i [problemlosning/projekt/transportfabrik.md](https://github.com/04luknie-nemo/problemlosning/blob/main/projekt/transportfabrik.md).

## Struktur

| Projekt | Innehåll |
|---|---|
| `src/Fabrik.Core` | All logik. `netstandard2.1` och C# 9 så att Unity kan använda det. Ingen `Console` här. |
| `src/Fabrik.Konsol` | Konsolprogrammet. Visar simuleringen och tar emot kommandon. |
| `tests/Fabrik.Tester` | xUnit-tester mot Core. |

## Dokumentation

| Fil | Innehåll |
|---|---|
| [docs/BESLUT.md](docs/BESLUT.md) | Designbeslut: mönster, signal, bortvalt alternativ, när det vore overkill |
| [docs/FELSOKNING.md](docs/FELSOKNING.md) | Fel jag jagat: Förstå, Bryt ner, Hypotes, Pröva, Omvärdera |

## Köra

```bash
dotnet run --project src/Fabrik.Konsol
```

```bash
dotnet test
```
