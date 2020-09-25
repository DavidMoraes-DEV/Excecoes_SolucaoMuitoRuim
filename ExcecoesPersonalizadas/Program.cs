using ExcecoesPersonalizadas.Entities;
using System;

namespace ExcecoesPersonalizadas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Check-in date (dd//MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Check-Out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            //SOLUÇÃO MUITO RUIM:
            if (checkOut <= checkIn) //Esse tipo de solução é ruim por ter que implementar toda a lógica de instanciação da reserva com if e else encadeados no programa principal, pois a lógica de verificar deveria estar dentro da classe reserva e não no programa principal, causando uma delegação de responsabilidades.
            {
                Console.WriteLine("Error in resenvation: Check-out date must be after check-in date!" );
            }
            else
            {
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.WriteLine("Check-in date (dd//MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Check-Out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                DateTime now = DateTime.Now;
                if(checkIn < now || checkOut < now)
                {
                    Console.WriteLine("Error in reservation: Reservation dates for update must be future dates!");
                }
                else if (checkOut <= checkIn)
                {
                    Console.WriteLine("Error in resenvation: Check-out date must be after check-in date!");
                }
                else
                {
                    reservation.UpdateDates(checkIn, checkOut);
                    Console.WriteLine("Reservation: " + reservation);
                }
            }
        }
    }
}
