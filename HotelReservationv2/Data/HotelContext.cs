using HotelReservationv2.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationv2.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
        :base(options){}

        public DbSet<tblCustomers> tblCustomer {get; set;}
        public DbSet<tblBookings> tblBooking {get; set;}
        public DbSet<tblPaymentMethods> tblPaymentMethod {get; set;}
        public DbSet<tblPayments> tblPayment {get; set;}
        public DbSet<tblLINK_BookingsRooms> tblLINK_BookingsRoom {get; set;}
        public DbSet<tblGuests> tblGuest {get; set;}
        public DbSet<tblRooms> tblRoom {get; set;}
        public DbSet<tblLINK_RoomsFacilities> tblLINK_RoomsFacilitie {get; set;}
        public DbSet<tblFacilitiesList> tblFacilitiesList {get; set;}
        public DbSet<tblRoomTypes> tblRoomType {get; set;}
        public DbSet<tblRoomBands> tblRoomBand {get; set;}
        public DbSet<tblRoomPrices> tblRoomPrice {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<tblCustomers>().ToTable("Customers");
            modelBuilder.Entity<tblBookings>().ToTable("Bookings");
            modelBuilder.Entity<tblPaymentMethods>().ToTable("Payment Methods");
            modelBuilder.Entity<tblPayments>().ToTable("Payments");
            modelBuilder.Entity<tblLINK_BookingsRooms>().ToTable("Booking Rooms");
            modelBuilder.Entity<tblRooms>().ToTable("Rooms");
            modelBuilder.Entity<tblGuests>().ToTable("Guests");
            modelBuilder.Entity<tblRoomTypes>().ToTable("Room Types");
            modelBuilder.Entity<tblRoomBands>().ToTable("Room Bands");
            modelBuilder.Entity<tblRoomPrices>().ToTable("Room Prices");
            modelBuilder.Entity<tblLINK_RoomsFacilities>().ToTable("Room Facilities");
            modelBuilder.Entity<tblFacilitiesList>().ToTable("Facilities List");

             modelBuilder.Entity<tblLINK_BookingsRooms>().HasKey(c=> new {c.ingBookingID,c.ingGuestID,c.ingRoomID});
             modelBuilder.Entity<tblLINK_RoomsFacilities>().HasKey(c=> new{c.ingRoomID,c.ingFacilityID});
        }
        
    

    }
}