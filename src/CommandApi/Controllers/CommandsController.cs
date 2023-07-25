using Microsoft.AspNetCore.Mvc;
using CommandApi.Data;
using CommandApi.Dtos;
using AutoMapper;

namespace CommandApi.Controllers;

[Route("api/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommandApiRepo _repository;
    private readonly IMapper _mapper;
    public CommandsController(ICommandApiRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
        var commandItems = _repository.GetAllCommands();

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
        var commandItem = _repository.GetCommandById(id);
        if(commandItem == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
    }
}
