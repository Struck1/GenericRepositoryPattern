using FluentValidation;
using MusicMarket.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.API.Validators
{
    public class SaveArtistResourceValidator : AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
