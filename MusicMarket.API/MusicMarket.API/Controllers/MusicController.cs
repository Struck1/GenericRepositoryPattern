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
    public class MusicController : ControllerBase
    {

        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            this._musicService = musicService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();

            var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(musics);

            return Ok(musicResources);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            var musicResources = _mapper.Map<Music, MusicDTO>(music);
            return Ok(musicResources);
        }


        [HttpPost("")]

        public async Task<ActionResult<MusicDTO>> CreateMusic([FromBody] SaveMusicDTO saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveMusicResource);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var musicToCreate = _mapper.Map<SaveMusicDTO, Music>(saveMusicResource);

            var newMusic = await _musicService.CreateMusic(musicToCreate);

            var music = await _musicService.GetMusicById(newMusic.Id);

            var musicResource = _mapper.Map<Music, MusicDTO>(music);

            return Ok(musicResource);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<MusicDTO>> UpdateMusic(int id, [FromBody] SaveMusicDTO saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            if (!validationResult.IsValid || id == 0)
            {
                return BadRequest(validationResult.Errors);
            }

            var musicToBeUpdate = await _musicService.GetMusicById(id);

            if (musicToBeUpdate == null)
            {
                return NotFound();
            }

            var music = _mapper.Map<SaveMusicDTO, Music>(saveMusicResource);

            await _musicService.UpdateMusic(musicToBeUpdate, music);

            var updateMusic = await _musicService.GetMusicById(id);

            var updateMusicDTO = _mapper.Map<Music, MusicDTO>(updateMusic);

            return Ok(updateMusicDTO);

        }

    }
}
