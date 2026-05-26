using NTierTodoApp.Business;
using NTierTodoApp.Models;

namespace NTierTodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService taskService;

        public HomeController(TaskService service)
        {
            taskService = service;
        }

        public ActionResult Index()
        {
            var tasks = taskService.GetTasks();
            return View(tasks);
        }

        [HttpPost]
        public ActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                taskService.AddTask(title);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CompleteTask(int id)
        {
            taskService.CompleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}