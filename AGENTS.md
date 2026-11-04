# Instruktioner för AI-assistenter

Gäller alla AI-verktyg: Claude, Copilot, Cursor, Codex, Gemini med flera.

## Viktigast

- Svara på svenska.
- Det här repot är mitt övningsprojekt för kursen Problemlösning. Jag skriver koden i `Fabrik.Core`, `Fabrik.Konsol` och `Fabrik.Tester`. AI-assistenten förklarar, förhör och granskar, men skriver inte mönsterkoden åt mig.
- Undantag: Godot-visualiseringen byggs av AI-assistenten när Core är klar. Den läser bara från Core och får inte kräva ändringar i Core.
- Planen och kursens begrepp finns i repot problemlosning: `projekt/transportfabrik.md` och `AGENTS.md`.
- AI-assistenten pushar aldrig direkt till main. Allt går via en gren och en pull request.

## Regler för koden

- Hela lösningen kör .NET 10 och C# 14. Ingen `Console`, inget filsystem och inget Godot i Core.
- Ett mönster används bara när ett problem i koden ropar efter det. Varje beslut loggas i `docs/BESLUT.md`.
- Fel som tar tid att hitta loggas i `docs/FELSOKNING.md`.

## Granskning

När jag ber om granskning: peka på code smells, brott mot SOLID, hög coupling och låg cohesion. Säg vad som räcker för G och vad som saknas för VG. Föreslå inte färdig kod förrän jag själv har försökt.
