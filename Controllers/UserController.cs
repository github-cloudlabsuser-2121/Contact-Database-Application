using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Return the view to display the list of users
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the specified ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the view to display the user details
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Return the view to create a new user
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the new user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user with the specified ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the view to edit the user
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Find the user with the specified ID
            User existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, update the user's information
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Age = user.Age;

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user with the specified ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the view to confirm the deletion
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user with the specified ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, remove the user from the userlist
            if (user != null)
            {
                userlist.Remove(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }
    }
}
