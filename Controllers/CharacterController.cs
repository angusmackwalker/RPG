using Microsoft.AspNetCore.Mvc;
using RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static  List<Character> Characters = new List<Character> {
            new Character(),
            new Character{ Id = 1, Name="Angus"}
        };
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if(null == Characters[0] || string.Empty == Characters[0].Name)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Characters);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            //return Ok(Characters[id]);
            //This method will return null if id is not found; above method will throw an index out of range error if not found.
            if(null == Characters.FirstOrDefault(c => c.Id == id))
            {
                return NotFound();
            }
            else
            {
                return Ok(Characters.FirstOrDefault(c => c.Id == id));
            }
            
        }

        [HttpPost]
        public IActionResult AddCharacter(Character c)
        {
            Characters.Add(c);
            return Ok(Characters);
        }

    }
}