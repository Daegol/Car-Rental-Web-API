using AutoDabiServiceAPI.Models;
using AutoDabiServiceAPI.Models.Protocol;
using System.Collections.Generic;
using System.Data;

namespace AutoDabiServiceAPI.Mapper
{
    public static class ReportMapper
    {
        public static DataTable ContractInfoMap(string contractId, string protocolId, string date)
        {
            var result = new DataTable();
            result.Columns.Add("ContractId");
            result.Columns.Add("ProtocolId");
            result.Columns.Add("Date");

            var newRow = result.NewRow();
            newRow["ContractId"] = contractId;
            newRow["ProtocolId"] = protocolId;
            newRow["Date"] = date;
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable TenantPrivateMap(TenantPrivate tenant, Hirer hirer)
        {
            var result = new DataTable();
            result.Columns.Add("Tenant");
            result.Columns.Add("Address");
            result.Columns.Add("NipOrPesel");
            result.Columns.Add("RegonOrDocumentId");
            result.Columns.Add("Phone");
            result.Columns.Add("Email");
            result.Columns.Add("FullName");
            result.Columns.Add("HirerFullName");

            var newRow = result.NewRow();
            newRow["Tenant"] = IsNotNull(tenant.Name) + " " + IsNotNull(tenant.LastName);
            newRow["Address"] = IsNotNull(tenant.CorrespondenceAddresss);
            newRow["NipOrPesel"] = IsNotNull(tenant.Pesel);
            newRow["RegonOrDocumentId"] = IsNotNull(tenant.IdNumber);
            newRow["Phone"] = IsNotNull(tenant.PhoneNumber);
            newRow["Email"] = IsNotNull(tenant.Email);
            newRow["FullName"] = IsNotNull(tenant.Name) + " " + IsNotNull(tenant.LastName);
            newRow["HirerFullName"] = IsNotNull(hirer.Name) + " " + IsNotNull(hirer.LastName);
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable TenantBusinesssMap(TenantBusiness tenant, Hirer hirer)
        {
            var result = new DataTable();
            result.Columns.Add("Tenant");
            result.Columns.Add("Address");
            result.Columns.Add("NipOrPesel");
            result.Columns.Add("RegonOrDocumentId");
            result.Columns.Add("Phone");
            result.Columns.Add("Email");
            result.Columns.Add("FullName");
            result.Columns.Add("HirerFullName");

            var newRow = result.NewRow();
            newRow["Tenant"] = IsNotNull(tenant.Name);
            newRow["Address"] = IsNotNull(tenant.CorrespondenceAddresss);
            newRow["NipOrPesel"] = IsNotNull(tenant.Nip);
            newRow["RegonOrDocumentId"] = IsNotNull(tenant.Regon);
            newRow["Phone"] = IsNotNull(tenant.PhoneNumber);
            newRow["Email"] = IsNotNull(tenant.Email);
            newRow["FullName"] = IsNotNull(tenant.RepresentedBy);
            newRow["HirerFullName"] = IsNotNull(hirer.Name) + " " + IsNotNull(hirer.LastName);
            result.Rows.Add(newRow);

            return result;
        }

        //TODO
        public static DataTable AdditionalService()
        {
            var result = new DataTable();
            result.Columns.Add("Name");
            result.Columns.Add("NetPLN");
            result.Columns.Add("GrossPLN");
            result.Columns.Add("Unit");
            result.Columns.Add("Comments");

            var newRow = result.NewRow();
            newRow["Name"] = " ";
            newRow["NetPLN"] = " ";
            newRow["GrossPLN"] = " ";
            newRow["Unit"] = " ";
            newRow["Comments"] = " ";
            result.Rows.Add(newRow);

            return result;
        }
        //TODO
        public static DataTable LeasePeriod(string date, string hour)
        {
            var result = new DataTable();
            result.Columns.Add("DateFrom");
            result.Columns.Add("TimeFrom");
            result.Columns.Add("DateTo");
            result.Columns.Add("TimeTo");

            var newRow = result.NewRow();
            newRow["DateFrom"] = date;
            newRow["TimeFrom"] = hour;
            newRow["DateTo"] = " ";
            newRow["TimeTo"] = " ";
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable IssuedItem()
        {
            var result = new DataTable();
            result.Columns.Add("Keys");
            result.Columns.Add("Oc");
            result.Columns.Add("RegisterNr");

            var newRow = result.NewRow();
            newRow["RegisterNr"] = "-";
            newRow["Oc"] = "-";
            newRow["Keys"] = "1";
            result.Rows.Add(newRow);

            return result;
        }
        //TODO
        public static DataTable LeaseRent()
        {
            var result = new DataTable();
            result.Columns.Add("NetPerDay");
            result.Columns.Add("GrossPerDay");
            result.Columns.Add("KilometerLimit");
            result.Columns.Add("NetPerKilometer");
            result.Columns.Add("GrossPerKilometer");
            result.Columns.Add("NetInAc");
            result.Columns.Add("GrossInAc");

            var newRow = result.NewRow();
            newRow["NetPerDay"] = "Wg. kontraktu";
            newRow["GrossPerDay"] = " ";
            newRow["KilometerLimit"] = " ";
            newRow["NetPerKilometer"] = " ";
            newRow["GrossPerKilometer"] = " ";
            newRow["NetInAc"] = " ";
            newRow["GrossInAc"] = " ";
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable LeaseSubject(Car car)
        {
            var result = new DataTable();
            result.Columns.Add("BrandModelFuel");
            result.Columns.Add("RegisterNumber");

            var newRow = result.NewRow();
            newRow["BrandModelFuel"] = IsNotNull(car.Brand) + "/" + IsNotNull(car.Model) + "/" + IsNotNull(car.FuelType);
            newRow["RegisterNumber"] = IsNotNull(car.Number);
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable DriverInfo(List<Driver> drivers)
        {
            var result = new DataTable();
            result.Columns.Add("No");
            result.Columns.Add("FullName");
            result.Columns.Add("CarLicenseId");
            result.Columns.Add("DocumentId");
            var no = 1;
            foreach (var driver in drivers)
            {
                var newRow = result.NewRow();
                newRow["No"] = no;
                newRow["FullName"] = IsNotNull(driver.Name) + " " + IsNotNull(driver.LastName);
                newRow["CarLicenseId"] = IsNotNull(driver.DrivingLicenseNumber);
                newRow["DocumentId"] = IsNotNull(driver.IdNumber);
                result.Rows.Add(newRow);
                no++;
            }
            return result;
        }

        public static DataTable DriverSignatures(string date)
        {
            var result = new DataTable();
            result.Columns.Add("DateAndPlace");
            result.Columns.Add("Signature");
            var newRow = result.NewRow();
            newRow["DateAndPlace"] = IsNotNull(date);
            newRow["Signature"] = "";
            result.Rows.Add(newRow);

            return result;
        }

        //TODO: add gearbox type
        public static DataTable Car(Car car)
        {
            var result = new DataTable();
            result.Columns.Add("MarkAndModel");
            result.Columns.Add("RegisterNr");
            result.Columns.Add("FuelType");
            result.Columns.Add("GearboxType");
            var newRow = result.NewRow();
            newRow["MarkAndModel"] = IsNotNull(car.Brand) + " " + IsNotNull(car.Model);
            newRow["RegisterNr"] = IsNotNull(car.Number);
            newRow["FuelType"] = IsNotNull(car.FuelType);
            newRow["GearboxType"] = car.GearBoxType;
            result.Rows.Add(newRow);
            return result;
        }

        public static DataTable ProtocolRelease(Protocol protocol)
        {
            var result = new DataTable();
            result.Columns.Add("ReleasePlace");
            result.Columns.Add("ReleaseUser");
            result.Columns.Add("ReleaseDate");
            result.Columns.Add("ReleaseTime");
            result.Columns.Add("ReleaseMaxFuel");
            result.Columns.Add("ReleaseReadFuel");
            result.Columns.Add("ReleaseLevelFuel");
            result.Columns.Add("ReleaseInsideClean");
            result.Columns.Add("ReleaseInsideDirty");
            result.Columns.Add("ReleaseOutsideClean");
            result.Columns.Add("ReleaseOutsideDirty");

            result.Columns.Add("ReturnPlace");
            result.Columns.Add("ReturnUser");
            result.Columns.Add("ReturnDate");
            result.Columns.Add("ReturnTime");
            result.Columns.Add("ReturnMaxFuel");
            result.Columns.Add("ReturnReadFuel");
            result.Columns.Add("ReturnLevelFuel");
            result.Columns.Add("ReturnInsideClean");
            result.Columns.Add("ReturnInsideDirty");
            result.Columns.Add("ReturnOutsideClean");
            result.Columns.Add("ReturnOutsideDirty");

            var newRow = result.NewRow();
            newRow["ReleasePlace"] = protocol.Place;
            newRow["ReleaseUser"] = protocol.User;
            newRow["ReleaseDate"] = protocol.Date;
            newRow["ReleaseTime"] = protocol.Time;
            newRow["ReleaseMaxFuel"] = "1.0";
            newRow["ReleaseReadFuel"] = protocol.Car.FuelContent;
            newRow["ReleaseLevelFuel"] = protocol.Car.FuelContent;
            newRow["ReleaseInsideClean"] = protocol.IsClearInside ? "*" : " ";
            newRow["ReleaseInsideDirty"] = protocol.IsClearInside ? " " : "*";
            newRow["ReleaseOutsideClean"] = protocol.IsClearOutside ? "*" : " ";
            newRow["ReleaseOutsideDirty"] = protocol.IsClearOutside ? " " : "*";

            newRow["ReturnPlace"] = " ";
            newRow["ReturnUser"] = " ";
            newRow["ReturnDate"] = " ";
            newRow["ReturnTime"] = " ";
            newRow["ReturnMaxFuel"] = " ";
            newRow["ReturnReadFuel"] = " ";
            newRow["ReturnLevelFuel"] = " ";
            newRow["ReturnInsideClean"] = " ";
            newRow["ReturnInsideDirty"] = " ";
            newRow["ReturnOutsideClean"] = " ";
            newRow["ReturnOutsideDirty"] = " ";
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable ProtocolReturn(Protocol protocol, Protocol returnProtocol)
        {
            var result = new DataTable();
            result.Columns.Add("ReleasePlace");
            result.Columns.Add("ReleaseUser");
            result.Columns.Add("ReleaseDate");
            result.Columns.Add("ReleaseTime");
            result.Columns.Add("ReleaseMaxFuel");
            result.Columns.Add("ReleaseReadFuel");
            result.Columns.Add("ReleaseLevelFuel");
            result.Columns.Add("ReleaseInsideClean");
            result.Columns.Add("ReleaseInsideDirty");
            result.Columns.Add("ReleaseOutsideClean");
            result.Columns.Add("ReleaseOutsideDirty");

            result.Columns.Add("ReturnPlace");
            result.Columns.Add("ReturnUser");
            result.Columns.Add("ReturnDate");
            result.Columns.Add("ReturnTime");
            result.Columns.Add("ReturnMaxFuel");
            result.Columns.Add("ReturnReadFuel");
            result.Columns.Add("ReturnLevelFuel");
            result.Columns.Add("ReturnInsideClean");
            result.Columns.Add("ReturnInsideDirty");
            result.Columns.Add("ReturnOutsideClean");
            result.Columns.Add("ReturnOutsideDirty");

            var newRow = result.NewRow();
            newRow["ReleasePlace"] = protocol.Place;
            newRow["ReleaseUser"] = protocol.User;
            newRow["ReleaseDate"] = protocol.Date;
            newRow["ReleaseTime"] = protocol.Time;
            newRow["ReleaseMaxFuel"] = "1.0";
            newRow["ReleaseReadFuel"] = protocol.Car.FuelContent;
            newRow["ReleaseLevelFuel"] = protocol.Car.FuelContent;
            newRow["ReleaseInsideClean"] = protocol.IsClearInside ? "*" : " ";
            newRow["ReleaseInsideDirty"] = protocol.IsClearInside ? " " : "*";
            newRow["ReleaseOutsideClean"] = protocol.IsClearOutside ? "*" : " ";
            newRow["ReleaseOutsideDirty"] = protocol.IsClearOutside ? " " : "*";

            newRow["ReturnPlace"] = returnProtocol.Place;
            newRow["ReturnUser"] = returnProtocol.User;
            newRow["ReturnDate"] = returnProtocol.Date;
            newRow["ReturnTime"] = returnProtocol.Time;
            newRow["ReturnMaxFuel"] = "1.0";
            newRow["ReturnReadFuel"] = returnProtocol.Car.FuelContent;
            newRow["ReturnLevelFuel"] = returnProtocol.Car.FuelContent;
            newRow["ReturnInsideClean"] = returnProtocol.IsClearInside ? "*" : " ";
            newRow["ReturnInsideDirty"] = returnProtocol.IsClearInside ? " " : "*";
            newRow["ReturnOutsideClean"] = returnProtocol.IsClearInside ? " " : "*";
            newRow["ReturnOutsideDirty"] = returnProtocol.IsClearInside ? " " : "*";
            result.Rows.Add(newRow);

            return result;
        }

        public static DataTable HandedOverWith(HandedOverWithCar handed)
        {
            var result = new DataTable();

            result.Columns.Add("ReleaseRegistrationCertificate");
            result.Columns.Add("ReleaseOc");
            result.Columns.Add("ReleaseRadio");
            result.Columns.Add("ReleaseHubcup");
            result.Columns.Add("ReleaseTireFront");
            result.Columns.Add("ReleaseTireBack");
            result.Columns.Add("ReleaseSpareTires");
            result.Columns.Add("ReleaseFireExtinguisher");
            result.Columns.Add("ReleaseTriangle");
            result.Columns.Add("ReleaseJack");
            result.Columns.Add("ReleaseOthers");
            result.Columns.Add("ReleaseAnten");

            result.Columns.Add("ReturnRegistrationCertificate");
            result.Columns.Add("ReturnOc");
            result.Columns.Add("ReturnRadio");
            result.Columns.Add("ReturnHubcup");
            result.Columns.Add("ReturnTireFront");
            result.Columns.Add("ReturnTireBack");
            result.Columns.Add("ReturnSpareTires");
            result.Columns.Add("ReturnFireExtinguisher");
            result.Columns.Add("ReturnTriangle");
            result.Columns.Add("ReturnJack");
            result.Columns.Add("ReturnOthers");
            result.Columns.Add("ReturnAnten");

            var newRow = result.NewRow();

            newRow["ReleaseRegistrationCertificate"] = handed.RegistrationCertificate? "*" : " "; 
            newRow["ReleaseOc"] = handed.Oc ? "*" : " ";
            newRow["ReleaseRadio"] = handed.Radio ? "*" : " ";
            newRow["ReleaseHubcup"] = handed.Hubcup ? "*" : " ";
            newRow["ReleaseTireFront"] = handed.TireFront ? "*" : " ";
            newRow["ReleaseTireBack"] = handed.TireBack ? "*" : " ";
            newRow["ReleaseSpareTires"] = handed.SpareTires ? "*" : " ";
            newRow["ReleaseFireExtinguisher"] = handed.FireExtinguisher ? "*" : " ";
            newRow["ReleaseTriangle"] = handed.Triangle ? "*" : " ";
            newRow["ReleaseJack"] = handed.Jack ? "*" : " ";
            newRow["ReleaseOthers"] = handed.Others ? "*" : " ";
            newRow["ReleaseAnten"] = handed.Anten ? "*" : " ";

            newRow["ReturnRegistrationCertificate"] = " ";
            newRow["ReturnOc"] = " ";
            newRow["ReturnRadio"] = " ";
            newRow["ReturnHubcup"] = " ";
            newRow["ReturnTireFront"] = " ";
            newRow["ReturnTireBack"] = " ";
            newRow["ReturnSpareTires"] = " ";
            newRow["ReturnFireExtinguisher"] = " ";
            newRow["ReturnTriangle"] = " ";
            newRow["ReturnJack"] = " ";
            newRow["ReturnOthers"] = " ";
            newRow["ReturnAnten"] = " ";
            result.Rows.Add(newRow);
            return result;
        }

        public static DataTable ReturnHandedOverWith(HandedOverWithCar handed, HandedOverWithCar handedReturn)
        {
            var result = new DataTable();

            result.Columns.Add("ReleaseRegistrationCertificate");
            result.Columns.Add("ReleaseOc");
            result.Columns.Add("ReleaseRadio");
            result.Columns.Add("ReleaseHubcup");
            result.Columns.Add("ReleaseTireFront");
            result.Columns.Add("ReleaseTireBack");
            result.Columns.Add("ReleaseSpareTires");
            result.Columns.Add("ReleaseFireExtinguisher");
            result.Columns.Add("ReleaseTriangle");
            result.Columns.Add("ReleaseJack");
            result.Columns.Add("ReleaseOthers");
            result.Columns.Add("ReleaseAnten");

            result.Columns.Add("ReturnRegistrationCertificate");
            result.Columns.Add("ReturnOc");
            result.Columns.Add("ReturnRadio");
            result.Columns.Add("ReturnHubcup");
            result.Columns.Add("ReturnTireFront");
            result.Columns.Add("ReturnTireBack");
            result.Columns.Add("ReturnSpareTires");
            result.Columns.Add("ReturnFireExtinguisher");
            result.Columns.Add("ReturnTriangle");
            result.Columns.Add("ReturnJack");
            result.Columns.Add("ReturnOthers");
            result.Columns.Add("ReturnAnten");

            var newRow = result.NewRow();

            newRow["ReleaseRegistrationCertificate"] = handed.RegistrationCertificate ? "*" : " ";
            newRow["ReleaseOc"] = handed.Oc ? "*" : " ";
            newRow["ReleaseRadio"] = handed.Radio ? "*" : " ";
            newRow["ReleaseHubcup"] = handed.Hubcup ? "*" : " ";
            newRow["ReleaseTireFront"] = handed.TireFront ? "*" : " ";
            newRow["ReleaseTireBack"] = handed.TireBack ? "*" : " ";
            newRow["ReleaseSpareTires"] = handed.SpareTires ? "*" : " ";
            newRow["ReleaseFireExtinguisher"] = handed.FireExtinguisher ? "*" : " ";
            newRow["ReleaseTriangle"] = handed.Triangle ? "*" : " ";
            newRow["ReleaseJack"] = handed.Jack ? "*" : " ";
            newRow["ReleaseOthers"] = handed.Others ? "*" : " ";
            newRow["ReleaseAnten"] = handed.Anten ? "*" : " ";

            newRow["ReturnRegistrationCertificate"] = handedReturn.RegistrationCertificate ? "*" : " ";
            newRow["ReturnOc"] = handedReturn.Oc ? "*" : " ";
            newRow["ReturnRadio"] = handedReturn.Radio ? "*" : " ";
            newRow["ReturnHubcup"] = handedReturn.Hubcup ? "*" : " ";
            newRow["ReturnTireFront"] = handedReturn.TireFront ? "*" : " ";
            newRow["ReturnTireBack"] = handedReturn.TireBack ? "*" : " ";
            newRow["ReturnSpareTires"] = handedReturn.SpareTires ? "*" : " ";
            newRow["ReturnFireExtinguisher"] = handedReturn.FireExtinguisher ? "*" : " ";
            newRow["ReturnTriangle"] = handedReturn.Triangle ? "*" : " ";
            newRow["ReturnJack"] = handedReturn.Jack ? "*" : " ";
            newRow["ReturnOthers"] = handedReturn.Others ? "*" : " ";
            newRow["ReturnAnten"] = handedReturn.Anten ? "*" : " ";
            result.Rows.Add(newRow);
            return result;
        }

        public static DataTable Damage(List<CarDamage> damages)
        {
            var result = new DataTable();
            result.Columns.Add("Symbol");
            result.Columns.Add("Description");
            foreach(var damage in damages)
            {
                var newRow = result.NewRow();
                newRow["Symbol"] = damage.CarDamageType.Code !=null ? damage.CarDamageType.Code: " ";
                newRow["Description"] = damage.CarDamagePart.Name != null ? damage.CarDamagePart.Name : " " + " : " + damage.Comments != null ? damage.Comments : " ";
                result.Rows.Add(newRow);
            }
            return result;
        }

        //just for table purpose, content doesn't matter
        public static DataTable DamageSignature()
        {
            var result = new DataTable();
            result.Columns.Add("UserSignature");
            result.Columns.Add("HirerSignature");
                var newRow = result.NewRow();
            newRow["UserSignature"] = "PlaceHolder";
            newRow["HirerSignature"] = "PlaceHolder";
            result.Rows.Add(newRow);
            return result;
        }

        private static string IsNotNull(string str)
        {
            return str != null ? str : " ";
        }

    }
}
