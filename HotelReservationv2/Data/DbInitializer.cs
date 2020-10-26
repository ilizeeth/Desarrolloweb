using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotelReservationv2.Models;

namespace HotelReservationv2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            if(context.tblCustomer.Any()){
                return;
            }
            context.SaveChanges();

            var customers = new tblCustomers[]
            {
                new tblCustomers { 
                txtCustomerTitle = "Lizzeth Valois Martinez", txtCustomerForenames = "Paola Lizeth", txtCustomerSurnames ="Medina",
                CustomerDOB= DateTime.Parse("1996-07-30"), txtCustomerAddressStreet = "Ramón Gúzman #5",  txtCustomerAddressCountry = "México",
                txtCustomerAddressTown= "Zacatecas", txtCustomerAddressPostalCode = "98000", txtCustomerHomePhone="92-123-322", txtCustomerMobilePhone="492-123-2332", hypCustomerEmail="liz122@hotmail.com" },
            
                new tblCustomers { 
                txtCustomerTitle = "Francisco Rodarte", txtCustomerForenames = "Guadalupe", txtCustomerSurnames ="Reyes",
                CustomerDOB= DateTime.Parse("1990-05-20"), txtCustomerAddressStreet = "San benito #10",  txtCustomerAddressCountry = "México",
                txtCustomerAddressTown= "Guadalajara", txtCustomerAddressPostalCode = "12000", txtCustomerHomePhone="12-123-322", txtCustomerMobilePhone="442-143-1232", hypCustomerEmail="fran@hotmail.com" },

                 new tblCustomers { 
                txtCustomerTitle = "Juana María López", txtCustomerForenames = "Macario", txtCustomerSurnames ="López Rodriguez",
                CustomerDOB= DateTime.Parse("1987-07-10"), txtCustomerAddressStreet = "Madero #5",  txtCustomerAddressCountry = "México",
                txtCustomerAddressTown= "Zacatecas", txtCustomerAddressPostalCode = "98020", txtCustomerHomePhone="92-342-52", txtCustomerMobilePhone="492-345-6789", hypCustomerEmail="maria@hotmail.com" }
            
            };

            foreach(tblCustomers c in customers)
            {
                context.tblCustomer.Add(c);
            }
            context.SaveChanges();

               if(context.tblBooking.Any()){
                return;
            }
            context.SaveChanges();

            var Bookings = new tblBookings[]
            {
                new tblBookings{ingBookingID=1,
                    ingCustomerID = customers.Single(i => i.txtCustomerSurnames == "Medina").IngCutomerID,
                    dteDateBookingMade = DateTime.Parse("2020-10-26"), tmeTimeBookingMade = "14:00 hrs", 
                    dteBookedStartDate = DateTime.Parse("2020-12-16"), dteBookedEndDate = DateTime.Parse("2020-12-26"),
                    dteTotalPaymentDueDate = DateTime.Parse("2020-12-16"),dteTotalPaymentDueAmount = 6783,dteTotalPaymentMadeOn = DateTime.Parse("2020-11-13"), memBookingComments ="Excelente Servicio"
                },

                new tblBookings{ingBookingID=2,
                    ingCustomerID = customers.Single(i => i.txtCustomerTitle == "Francisco").IngCutomerID,
                    dteDateBookingMade = DateTime.Parse("2020-09-16"), tmeTimeBookingMade = "14:00 hrs", 
                    dteBookedStartDate = DateTime.Parse("2020-11-16"), dteBookedEndDate = DateTime.Parse("2020-11-18"),
                    dteTotalPaymentDueDate = DateTime.Parse("2020-11-16"),dteTotalPaymentDueAmount = 2123,dteTotalPaymentMadeOn = DateTime.Parse("2020-10-16"), memBookingComments =""
                },

                new tblBookings{
                    ingBookingID=3,
                    ingCustomerID = customers.Single(i => i.txtCustomerTitle == "Juana").IngCutomerID,
                    dteDateBookingMade = DateTime.Parse("2020-06-03"), tmeTimeBookingMade = "14:00 hrs", 
                    dteBookedStartDate = DateTime.Parse("2020-08-01"), dteBookedEndDate = DateTime.Parse("2020-08-15"),
                    dteTotalPaymentDueDate = DateTime.Parse("2020-08-01"),dteTotalPaymentDueAmount = 10345,dteTotalPaymentMadeOn = DateTime.Parse("2020-08-01"), memBookingComments ="Espero la estancia sea agradable"
                }
            };

            foreach(tblBookings b in Bookings)
            {
                context.tblBooking.Add(b);
            }
            context.SaveChanges();

            var PaymentMethod = new tblPaymentMethods[]
             {

                new tblPaymentMethods{ingPaymentMethodID=1,txtPaymentMethod="Tarjeta Debito"},
                new tblPaymentMethods{ingPaymentMethodID=2,txtPaymentMethod="Tarjeta Crédito"},
                new tblPaymentMethods{ingPaymentMethodID=3,txtPaymentMethod="Efectivo"}
            };

            foreach(tblPaymentMethods p in PaymentMethod)
            {
                context.tblPaymentMethod.Add(p);
            }
            context.SaveChanges();

            var Payment = new tblPayments []
            {
                new tblPayments{ingPaymentID=1,ingBookingID=Bookings.Single(i=> i.dteTotalPaymentMadeOn==DateTime.Parse("2020-08-01")).ingBookingID,
                ingCustomerID=customers.Single(i=> i.txtCustomerForenames=="Macario").IngCutomerID,
                ingPaymentMethodID=PaymentMethod.Single(i=>i.txtPaymentMethod=="Efectivo").ingPaymentMethodID,
                curPaymentAmount=10345, memPaymentComments ="Excelente precio"
                },

                new tblPayments{ingPaymentID=2,ingBookingID=Bookings.Single(i=> i.dteTotalPaymentMadeOn==DateTime.Parse("2020-10-16")).ingBookingID,
                ingCustomerID=customers.Single(i=> i.txtCustomerForenames=="Guadalupe").IngCutomerID,
                ingPaymentMethodID=PaymentMethod.Single(i=>i.txtPaymentMethod=="Tarjeta Debito ").ingPaymentMethodID,
                curPaymentAmount=2123, memPaymentComments ="precio accesible"
                },

                 new tblPayments{ingPaymentID=3,ingBookingID=Bookings.Single(i=> i.dteTotalPaymentMadeOn==DateTime.Parse("2020-11-13")).ingBookingID,
                ingCustomerID=customers.Single(i=> i.txtCustomerForenames=="Paola").IngCutomerID,
                ingPaymentMethodID=PaymentMethod.Single(i=>i.txtPaymentMethod=="Tarjeta Crédito ").ingPaymentMethodID,
                curPaymentAmount=6783, memPaymentComments ="precio accesible"
                }

            };

            foreach(tblPayments p in Payment)
            {
                context.tblPayment.Add(p);
            }
            context.SaveChanges();

            var Guest = new tblGuests []
            {
                new tblGuests {txtGuestTitle ="Paola Lizeth Medina Trejo", txtGuestForenames ="Lizzeth", txtGuestSurnames="Valois Martinez", dteGuestDOB=DateTime.Parse("1996-12-16"),
                txtGuestAddressStreet ="Roberto Cabral", txtGuestAddressTown ="Zacatecas", txtGuestAddressCountry="México", txtGuestAddressPostalCode ="98020", txtGuestContactPhone = "492-137-6049"},

                 new tblGuests { 
                txtGuestTitle = "Francisco Rodarte", txtGuestForenames = "Guadalupe", txtGuestSurnames ="Reyes",
                dteGuestDOB= DateTime.Parse("1990-05-20"), txtGuestAddressStreet = "San benito #10",  txtGuestAddressCountry = "México",
                txtGuestAddressTown= "Guadalajara", txtGuestAddressPostalCode = "12000", txtGuestContactPhone="442-143-1232" },

                 new tblGuests { 
                txtGuestTitle = "Juana María López", txtGuestForenames = "Macario", txtGuestSurnames ="López Rodriguez",
                dteGuestDOB= DateTime.Parse("1987-07-10"), txtGuestAddressStreet = "Madero #5",  txtGuestAddressCountry = "México",
                txtGuestAddressTown= "Zacatecas", txtGuestAddressPostalCode = "98020", txtGuestContactPhone="492-345-6789" }
            
            };

            foreach(tblGuests g in Guest){
                context.tblGuest.Add(g);
            }
            context.SaveChanges();

            var RoomType = new tblRoomTypes[]
            {
                new tblRoomTypes{strRoomType="Sencilla"},
                new tblRoomTypes{strRoomType="Doble"},
                new tblRoomTypes{strRoomType="Triple"},
                new tblRoomTypes{strRoomType="Cuadruple"}
            };

            foreach(tblRoomTypes r in RoomType){
                context.tblRoomType.Add(r);
            }
            context.SaveChanges();

            var RoomBand = new tblRoomBands []
            {
                new tblRoomBands {strBandDesc= "una cama matrimonial"},
                new tblRoomBands {strBandDesc= "dos camas matrimoniales"},
                new tblRoomBands {strBandDesc= "dos camas matrimoniales y un sofacama"}

            };

            foreach(tblRoomBands r in RoomBand)
            {
            context.tblRoomBand.Add(r);
            }
            context.SaveChanges();

            var Price = new tblRoomPrices []
            {
                new tblRoomPrices {curRoomPrice = 520},
                new tblRoomPrices {curRoomPrice = 1220},
                new tblRoomPrices {curRoomPrice = 1620},
                new tblRoomPrices {curRoomPrice = 1920}
            };

            foreach (tblRoomPrices r in Price)
            {
                context.tblRoomPrice.Add(r);
            }
            context.SaveChanges();

            var Room = new tblRooms[]
            {
                new tblRooms{ingRoomTypeID=RoomType.Single(i=>i.strRoomType=="Sencilla").ingRoomTypeID,
                ingRoomBandID=RoomBand.Single(i=>i.strBandDesc=="una cama matrimonial").ingRoomBandID,
                ingRoomPriceID=Price.Single(i=>i.curRoomPrice==520).ingRoomPriceID, strFloor="2do",memAdditionNotes="Habitacion para dos personas"},
                
                new tblRooms{ingRoomTypeID=RoomType.Single(i=>i.strRoomType=="Doble").ingRoomTypeID,
                ingRoomBandID=RoomBand.Single(i=>i.strBandDesc=="dos camas matrimoniales").ingRoomBandID,
                ingRoomPriceID=Price.Single(i=>i.curRoomPrice==1220).ingRoomPriceID, strFloor="2do",memAdditionNotes="Habitacion para dos personas"},

                new tblRooms{ingRoomTypeID=RoomType.Single(i=>i.strRoomType=="Triple").ingRoomTypeID,
                ingRoomBandID=RoomBand.Single(i=>i.strBandDesc=="dos camas matrimoniales y un sofacama").ingRoomBandID,
                ingRoomPriceID=Price.Single(i=>i.curRoomPrice==1620).ingRoomPriceID, strFloor="8vo",memAdditionNotes="Habitacion para maximo 4 personas"}
            };

            foreach(tblRooms r in Room){
                context.tblRoom.Add(r);
            }
            context.SaveChanges();

            var BookingRoom = new tblLINK_BookingsRooms[]
            {
                new tblLINK_BookingsRooms{ingBookingID=Bookings.Single(i=>i.dteBookedStartDate==DateTime.Parse("2020-08-01")).ingBookingID,
                ingGuestID=Guest.Single(i=>i.txtGuestTitle=="Juana María López").ingGuestID,
                ingRoomID=Room.Single(i=>i.strFloor=="8vo").ingRoomID},

                new tblLINK_BookingsRooms{ingBookingID=Bookings.Single(i=>i.dteBookedStartDate==DateTime.Parse("2020-12-16")).ingBookingID,
                ingGuestID=Guest.Single(i=>i.txtGuestTitle=="Paola Lizeth Medina Trejo").ingGuestID,
                ingRoomID=Room.Single(i=>i.strFloor=="2do").ingRoomID},

                 new tblLINK_BookingsRooms{ingBookingID=Bookings.Single(i=>i.dteBookedStartDate==DateTime.Parse("2020-11-16")).ingBookingID,
                ingGuestID=Guest.Single(i=>i.txtGuestTitle=="Francisco Rodarte").ingGuestID,
                ingRoomID=Room.Single(i=>i.strFloor=="2do").ingRoomID},
            };

            foreach(tblLINK_BookingsRooms b in BookingRoom)
            {
                context.tblLINK_BookingsRoom.Add(b);
            }
            context.SaveChanges();

            var Facility = new tblFacilitiesList []
            {
                new tblFacilitiesList{FacilityDesc="Cama matrimonial, baño completo, tv y wifi"},
                new tblFacilitiesList{FacilityDesc="Dos camas matrimoniales, baño completo, tv, wifi y minibar"},
                new tblFacilitiesList{FacilityDesc="Dos camas matrimoniales, un sofacama, baño completo, tv, wifi y minibar"},

            };

            foreach(tblFacilitiesList f in Facility)
            {
                context.tblFacilitiesList.Add(f);
            }
            context.SaveChanges();

            var RoomFacility = new tblLINK_RoomsFacilities[]
            {
                new tblLINK_RoomsFacilities{ingRoomID=Room.Single(i=>i.strFloor=="2do").ingRoomID,
                ingFacilityID=Facility.Single(i=>i.FacilityDesc=="Cama matrimonial, baño completo, tv y wifi").ingFacilityID,
                strFacilityDetails="Habitación sencilla ideal para dos personas"}
            };

            foreach(tblLINK_RoomsFacilities r in RoomFacility)
            {
                context.tblLINK_RoomsFacilitie.Add(r);
            }
            context.SaveChanges();
        }

    }
}