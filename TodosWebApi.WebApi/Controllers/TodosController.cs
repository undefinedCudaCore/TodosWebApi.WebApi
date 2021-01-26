using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Data;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;

namespace TodosWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TodosController> _logger;
        private readonly DataContext _context;

        public TodosController(ILogger<TodosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
                return await _context.Items.ToListAsync();
        }

        [HttpPost]
        public async Task<TodoDto> Create(TodoDto item)
        {
            _context.Items.Add(new TodoItem()
            {
                Title = item.Title,
                Completed = item.Completed
            });

            await _context.SaveChangesAsync();

            return item;
        }
    }
}

