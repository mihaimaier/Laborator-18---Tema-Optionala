using Laborator_18___Tema_Optionala.Models;
using Laborator_18___Tema_Optionala.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Laborator_18___Tema_Optionala
{
    internal class DataAccessLayer
    {
        private static DataAccessLayer instance = null;

        public static DataAccessLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessLayer();
                }
                return instance;
            }
        }
        private DataAccessLayer()
        {
        }

        // Adaugare Vehicul
        public Vehicle AddVehicle(string name, int numberKeys)
        {
            using var ctx = new AutoShopDbContext();
            var newVehicle = new Vehicle { Name = name, KeyNumber = numberKeys };
            ctx.Vehicles.Add(newVehicle);
            ctx.SaveChanges();
            return newVehicle;
        }
        // Adaugare Producator
        public Manufacturer AddManufacturer(string name, string address)
        {
            using var ctx = new AutoShopDbContext();
            var newManufacturer = new Manufacturer { Name = name, Address = address };
            ctx.Manufacturers.Add(newManufacturer);
            ctx.SaveChanges();
            return newManufacturer;
        }
        //Adaugare cheie unui vehicul
        public Key AddKeyForVehicle(int keyId)
        {
            using var ctx = new AutoShopDbContext();

            if (!ctx.Keys.Any(p => p.Id == keyId))
            {
                throw new NotFoundException($"The key {keyId} does not exist in the system!!!");
            }
            Console.Clear();

            var newKeyVehicle = new Key { Barcode = Guid.NewGuid(), Vehicles = keyId };
            ctx.Vehicles.Add(newKeyVehicle);
            ctx.SaveChanges();
            return newKeyVehicle;
        }
        //Inlocuire carte tehnica
        public Manual ChangeManual(int manualId, int cylinderCapacity, int manufactureYear, string chassisNumber)
        {
            using var ctx = new AutoShopDbContext();

            var manual = ctx.Manuals.FirstOrDefault(p => p.Id == manualId);

            if (manual == null)
            {
                throw new NotFoundException($"The manual {manualId} does not exist in the system!!!");
            }
            manual.CylinderCapacity = cylinderCapacity;
            manual.ManufactureYear = manufactureYear;
            manual.ChassisNumber = chassisNumber;
            ctx.SaveChanges();
            return manual;
        }
        // Sterge Autovehiculul
        public Vehicle DeleteVehicle(int vehicleId)
        {
            using var ctx = new AutoShopDbContext();
            if(!ctx.Vehicles.Any(p => p.Id == vehicleId))
            {
                throw new NotFoundException($"The Vehicle {vehicleId} does not exist!!!");
            }
            var vehicle = ctx.Vehicles.Include(k => k.Keys).Include(m => m.Manuals).First(p => p.Id == vehicleId);
            ctx.Remove(vehicle);
            ctx.SaveChanges();
            return vehicle;
        }
        // Sterge Producatorul
        public Manufacturer DeleteManufacturer(int manufactureId)
        {
            using var ctx = new AutoShopDbContext();
            if (!ctx.Manufacturers.Any(p => p.Id == manufactureId))
            {
                throw new NotFoundException($"The Manufacturer {manufactureId} does not exist!!!");
            }
            var manufacturer = ctx.Manufacturers.Include(n => n.Name).Include(a => a.Address).First(p =>p.Id == manufactureId);
            ctx.Remove(manufacturer);
            ctx.SaveChanges();
            return manufacturer;
        }
        // Sterge cheie
        public Key DeleteKey(int keyId)
        {
            using var ctx = new AutoShopDbContext();
            if (!ctx.Keys.Any(p => p.Id == keyId))
            {
                throw new NotFoundException($"The Key {keyId} does not exist!!!");
            }
            var deleteKey = ctx.Keys.Include(n => n.Barcode).Include(v => v.Vehicles).First(p => p.Id == keyId);
            ctx.Keys.Remove(deleteKey);
            ctx.SaveChanges();
            return deleteKey;
        }
    }
}