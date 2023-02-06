using AutoDabiServiceAPI.Models;
using System;
using System.Linq;

namespace AutoDabiServiceAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            SeedCarDamageParts(context);

            SeedCarDamageTypes(context);

            SeedCars(context);
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return; // DB has been seeded
            }

            var cars = new Car[]
            {
                new Car { Number = "WU8186", Brand = "HIUNDAY", Model = "I30", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2021 },
                new Car { Number = "WU2081L", Brand = "DACIA", Model = "DOKKER", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WU2083L", Brand = "DACIA", Model = "DOKKER", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WD0788N", Brand = "FIAT", Model = "TIPO", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WD1223N", Brand = "FIAT", Model = "TIPO", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WU6817L", Brand = "TOYOTA", Model = "CAMRY", FuelType = "PB/HYB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WU3779L", Brand = "RENAULT", Model = "TRAFIC", FuelType = "ON", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WU0940L", Brand = "CITROEN", Model = "JAMPER", FuelType = "ON", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WU8764K", Brand = "RENAULT", Model = "MASTER", FuelType = "ON", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WD6096N", Brand = "NISSAN", Model = "QASQHAI", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WE006UX", Brand = "PEGOUT", Model = "PARTNER", FuelType = "ON", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2017 },
                new Car { Number = "WI510JY", Brand = "SKODA", Model = "OCTAVIA", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WI912JX", Brand = "SKODA", Model = "OCTAVIA", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
                new Car { Number = "WF9287T", Brand = "VOLKSWAGEN ", Model = "TIGUAN", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WU7230M", Brand = "BMW", Model = "318 GRAN TURISMO", FuelType = "ON", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WT2129A", Brand = "NISSAN", Model = "QASQHAI", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WT2131A", Brand = "NISSAN", Model = "QASQHAI", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2019 },
                new Car { Number = "WU1585N", Brand = "FIAT", Model = "TIPO", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2021 },
                new Car { Number = "WU1584N", Brand = "FIAT", Model = "TIPO", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2021 },
                new Car { Number = "WU1583N", Brand = "FIAT", Model = "TIPO", FuelType = "PB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2021 },
                new Car { Number = "WU2664N", Brand = "TOYOTA", Model = "CAMRY", FuelType = "PB/HYB", FuelContent = 0.5, Mileage = 0, Available = true, CarDamages = null, GearBoxType = "Manualna", Year = 2020 },
            };

            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }

            context.SaveChanges();
        }

        private static void SeedCarDamageParts(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CarDamageParts.Any())
            {
                return; // DB has been seeded
            }

            var carDamageParts = new CarDamagePart[]
            {
                new CarDamagePart{ Name="Drzwi przód lewe", Code="DOOR_FRONT_LEFT"},
                new CarDamagePart{ Name= "Drzwi przód prawe", Code="DOOR_FRONT_RIGHT"},
                new CarDamagePart{ Name= "Drzwi tył lewe", Code="DOOR_BACK_LEFT"},
                new CarDamagePart{ Name= "Drzwi tył prawe", Code="DOOR_BACK_RIGHT"},
                new CarDamagePart{ Name= "Maska", Code="HOOD"},
                new CarDamagePart{ Name= "Bagażnik", Code="TRUNK"},
                new CarDamagePart{ Name= "Szyba przód", Code="WINDOW_FRONT"},
                new CarDamagePart{ Name= "Szyba tył", Code="WINDOW_BACK"},
                new CarDamagePart{ Name= "Szyba przód lewa", Code="WINDOW_FRONT_LEFT"},
                new CarDamagePart{ Name= "Szyba przód prawa", Code="WINDOW_FRONT_RIGHT"},
                new CarDamagePart{ Name= "Szyba tył lewa", Code="WINDOW_BACK_LEFT"},
                new CarDamagePart{ Name= "Szyba tył prawa", Code="WINDOW_BACK_RIGHT"},
                new CarDamagePart{ Name= "Dach", Code="ROOF"},
                new CarDamagePart{ Name= "Zderzak przedni", Code="FRONT_BUMPER"},
                new CarDamagePart{ Name= "Zderzak tylny", Code="REAR_BUMPER"},
                new CarDamagePart{ Name= "Błotnik przód lewy", Code="FENDER_FRONT_LEFT"},
                new CarDamagePart{ Name= "Błotnik przód prawy", Code="FENDER_FRONT_RIGHT"},
                new CarDamagePart{ Name= "Błotnik tył lewy", Code="FENDER_BACK_LEFT"},
                new CarDamagePart{ Name= "Błotnik tył prawy", Code="FENDER_BACK_RIGHT"},
                new CarDamagePart{ Name= "Lampa przód lewa", Code="LAMP_FRONT_LEFT"},
                new CarDamagePart{ Name= "Lampa przód prawa", Code="LAMP_FRONT_RIGHT"},
                new CarDamagePart{ Name= "Lampa tył lewa", Code="LAMP_BACK_LEFT"},
                new CarDamagePart{ Name= "Lampa tył prawa", Code="LAMP_BACK_RIGHT"},
                new CarDamagePart{ Name= "Wnętrze", Code="INTERIOR"},
                new CarDamagePart{ Name= "Próg lewy", Code="THRESHOLD_LEFT"},
                new CarDamagePart{ Name= "Próg prawy", Code="THRESHOLD_RIGHT"},
            };

            foreach (CarDamagePart carDamagePart in carDamageParts)
            {
                context.CarDamageParts.Add(carDamagePart);
            }

            context.SaveChanges();
        }

        private static void SeedCarDamageTypes(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CarDamageTypes.Any())
            {
                return; // DB has been seeded
            }

            var carDamageTypes = new CarDamageType[]
            {
                new CarDamageType{ Name="Rysa lub otarcie", Code="SCRATCH_OR_RUB"},
                new CarDamageType{ Name="Wgniecenie", Code="DENT"},
                new CarDamageType{ Name="Pęknięcie", Code="CRACK"},
                new CarDamageType{ Name="Odprysk", Code="CHIP"}
            };

            foreach (var carDamageType in carDamageTypes)
            {
                context.CarDamageTypes.Add(carDamageType);
            }

            context.SaveChanges();
        }


    }
}
