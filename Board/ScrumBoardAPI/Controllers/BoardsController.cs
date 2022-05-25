using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.DTO;
using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IScrumBoardRepository _repository;

    public BoardsController(IScrumBoardRepository repository)
    {
        _repository = repository;
    }
    
    // Получить список досок
    // GET: api/boards
    [HttpGet]
    public IActionResult GetListBoards()
    {
        IEnumerable<BoardDTO> boards;
        try
        {
            boards = _repository.GetAllBoard();
        }
        catch
        {
            boards = Enumerable.Empty<BoardDTO>();
        }
        return Ok(boards);
    }

    // Получить доску
    // GET api/boards/{boardGUID}
    [HttpGet("{boardGUID}")]
    public IActionResult GetBoardByGUID(string boardGUID)
    {
        BoardDTO board;
        try
        {
            board = _repository.GetBoard(boardGUID);
        }
        catch
        {
            return NotFound();
        }
        return Ok(board);
    }

    // Создать доску
    // POST api/boards
    [HttpPost]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO param)
    {
        try
        {
            _repository.AddBoard(param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Удалить доску
    // DELETE api/boards/{boardGUID}
    [HttpDelete("{boardGUID}")]
    public IActionResult DeleteBoard(string boardGUID)
    {
        try
        {
            _repository.DeleteBoard(boardGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Создать колонку
    // POST api/boards/{boardGUID}/column
    [HttpPost("{boardGUID}/column")]
    public IActionResult CreateColumn(string boardGUID, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.AddColumn(boardGUID, param);
        }
        catch
        {
            return NotFound();
        }
        return Ok();
    }

    // Редактировать колонку
    // PUT api/boards/{columnGUID}/column
    [HttpPut("{boardGUID}/column")]
    public IActionResult EditColumn(string boardGUID, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.EditColumn(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Удалить колонку
    // DELETE api/boards/<columnGUID>/column
    [HttpDelete("{boardGUID}/column/{columnGUID}")]
    public IActionResult DeleteColumn(string boardGUID, string columnGUID)
    {
        try
        {
            _repository.DeleteColumn(boardGUID, columnGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Создать задачу
    // POST api/boards/{boardGUID}/task
    [HttpPost("{boardGUID}/task")]
    public IActionResult CreateTask(string boardGUID, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.AddTask(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Редактировать задачу
    // PUT api/boards/{boardGUID}/task
    [HttpPut("{boardGUID}/task")]
    public IActionResult EditTask(string boardGUID, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.EditTask(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Удалить задачу
    // DELETE api/boards/{boardGUID}/task/{taskGUID}
    [HttpDelete("{boardGUID}/task/{taskGUID}")]
    public IActionResult DeleteTask(string boardGUID, string taskGUID)
    {
        try
        {
            _repository.DeleteTask(boardGUID, taskGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    // Переместить задачу из колонки в колонку
    // PUT api/boards/{boardGUID}/task{taskGUID}
    [HttpPut("{boardGUID}/task/{taskGUID}")]
    public IActionResult TransferTask(string boardGUID, string taskGUID, [FromBody] TransferTaskDTO param)
    {
        try
        {
            _repository.TransferTask(boardGUID, taskGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }
}
