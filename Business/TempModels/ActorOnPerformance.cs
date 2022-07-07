﻿using Data.Models;

namespace Business.TempModels
{
    public record ActorOnPerformance
    {
        public Person Actor { get; init; }
        
        public string Role { get; init; }

        public bool IsMainRole { get; init; }
    }
}
