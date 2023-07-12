List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// IEnumerable<Eruption> chileFirstEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
// PrintEach(chileFirstEruption, "Chile first eruption");

IEnumerable<Eruption> names = eruptions.OrderBy(e => e.Volcano);
// PrintEach(names, "Volcano names in alphabetical order");

int sum = eruptions.Sum(e => e.ElevationInMeters);
// Console.WriteLine($"Sum of all elevation: {sum}");

bool eruptedIn2000 = eruptions.Any(e => e.Year < 2000);
// Console.WriteLine($"Is there eruptions in 2000's? {eruptedIn2000}");

IEnumerable<Eruption> stratovolcano = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
// PrintEach(stratovolcano, "First three stratovolcanos");

IEnumerable<Eruption> volcanoInNewZealand = eruptions.Where(e => e.Year > 1900 && e.Location == "New Zealand");
// PrintEach(volcanoInNewZealand, "Volcano in New Zealand");

IEnumerable<Eruption> highElevation = eruptions.Where(e => e.ElevationInMeters > 2000);
// PrintEach(highElevation, "Volcano elevations over 2000m");

IEnumerable<Eruption> volcanosStartWithL = eruptions.Where(e => e.Volcano.StartsWith('L'));
// PrintEach(volcanosStartWithL, "Volcanos start with L");
int volcanoStartsWithLCount = eruptions.Where(e => e.Volcano.StartsWith('L')).Count();
// Console.WriteLine($"Count of how many volcanos start with L: {volcanoStartsWithLCount}");

int maxElevation = eruptions.Max(e => e.ElevationInMeters);
// Console.WriteLine($"Max elevation: {maxElevation}");

var nameOfMaxElevation = eruptions.OrderByDescending(e => e.ElevationInMeters).FirstOrDefault();
// Console.WriteLine($"Name of volcano with max elevation: {nameOfMaxElevation}");

var firstChileEruption = eruptions.OrderBy(e => e.Year).Where(e => e.Location == "Chile").FirstOrDefault();
// Console.WriteLine($"First eruption in Chile: {firstChileEruption}");

var hawaiianFirstEruption = eruptions.OrderBy(e => e.Year).Where(e => e.Location == "Hawaiian Is").FirstOrDefault();
// if (hawaiianFirstEruption != null)
// {
//     Console.WriteLine($"Name of the first volcano in the Hawaiian Is: {hawaiianFirstEruption}");
// } else {
//     Console.WriteLine($"No Hawaiian Is Eruption found");

// }

var greenLandVolcano = eruptions.Where(e => e.Location == "Greenland").FirstOrDefault();
// if (greenLandVolcano != null)
// {
//     Console.WriteLine($"Name of the first volcano in the Greenland: {greenLandVolcano}");
// } else {
//     Console.WriteLine($"No Greenland Eruption found");

// }

IEnumerable<Eruption> eruptionsBefore1 = eruptions.Where(e => e.Year < 1000).OrderBy(n => n.Volcano);
// PrintEach(eruptionsBefore, "Volcanos before 1000 CE in alphabetical order");

var eruptionsBefore = eruptions.Where(e => e.Year < 1000).OrderBy(n => n.Volcano);
var volcanoNames = eruptionsBefore.Select(e => e.Volcano);
foreach (var name in volcanoNames)
{
    Console.WriteLine(name);
}



// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
