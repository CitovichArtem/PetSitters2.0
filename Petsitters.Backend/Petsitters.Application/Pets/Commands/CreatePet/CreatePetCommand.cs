﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Petsitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}