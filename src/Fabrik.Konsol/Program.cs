// Konsolen är bara ett UI. All logik ligger i Fabrik.Core.
Console.WriteLine("Transportfabriken startar.");

var sim = new HandleTick();

for (int i = 1; i <= 15; i++)
{
    sim.Tick();
    Console.WriteLine($"Tick {i} klar");
}