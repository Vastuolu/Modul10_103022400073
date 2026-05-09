using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Modul10_103022400073.Entity;
using System.Diagnostics;

namespace Modul10_103022400073.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> _games = new List<Game>
        {
            new Game {Id = 1, Nama = "Valorant", Developer= "Riot Games", TahunRilis= 2020, Genre= "FPS",
                        Rating= 8.5, Platform= ["PC"], Mode= ["Multiplayer"], IsOnline= true, Harga= 0},

            new Game {Id = 2, Nama= "GTA V", Developer= "Rockstar Games", TahunRilis= 2013, Genre= "Open World",
                        Rating= 9.5, Platform= ["PC", "PS4", "PS5", "Xbox"], Mode= ["Singleplayer","Multiplayer"], IsOnline= true, Harga= 300000},

            new Game {Id = 3, Nama= "The Witcher 3", Developer= "CD Projekt Red", TahunRilis= 2015, Genre= "RPG",
                        Rating= 9.7, Platform= ["PC", "PS4", "PS5", "Xbox", "Switch"], Mode= ["Singleplayer"], IsOnline= false, Harga= 250000},
        };

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _games;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            foreach (var game in _games)
            {
                if (game.Id == id)
                {
                    return game;
                }
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Game game)
        {
            _games.Add(game);
            
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Game gameData)
        {
            var index = _games.FindIndex(g => g.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            _games[index] = gameData;
            return Ok(gameData);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            foreach (var game in _games)
            {
                if (game.Id == id)
                {
                    _games.Remove(game);
                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
