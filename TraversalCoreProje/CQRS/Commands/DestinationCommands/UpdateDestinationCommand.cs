﻿namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int DestionID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
