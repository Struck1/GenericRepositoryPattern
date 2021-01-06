using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.API.DTOs;
using MusicMarket.API.Validators;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            this._artistService = artistService;
            this._mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtist()
        {
            var artists = await _artistService.GetAllArtist();

            var artistResource = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(artists);

            return Ok(artistResource);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ArtistDTO>> GetArtistByID(int id)
        {
            var artist = await _artistService.GetArtistById(id);

            var artistResource = _mapper.Map<Artist, ArtistDTO>(artist);

            return Ok(artistResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ArtistDTO>> CreateArtist([FromBody] SaveArtistDTO saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var artistToCreate = _mapper.Map<SaveArtistDTO, Artist>(saveArtistResource);

            var newArtist = await _artistService.CreateArtist(artistToCreate);

            var artist = await _artistService.GetArtistById(newArtist.Id);

            var artistResource = _mapper.Map<Artist, ArtistDTO>(artist);

            return Ok(artistResource);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ArtistDTO>> UpdateArtistById(int id, [FromBody] SaveArtistDTO saveArtistDTO)
        {
            var validation = new SaveArtistResourceValidator();

            var validationResource = await validation.ValidateAsync(saveArtistDTO);

            if (id == 0 || !validationResource.IsValid)
            {
                return BadRequest(validationResource.Errors);
            }

            var artistToBeUpdate = await _artistService.GetArtistById(id);

            if (artistToBeUpdate == null)
            {
                return NotFound();
            }

            var artist = _mapper.Map<SaveArtistDTO, Artist>(saveArtistDTO);

            await _artistService.UpdateArtist(artistToBeUpdate, artist);

            var updateArtist = await _artistService.GetArtistById(id);

            var updateArtistResource = _mapper.Map<Artist, ArtistDTO>(updateArtist);

            return Ok(updateArtistResource);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtistById(id);

            await _artistService.DeleteArtist(artist);

            return NoContent();

        }


    }
}
