/*
 * Name: Dalton Carr
 * Course: CSCI 1250-002
 * Date: 10/14/2026
 * Description: Calculates the fuel, food, and work hours behind one road trip.
 */

const int slicesPerPizza = 8;
const double taxRate = 0.18;

// Part 1: The Trip
Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("");
Console.WriteLine("Round trip miles:");
int milesForTheTrip = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Miles per gallon:");
int milesPerGallon = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Price per gallon:");
double gasPrice = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("How many pizzas:");
int numberOfPizzas = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Price per pizza:");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());

// Part 1 calculations
double fuelCost = FuelCost(milesForTheTrip, milesPerGallon, gasPrice);
double totalPizzaCost = numberOfPizzas * pizzaPrice;
double tripTotal = fuelCost + totalPizzaCost;

Console.WriteLine();
Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + totalPizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));

// Part 2: The Group
Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("");
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

double numberOfPeople = names.Length;
double slicesPerPerson = numberOfPizzas * slicesPerPizza / numberOfPeople;
double costPerPerson = tripTotal / numberOfPeople;

Console.WriteLine();
Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices each: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));

// Part 3: Who Works How Long
Console.WriteLine();
Console.WriteLine("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePayPerHour = takeHomePay / hoursWorked[i];
    double hoursNeededToWork = HoursToCover(costPerPerson, takeHomePayPerHour);

    Console.WriteLine(
        names[i] + ": takes home " +
        takeHomePay.ToString("C") +
        " for " + hoursWorked[i].ToString("F0") +
        " hours, " + takeHomePayPerHour.ToString("C") +
        " per hour, must work " +
        hoursNeededToWork.ToString("F2") + " hours");

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;
    longest = Math.Max(longest, hoursNeededToWork);
}

Console.WriteLine();
Console.WriteLine("Total hours worked: " + totalHours.ToString("F0"));
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));

// Methods
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    return grossPay * (1 - taxRate);
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}
