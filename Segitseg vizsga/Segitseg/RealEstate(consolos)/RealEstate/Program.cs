using RealEstate;

var ads = Ad.LoadFromCsv("realestates.json");

var avgArea = ads.Where(a => a.Floors==0).Average(a => a.Area);
Console.WriteLine($"1. A földszinti ingatlanok átlagos alapterülete: {avgArea:f2} m2");


var coordinate = "47.4164220114023,19.066342425796986";
var closest = ads.Where(a=>a.FreeOfCharge).MinBy(a => a.DistanceTo(coordinate));

Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai");
Console.WriteLine($"\t Eladó neve: {closest.Seller.Name}");
Console.WriteLine($"\t Eladó telefonja: {closest.Seller.Phone}");
Console.WriteLine($"\t Alapterület: {closest.Area}");
Console.WriteLine($"\t Szobák száma: {closest.Rooms}");