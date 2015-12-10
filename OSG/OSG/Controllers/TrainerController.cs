using System.Web.Mvc;
using Gateway.DomainModel;
using Gateway.Facade;

namespace OSG.Controllers
{
    public class TrainerController : Controller
    {
        Facade facade = new Facade();

        // GET: Trainer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Options()
        {
            return View(facade.GetTrainerGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Trainer());
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            facade.GetTrainerGateway().Create(new Trainer()
            {
                Id = trainer.Id,
                Picture = trainer.Picture,
                Description = trainer.Description,
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                PhoneNo = trainer.PhoneNo
            });
            return RedirectToAction("Options", "Trainer");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Trainer trainer = facade.GetTrainerGateway().ReadById(id);
            return View(trainer);
        }

        [HttpPost]
        public ActionResult Edit(Trainer trainer)
        {
            facade.GetTrainerGateway().Update(trainer);
            return RedirectToAction("Options", "Trainer");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            facade.GetTrainerGateway().Delete(id);
            return RedirectToAction("Options", "Trainer");
        }


    }
}