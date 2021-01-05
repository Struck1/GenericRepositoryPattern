
using FluentValidation;
using MusicMarket.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.API.Validators
{
    public class SaveMusicResourceValidator : AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.ArtistId)
                .NotEmpty()
                .WithMessage("'Artist Id' should not be empty");
        }
    }
}
