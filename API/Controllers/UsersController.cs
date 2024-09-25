using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();

        return Ok(users);
    }


    [HttpGet("{username}")] // api/users/username
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto, IMapper mapper)
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (username == null)
        {
            return BadRequest("User not found");
        }

        var user = await userRepository.GetUserByUsernameAsync(username);

        if (user == null)
        {
            return BadRequest("Could not find user");
        }
        // map from memberUpdateDto to userObject
        mapper.Map(memberUpdateDto, user);

        // explicitly save changes
        userRepository.Update(user);
        // userRepository.Update(user);

        
        if (await userRepository.SaveAllAsync())
        {
            // Update was successful
            return NoContent();
        }

        return BadRequest("Failed to update user");
    }
}
