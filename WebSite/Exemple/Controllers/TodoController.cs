using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Session;
using WebApplication1.Utils;
using WebApplication1.Attributes;

namespace WebApplication1.Controllers
{
    [LoggedRequired]
    public class TodoController : ControllerBase
    {
        private readonly IControllerAPI _controllerAPI;

        public TodoController(IControllerAPI controllerAPI, ISessionManager sessionManager) : base(sessionManager)
        {
            _controllerAPI = controllerAPI;
        }

        public IActionResult List()
        {
            IEnumerable<Todo> listTodo = _controllerAPI.GetAllAPI<IEnumerable<Todo>>("Todo/Gets/" + SessionManager.IdUser);
            return View(listTodo);
          
        }


        [HttpPost]
        public IActionResult Create() { return View(); }

        
        [ValidateAntiForgeryToken]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _controllerAPI.PostAPI<Todo>("Todo/Post", todo);
                return RedirectToAction("Index");
            }
            else
                return View(new Todo());

            
        }


        
        public IActionResult Delete(int id)
        {
            _controllerAPI.Delete("Todo/Delete", id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            return View(new Todo());
        }


        [HttpGet]
        public IActionResult Edit(int id) { return View(new Todo()); }


        [ValidateAntiForgeryToken]
        public IActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _controllerAPI.PutAPI<Todo>("Todo/Edit", todo);
                return RedirectToAction("List");
            }
            else
            {
                return View(new Todo());
            }
        }



        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateTodo(int id)
        {
            Todo todoValid = _controllerAPI.GetOneAPI<Todo>("Todo/Get", id);

            todoValid.Done = true;
            _controllerAPI.PutAPI<Todo>("Todo/Put", todoValid);

            return RedirectToAction("Index");
        }


        

    }
}