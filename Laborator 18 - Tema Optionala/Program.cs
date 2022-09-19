using Laborator_18___Tema_Optionala.Models;

ResetDb();

static void ResetDb()
{
    using var ctx = new AutoShopDbContext();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var manufacturer = new Manufacturer
    {
        Name = "BMW",
        Address = "BMW Headquarters, Petuelring 130, 80809 München, Germany"
    };

    var vehicle1 = new Vehicle
    {
        Name = "Series 3",
        Manufacturers = manufacturer,
        Keys = new Key
        {
            Barcode = Guid.NewGuid(),
        },
        KeyNumber = 3,
        Manuals = new Manual
        {
            CylinderCapacity = 4,
            ManufactureYear = 2022,
            ChassisNumber = "320",
        }
    };
    var vehicle2 = new Vehicle
    {
        Name = "Series 5",
        Manufacturers = manufacturer,
        Keys = new Key
        {
            Barcode = Guid.NewGuid(),
        },
        KeyNumber = 10,
        Manuals = new Manual
        {
            CylinderCapacity = 6,
            ManufactureYear = 2021,
            ChassisNumber = "5",
        }
    };
    var vehicle3 = new Vehicle
    {
        Name = "Series 1",
        Manufacturers = manufacturer,
        Keys = new Key
        {
            Barcode = Guid.NewGuid(),
        },
        KeyNumber = 12,
        Manuals = new Manual
        {
            CylinderCapacity = 4,
            ManufactureYear = 2023,
            ChassisNumber = "120",
        }
    };
    var vehicle4 = new Vehicle
    {
        Name = "Series 7",
        Manufacturers = manufacturer,
        Keys = new Key
        {
            Barcode = Guid.NewGuid(),
        },
        KeyNumber = 7,
        Manuals = new Manual
        {
            CylinderCapacity = 6,
            ManufactureYear = 2020,
            ChassisNumber = "760",
        }
    };
    var vehicle5 = new Vehicle
    {
        Name = "Series 4",
        Manufacturers = manufacturer,
        Keys = new Key
        {
            Barcode = Guid.NewGuid(),
        },
        KeyNumber = 8,
        Manuals = new Manual
        {
            CylinderCapacity = 4,
            ManufactureYear = 2019,
            ChassisNumber = "430",
        }
    };
    ctx.Manufacturers.Add(manufacturer);
    ctx.Vehicles.Add(vehicle1);
    ctx.Vehicles.Add(vehicle2);
    ctx.Vehicles.Add(vehicle3);
    ctx.Vehicles.Add(vehicle4);
    ctx.Vehicles.Add(vehicle5);
    ctx.SaveChanges();
}