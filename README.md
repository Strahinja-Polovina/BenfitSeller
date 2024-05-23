.NET VERSION 8.0

DATABASE - MSSQL

Kako pokrenuti aplikaciju?

Otvoriti aplikaciju u Visual Studio 2022 i pokrenuti je. Potrebno je promeniti ConnectionString u appsettings.json fajlu i prilagoditi ga bazi na racunaru.

Za nastavak rada sa aplikacijom potrebno je migrirati bazu podataka za koju je potrebno pratiti sledece korake:
	
	1. Otvoriti Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)
	2. Izabrati projekat "ApiLibrary" u Package Manager Console
	3. Uneti komandu "Update-Database" i pritisnuti Enter
	
	** OPTIONAL **

	4. Ukoliko migracija nije uspela, potrebno je obrisati folder Migration iz projekta "ApiLibrary"
	5. Ponoviti korak 1 i 2
	6. Uneti komandu "Add-Migration InitialCreate" i pritisnuti Enter
	7. Uneti komandu "Update-Database" i pritisnuti Enter

Kada je baza kreirana pojavice se inicijalni podaci u tabelama. 

Inicijalni korisnik za login je:

EMAIL: "admin@benefitseller.com"
Password: "BenefitSeller"


O aplikaciji:

Korisnici (U ovom slucaju kompanije) imaju razlicite role, autentifikacija i autorizacija se vrsi preko JWT i Refresh tokena.

Inicijalni account je Admin. On ima mogucnost da kreira nove kompanije, benefite i kategorije, kao i da pregleda iste.

Kompanije mogu da upravljaju zaposlenima, kompanijskim benefitima, popustima kod prodavaca, karticama za zaposlene i da iste benefite dodeljuju odredjenim zaposlenima,
odnosno da postavljaju popuste kod prodavaca u zavisnosti od kategorije korisnika. (Inicijalno postoje 'Standard Users', 'Premium Users' i 'Platinum Users')

Svaki zaposleni moze da ima samo jednu karticu.

Placanjem kod kupaca preko rute /api/payment, za svaku transakciju se cuva log u bazi, u tabeli Transactions.


Moguce je koristiti admin account za testiranje gore navedenih stavki, ali je bolje da se koristi sledeci:

EMAIL: "info@techcorp.com",
PASSWORD: "TechCorp"

S ovim accountom (ili bilo kojim drugim) - mozete videti i restrikcije koje postoje za odredjene rute, koje su dozvoljene samo BenefitSelleru.

Primer kartica koje se mogu koristiti:

CardNumber:
1234123412341234
Pin
1234

CardNumber: 
2345234523452345
Pin
2345

CardNumber:
3456345634563456
Pin
3456

CardNumber
4567456745674567
Pin
4567

CardNumber
5678567856785678
Pin
5678

CardNumber
6789678967896789
Pin
6789

CardNumber
7890789078907890
Pin
7890

CardNumber
8901890189018901
Pin
8901

CardNumber
9012901290129012
Pin
9012

Takodje generisani su i sledeci prodavci: id od 1 - 13
Kao i odredjeni Benefiti i Popusti izmedju Kategorija Usera i Prodavca.

Svi gore navedeni podaci se mogu dodavati i brisati u zavisnosti od kompanije koja je ulogovana.

U aplikaciji postoji jos generisanih podataka koji se nalaze na lokaciji ApiLibrary/Data/ApplicationDbContext - modelBuilderi.


Sve transakcije (uspne i neuspesne) se beleze u tabeli Transactions.

Aplikacija se moze testirati preko Swagger UI-a.



NAPOMENA:

APLIKACIJA SE MOZE POKRENUTI I PREKO DRUGIH IDE-A, README JE PISAN PO VISUAL STUDIO 2022.

