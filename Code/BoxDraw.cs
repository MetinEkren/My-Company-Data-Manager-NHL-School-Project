namespace DataBaseProject.Code;

public class BoxDraw
{
    public static void DrawBox(string[] lines, string titel = null)
    {
        // Zoek de langste line in de array en sla de lengte op als innerWidth
        int innerWidth = lines.Max(line => line.Length);
        
        // Als er een titel is, controleer of de titel breder is dan de langste regel
        if (titel != null)
        {
            // Gebruik de grootste waarde tussen de innerWidth en de lengte van de titel
            innerWidth = Math.Max(innerWidth, titel.Length);
        }
        
        // Maak een horizontale lijn van '═' tekens, +2 voor de spatie aan elke kant
        string horizontal = new string('═', innerWidth + 2);
        
        // Maak de tussenlijn met '╠' en '╣' aan de uiteinden
        string divider    = "╠" + horizontal + "╣";

        // Controleer of er een titel is meegegeven
        if (titel != null)
        {
            // Teken de bovenste rand met '╔' en '╗' als hoeken
            Console.WriteLine("╔" + horizontal + "╗");

            // Bereken hoeveel spaties er over zijn naast de titel
            int totalPadding = innerWidth - titel.Length;
            
            // Verdeel de spaties gelijk over links en rechts voor centrering
            int padLeft      = totalPadding / 2;
            int padRight     = totalPadding - padLeft;

            // Teken de titelregel gecentreerd met '║' aan beide kanten
            Console.WriteLine("║ " + new string(' ', padLeft) + titel + new string(' ', padRight) + " ║");
            
            // Teken de tussenlijn onder de titel
            Console.WriteLine(divider);
        }
        else
        {
            // Geen titel, teken alleen de bovenste rand
            Console.WriteLine("╔" + horizontal + "╗");
        }

        // Loop door elke regel in de array
        foreach (var line in lines)
        {
            // Teken de regel met '║' aan beide kanten, vul korte regels aan met spaties rechts
            Console.WriteLine("║ " + line.PadRight(innerWidth) + " ║");
        }

        // Teken de onderste rand met '╚' en '╝' als hoeken
        Console.WriteLine("╚" + horizontal + "╝");
    }
}